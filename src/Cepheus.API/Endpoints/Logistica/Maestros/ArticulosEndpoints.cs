using Cepheus.Application.Features.Logistica.Maestros.Articulos.CreateArticulo;
using Cepheus.Application.Features.Logistica.Maestros.Articulos.GetArticuloByCode;
using Cepheus.Application.Features.Logistica.Maestros.Articulos.GetArticulosPaginated;
using Cepheus.Application.Features.Logistica.Maestros.Articulos.ToggleArticuloStatus;
using Cepheus.Application.Features.Logistica.Maestros.Articulos.UpdateArticulo;
using MediatR;

namespace Cepheus.API.Endpoints.Logistica.Maestros
{
    public static class ArticulosEndpoints
    {
        public static void MapArticulosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/logistica/maestros/articulos")
                .WithTags("Artículos (Logística)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateArticuloCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/logistica/maestros/articulos/{result.Code}", result);
            })
            .WithName("CreateArticulo")
            .RequireAuthorization("ARTICULOS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetArticulosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetArticulosPagedQueryString")
            .RequireAuthorization("ARTICULOS.VIEW");

            group.MapPost("/paged/body", async (
                GetArticulosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetArticulosPagedBody")
            .RequireAuthorization("ARTICULOS.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetArticuloByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetArticuloByCode")
            .RequireAuthorization("ARTICULOS.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateArticuloCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateArticulo")
            .RequireAuthorization("ARTICULOS.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleArticuloStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleArticuloStatus")
            .RequireAuthorization("ARTICULOS.UPDATE");
        }
    }
}
