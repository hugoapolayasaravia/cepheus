using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.CreateTipoArticulo;
using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.GetTipoArticuloByCode;
using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.GetTiposArticuloPaginated;
using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.ToggleTipoArticuloStatus;
using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.UpdateTipoArticulo;
using MediatR;

namespace Cepheus.API.Endpoints.Logistica.Catalogos
{
    public static class TiposArticuloEndpoints
    {
        public static void MapTiposArticuloEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/logistica/catalogos/tipos-articulo")
                .WithTags("Tipos de Artículo (Logística)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateTipoArticuloCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/logistica/catalogos/tipos-articulo/{result.Code}", result);
            })
            .WithName("CreateTipoArticulo")
            .RequireAuthorization("TIPOSARTICULO.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetTiposArticuloPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetTiposArticuloPagedQueryString")
            .RequireAuthorization("TIPOSARTICULO.VIEW");

            group.MapPost("/paged/body", async (
                GetTiposArticuloPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetTiposArticuloPagedBody")
            .RequireAuthorization("TIPOSARTICULO.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetTipoArticuloByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetTipoArticuloByCode")
            .RequireAuthorization("TIPOSARTICULO.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateTipoArticuloCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateTipoArticulo")
            .RequireAuthorization("TIPOSARTICULO.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleTipoArticuloStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleTipoArticuloStatus")
            .RequireAuthorization("TIPOSARTICULO.UPDATE");
        }
    }
}