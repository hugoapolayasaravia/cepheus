using Cepheus.Application.Features.Logistica.Catalogos.FormasPago.CreateFormaPago;
using Cepheus.Application.Features.Logistica.Catalogos.FormasPago.GetFormaPagoByCode;
using Cepheus.Application.Features.Logistica.Catalogos.FormasPago.GetFormasPagoPaginated;
using Cepheus.Application.Features.Logistica.Catalogos.FormasPago.ToggleFormaPagoStatus;
using Cepheus.Application.Features.Logistica.Catalogos.FormasPago.UpdateFormaPago;
using MediatR;

namespace Cepheus.API.Endpoints.Logistica.Catalogos
{
    public static class FormasPagoEndpoints
    {
        public static void MapFormasPagoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/logistica/catalogos/formas-pago")
                .WithTags("Formas de Pago (Logística)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateFormaPagoCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/logistica/catalogos/formas-pago/{result.Code}", result);
            })
            .WithName("CreateFormaPago")
            .RequireAuthorization("FORMASPAGO.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetFormasPagoPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetFormasPagoPagedQueryString")
            .RequireAuthorization("FORMASPAGO.VIEW");

            group.MapPost("/paged/body", async (
                GetFormasPagoPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetFormasPagoPagedBody")
            .RequireAuthorization("FORMASPAGO.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetFormaPagoByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetFormaPagoByCode")
            .RequireAuthorization("FORMASPAGO.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateFormaPagoCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateFormaPago")
            .RequireAuthorization("FORMASPAGO.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleFormaPagoStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleFormaPagoStatus")
            .RequireAuthorization("FORMASPAGO.UPDATE");
        }
    }
}