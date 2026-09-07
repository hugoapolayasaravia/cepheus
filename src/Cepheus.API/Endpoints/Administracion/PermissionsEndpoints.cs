using Cepheus.Application.Features.Administracion.Permissions.CreatePermission;
using Cepheus.Application.Features.Administracion.Permissions.GetPermissionById;
using Cepheus.Application.Features.Administracion.Permissions.GetPermissionsPaginated;
using Cepheus.Application.Features.Administracion.Permissions.TogglePermissionStatus;
using Cepheus.Application.Features.Administracion.Permissions.UpdatePermission;
using MediatR;

namespace Cepheus.API.Endpoints.Administracion
{
    public static class PermissionsEndpoints
    {
        public static void MapPermissionsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/permissions")
                .WithTags("Permissions")
                .RequireAuthorization();

            group.MapPost("/", async (CreatePermissionCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/permissions/{result.Id}", result);
            })
            .WithName("CreatePermission")
            .RequireAuthorization("PERMISSIONS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetPermissionsPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetPermissionsPagedQueryString")
            .RequireAuthorization("PERMISSIONS.VIEW");

            group.MapPost("/paged/body", async (
                GetPermissionsPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetPermissionsPagedBody")
            .RequireAuthorization("PERMISSIONS.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetPermissionByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetPermissionById")
            .RequireAuthorization("PERMISSIONS.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdatePermissionCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdatePermission")
            .RequireAuthorization("PERMISSIONS.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new TogglePermissionStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("TogglePermissionStatus")
            .RequireAuthorization("PERMISSIONS.UPDATE");
        }
    }


}
