using Cepheus.Application.Administracion.Features.Submodulos.CreateSubmodulo;
using Cepheus.Application.Administracion.Features.Submodulos.GetSubmoduloById;
using Cepheus.Application.Administracion.Features.Submodulos.GetSubmodulosPaginated;
using Cepheus.Application.Administracion.Features.Submodulos.ToggleSubmoduloStatus;
using Cepheus.Application.Administracion.Features.Submodulos.UpdateSubmodulo;
using MediatR;

namespace Cepheus.API.Endpoints.Administracion
{
    public static class SubmodulosEndpoints
    {
        public static void MapSubmodulosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/submodulos")
                .WithTags("Submodulos")
                .RequireAuthorization();

            group.MapPost("/", async (CreateSubmoduloCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/submodulos/{result.Id}", result);
            })
            .WithName("CreateSubmodulo")
            .RequireAuthorization("SUBMODULOS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetSubmodulosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetSubmodulosPagedQueryString")
            .RequireAuthorization("SUBMODULOS.VIEW");

            group.MapPost("/paged/body", async (
                GetSubmodulosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetSubmodulosPagedBody")
            .RequireAuthorization("SUBMODULOS.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetSubmoduloByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetSubmoduloById")
            .RequireAuthorization("SUBMODULOS.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateSubmoduloCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateSubmodulo")
            .RequireAuthorization("SUBMODULOS.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleSubmoduloStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleSubmoduloStatus")
            .RequireAuthorization("SUBMODULOS.UPDATE");
        }
    }


}
