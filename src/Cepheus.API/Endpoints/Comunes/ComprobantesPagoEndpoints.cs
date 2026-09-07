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
                return Results.Created($"/api/comunes/comprobantes-pago/{result.Id}", result);
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

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetComprobantePagoByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetComprobantePagoById")
            .RequireAuthorization("COMPROBANTESPAGO.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateComprobantePagoCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateComprobantePago")
            .RequireAuthorization("COMPROBANTESPAGO.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleComprobantePagoStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleComprobantePagoStatus")
            .RequireAuthorization("COMPROBANTESPAGO.UPDATE");
        }
    }
}
