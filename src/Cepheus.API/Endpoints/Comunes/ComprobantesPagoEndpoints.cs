using Cepheus.Application.Features.Comunes.ComprobantesPago.CreateComprobantePago;
using Cepheus.Application.Features.Comunes.ComprobantesPago.GetComprobantePagoById;
using Cepheus.Application.Features.Comunes.ComprobantesPago.GetComprobantesPagoPaginated;
using Cepheus.Application.Features.Comunes.ComprobantesPago.ToggleComprobantePagoStatus;
using Cepheus.Application.Features.Comunes.ComprobantesPago.UpdateComprobantePago;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class ComprobantesPagoEndpoints
    {
        public static void MapComprobantesPagoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/comprobantes-pago")
                .WithTags("ComprobantesPago")
                .RequireAuthorization();

            group.MapPost("/", async (CreateComprobantePagoCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/comprobantes-pago/{result.Code}", result);
            })
            .WithName("CreateComprobantePago")
            .RequireAuthorization("COMPROBANTESPAGO.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetComprobantesPagoPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetComprobantesPagoPagedQueryString")
            .RequireAuthorization("COMPROBANTESPAGO.VIEW");

            group.MapPost("/paged/body", async (
                GetComprobantesPagoPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetComprobantesPagoPagedBody")
            .RequireAuthorization("COMPROBANTESPAGO.VIEW");

            group.MapGet("/{code}", async (string code, ISender sender) =>
            {
                var result = await sender.Send(new GetComprobantePagoByIdQuery(code));
                return Results.Ok(result);
            })
            .WithName("GetComprobantePagoById")
            .RequireAuthorization("COMPROBANTESPAGO.VIEW");

            group.MapPut("/{code}", async (string code, UpdateComprobantePagoCommand command, ISender sender) =>
            {
                if (!string.Equals(code, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateComprobantePago")
            .RequireAuthorization("COMPROBANTESPAGO.UPDATE");

            group.MapPatch("/{code}/toggle-status", async (string code, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleComprobantePagoStatusCommand(code));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleComprobantePagoStatus")
            .RequireAuthorization("COMPROBANTESPAGO.UPDATE");
        }
    }
}
