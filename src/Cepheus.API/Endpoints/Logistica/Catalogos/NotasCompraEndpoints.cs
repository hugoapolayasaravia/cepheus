using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.CreateNotaCompra;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.GetNotaCompraByCode;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.GetNotasCompraPaginated;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.ToggleNotaCompraStatus;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.UpdateNotaCompra;
using MediatR;

namespace Cepheus.API.Endpoints.Logistica.Catalogos
{
    public static class NotasCompraEndpoints
    {
        public static void MapNotasCompraEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/logistica/catalogos/notas-compra")
                .WithTags("Notas de Compra (Logística)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateNotaCompraCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/logistica/catalogos/notas-compra/{result.Code}", result);
            })
            .WithName("CreateNotaCompra")
            .RequireAuthorization("NOTASCOMPRA.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetNotasCompraPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetNotasCompraPagedQueryString")
            .RequireAuthorization("NOTASCOMPRA.VIEW");

            group.MapPost("/paged/body", async (
                GetNotasCompraPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetNotasCompraPagedBody")
            .RequireAuthorization("NOTASCOMPRA.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetNotaCompraByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetNotaCompraByCode")
            .RequireAuthorization("NOTASCOMPRA.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateNotaCompraCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateNotaCompra")
            .RequireAuthorization("NOTASCOMPRA.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleNotaCompraStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleNotaCompraStatus")
            .RequireAuthorization("NOTASCOMPRA.UPDATE");
        }
    }
}