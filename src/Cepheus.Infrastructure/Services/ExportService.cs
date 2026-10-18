using Cepheus.Application.Comun.Interfaces;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;

namespace Cepheus.Infrastructure.Services
{
    /// <summary>
    /// Excel con ClosedXML y PDF con PDFsharp/MigraDoc.
    /// Nota de despliegue: en Windows, PDFsharp usa las fuentes instaladas en el sistema.
    /// Si algún día se despliega en Linux o en un contenedor, hay que registrar un
    /// IFontResolver propio (o instalar fuentes), de lo contrario el PDF fallará.
    /// </summary>
    public class ExportService : IExportService
    {
        private const string FormatoFecha = "dd/MM/yyyy HH:mm";

        static ExportService()
        {
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;
        }

        public byte[] ToExcel(string title, IReadOnlyList<string> headers, IReadOnlyList<object?[]> rows)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add(NombreHoja(title));

            for (var c = 0; c < headers.Count; c++)
            {
                sheet.Cell(1, c + 1).Value = headers[c];
            }

            var encabezado = sheet.Range(1, 1, 1, headers.Count);
            encabezado.Style.Font.Bold = true;
            encabezado.Style.Fill.BackgroundColor = XLColor.FromHtml("#E8EDF5");

            for (var r = 0; r < rows.Count; r++)
            {
                for (var c = 0; c < headers.Count; c++)
                {
                    EscribirCelda(sheet.Cell(r + 2, c + 1), rows[r][c]);
                }
            }

            sheet.SheetView.FreezeRows(1);

            if (rows.Count > 0)
            {
                sheet.Range(1, 1, rows.Count + 1, headers.Count).SetAutoFilter();
            }

            // El ajuste de ancho solo mide las primeras filas, para no hacerlo lento con muchos datos.
            sheet.Columns().AdjustToContents(1, Math.Min(rows.Count + 1, 200));

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] ToPdf(string title, string? subtitle, IReadOnlyList<string> headers, IReadOnlyList<object?[]> rows)
        {
            var document = new Document();
            document.Info.Title = title;

            var normal = document.Styles[StyleNames.Normal]!;
            normal.Font.Name = "Arial";
            normal.Font.Size = 8;

            var section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = Orientation.Landscape;
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.TopMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1.5);

            var encabezadoDoc = section.AddParagraph(title);
            encabezadoDoc.Format.Font.Size = 14;
            encabezadoDoc.Format.Font.Bold = true;
            encabezadoDoc.Format.SpaceAfter = Unit.FromCentimeter(0.1);

            if (!string.IsNullOrWhiteSpace(subtitle))
            {
                var sub = section.AddParagraph(subtitle);
                sub.Format.Font.Size = 8;
                sub.Format.Font.Color = Colors.Gray;
                sub.Format.SpaceAfter = Unit.FromCentimeter(0.4);
            }

            var table = section.AddTable();
            table.Borders.Width = 0.25;
            table.Borders.Color = Colors.Gray;
            table.Rows.LeftIndent = 0;
            table.LeftPadding = 3;
            table.RightPadding = 3;
            table.TopPadding = 2;
            table.BottomPadding = 2;

            // Ancho útil de una hoja A4 apaisada con márgenes de 1.5 cm: 26.7 cm, repartidos
            // según el largo del contenido de cada columna.
            var anchos = CalcularAnchos(headers, rows, 26.7);
            foreach (var ancho in anchos)
            {
                table.AddColumn(Unit.FromCentimeter(ancho));
            }

            var filaEncabezado = table.AddRow();
            filaEncabezado.HeadingFormat = true;
            filaEncabezado.Format.Font.Bold = true;
            filaEncabezado.Shading.Color = Color.FromRgb(232, 237, 245);
            for (var c = 0; c < headers.Count; c++)
            {
                filaEncabezado.Cells[c].AddParagraph(headers[c]);
            }

            foreach (var fila in rows)
            {
                var fPdf = table.AddRow();
                for (var c = 0; c < headers.Count; c++)
                {
                    fPdf.Cells[c].AddParagraph(ATexto(fila[c]));
                }
            }

            var pie = section.Footers.Primary.AddParagraph();
            pie.Format.Alignment = ParagraphAlignment.Right;
            pie.Format.Font.Size = 7;
            pie.AddText("Página ");
            pie.AddPageField();
            pie.AddText(" de ");
            pie.AddNumPagesField();

            var renderer = new PdfDocumentRenderer { Document = document };
            renderer.RenderDocument();

            using var stream = new MemoryStream();
            renderer.PdfDocument.Save(stream, false);
            return stream.ToArray();
        }

        private static void EscribirCelda(IXLCell celda, object? valor)
        {
            switch (valor)
            {
                case null:
                    break;
                case DateTime fecha:
                    celda.Value = fecha;
                    celda.Style.DateFormat.Format = FormatoFecha;
                    break;
                case bool booleano:
                    celda.Value = booleano;
                    break;
                case int entero:
                    celda.Value = entero;
                    break;
                default:
                    // Siempre como texto: un valor que empiece con "=" no se interpreta como fórmula.
                    celda.Value = valor.ToString() ?? string.Empty;
                    break;
            }
        }

        private static string ATexto(object? valor)
        {
            return valor switch
            {
                null => string.Empty,
                DateTime fecha => fecha.ToString(FormatoFecha),
                bool booleano => booleano ? "Sí" : "No",
                _ => valor.ToString() ?? string.Empty
            };
        }

        private static List<double> CalcularAnchos(IReadOnlyList<string> headers, IReadOnlyList<object?[]> rows, double anchoTotal)
        {
            var pesos = new List<double>();

            for (var c = 0; c < headers.Count; c++)
            {
                var muestra = rows.Take(50).Select(f => ATexto(f[c]).Length).ToList();
                var promedio = muestra.Count > 0 ? muestra.Average() : 0;
                pesos.Add(Math.Clamp(Math.Max(headers[c].Length, promedio), 6, 40));
            }

            var suma = pesos.Sum();
            return pesos.Select(p => anchoTotal * p / suma).ToList();
        }

        private static string NombreHoja(string titulo)
        {
            var limpio = new string(titulo.Where(ch => !"[]:*?/\\".Contains(ch)).ToArray());
            return string.IsNullOrWhiteSpace(limpio) ? "Hoja1" : limpio[..Math.Min(limpio.Length, 31)];
        }
    }
}
