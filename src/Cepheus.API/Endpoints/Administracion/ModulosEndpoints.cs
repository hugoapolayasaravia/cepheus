using Cepheus.Application.Features.Administracion.Modulos.CreateModulo;
using Cepheus.Application.Features.Administracion.Modulos.GetModuloById;
using Cepheus.Application.Features.Administracion.Modulos.GetModulosPaginated;
using Cepheus.Application.Features.Administracion.Modulos.ToggleModuloStatus;
using Cepheus.Application.Features.Administracion.Modulos.UpdateModulo;
using MediatR;

namespace Cepheus.API.Endpoints.Administracion
{
    public static class ModulosEndpoints
    {
        public static void MapModulosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/modulos")
                .WithTags("Modulos")
                .RequireAuthorization();

            group.MapPost("/", async (CreateModuloCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/modulos/{result.Id}", result);
            })
            .WithName("CreateModulo")
            .RequireAuthorization("MODULOS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetModulosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetModulosPagedQueryString")
            .RequireAuthorization("MODULOS.VIEW");

            group.MapPost("/paged/body", async (
                GetModulosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetModulosPagedBody")
            .RequireAuthorization("MODULOS.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetModuloByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetModuloById")
            .RequireAuthorization("MODULOS.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateModuloCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateModulo")
            .RequireAuthorization("MODULOS.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleModuloStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleModuloStatus")
            .RequireAuthorization("MODULOS.UPDATE");
        }
    }


}
