using Cepheus.Application.Features.Administracion.Users.AssignUserRoles;
using Cepheus.Application.Features.Administracion.Users.ChangePassword;
using Cepheus.Application.Features.Administracion.Users.CreateUser;
using Cepheus.Application.Features.Administracion.Users.GetUserById;
using Cepheus.Application.Features.Administracion.Users.GetUserRoles;
using Cepheus.Application.Features.Administracion.Users.GetUsersPaginated;
using Cepheus.Application.Features.Administracion.Users.ToggleUserStatus;
using Cepheus.Application.Features.Administracion.Users.UpdateUser;
using MediatR;

namespace Cepheus.API.Endpoints.Administracion
{
    public static class UsersEndpoints
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users")
                .WithTags("Users")
                .RequireAuthorization();

            // POST /api/users
            group.MapPost("/", async (CreateUserCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/users/{result.Id}", result);
            })
            .WithName("CreateUser")
            .RequireAuthorization("USERS.CREATE");

            // GET /api/users/paged
            group.MapGet("/paged", async (
                [AsParameters] GetUsersPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetUsersPagedQueryString")
            .RequireAuthorization("USERS.VIEW");

            // POST /api/users/paged/body
            group.MapPost("/paged/body", async (
                GetUsersPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetUsersPagedBody")
            .RequireAuthorization("USERS.VIEW");

            // GET /api/users/{id}
            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetUserByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetUserById")
            .RequireAuthorization("USERS.VIEW");

            // PUT /api/users/{id}
            group.MapPut("/{id:int}", async (int id, UpdateUserCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateUser")
            .RequireAuthorization("USERS.UPDATE");

            // PATCH /api/users/{id}/toggle-status
            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleUserStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleUserStatus")
            .RequireAuthorization("USERS.UPDATE");

            // PATCH /api/users/{id}/change-password — self-service. Solo requiere estar
            // autenticado (el Handler ya valida que {id} sea el propio usuario), no un
            // permiso de administración: cualquiera puede cambiar SU PROPIA contraseña.
            group.MapPatch("/{id:int}/change-password", async (
                int id, ChangePasswordCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                await sender.Send(command);
                return Results.NoContent();
            })
            .WithName("ChangePassword");

            // GET /api/users/{id}/roles
            group.MapGet("/{id:int}/roles", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetUserRolesQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetUserRoles")
            .RequireAuthorization("USERS.VIEW");

            // PUT /api/users/{id}/roles
            group.MapPut("/{id:int}/roles", async (
                int id, AssignUserRolesCommand command, ISender sender) =>
            {
                if (id != command.UserId)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el userId del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("AssignUserRoles")
            .RequireAuthorization("USERS.UPDATE");
        }
    }

}
