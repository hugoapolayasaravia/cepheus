using Cepheus.Application.Administracion.Features.Permissions.GetRolePermissions;
using Cepheus.Application.Administracion.Features.Roles.AssignRolePermissions;
using Cepheus.Application.Administracion.Features.Roles.CreateRole;
using Cepheus.Application.Administracion.Features.Roles.GetRoleById;
using Cepheus.Application.Administracion.Features.Roles.GetRolesPaginated;
using Cepheus.Application.Administracion.Features.Roles.ToggleRoleStatus;
using Cepheus.Application.Administracion.Features.Roles.UpdateRole;
using MediatR;

namespace Cepheus.API.Endpoints.Administracion
{
    public static class RolesEndpoints
    {
        public static void MapRolesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/roles")
                .WithTags("Roles")
                .RequireAuthorization();

            // POST /api/roles
            group.MapPost("/", async (CreateRoleCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/roles/{result.Id}", result);
            })
            .WithName("CreateRole")
            .RequireAuthorization("ROLES.CREATE");

            // GET /api/roles/paged
            group.MapGet("/paged", async (
                [AsParameters] GetRolesPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetRolesPagedQueryString")
            .RequireAuthorization("ROLES.VIEW");

            // POST /api/roles/paged/body
            group.MapPost("/paged/body", async (
                GetRolesPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetRolesPagedBody")
            .RequireAuthorization("ROLES.VIEW");

            // GET /api/roles/{id}
            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetRoleByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetRoleById")
            .RequireAuthorization("ROLES.VIEW");

            // PUT /api/roles/{id}
            group.MapPut("/{id:int}", async (int id, UpdateRoleCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateRole")
            .RequireAuthorization("ROLES.UPDATE");

            // PATCH /api/roles/{id}/toggle-status
            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleRoleStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleRoleStatus")
            .RequireAuthorization("ROLES.UPDATE");

            // GET /api/roles/{id}/permissions
            group.MapGet("/{id:int}/permissions", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetRolePermissionsQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetRolePermissions")
            .RequireAuthorization("ROLES.VIEW");

            // PUT /api/roles/{id}/permissions
            group.MapPut("/{id:int}/permissions", async (
                int id, AssignRolePermissionsCommand command, ISender sender) =>
            {
                if (id != command.RoleId)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el roleId del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("AssignRolePermissions")
            .RequireAuthorization("ROLES.UPDATE");
        }
    }


}
