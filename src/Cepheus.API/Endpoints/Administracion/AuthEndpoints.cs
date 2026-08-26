using Cepheus.Application.Administracion.Features.Users.Authenticate;
using Cepheus.Application.Administracion.Features.Users.Logout;
using Cepheus.Application.Administracion.Features.Users.Me;
using Cepheus.Application.Administracion.Features.Users.Refresh;
using Cepheus.Application.Administracion.Features.Users.Register;
using MediatR;

namespace Cepheus.API.Endpoints.Administracion;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth").WithTags("Auth");

        // POST /api/auth/register — SOLO bootstrap del primer usuario.
        // Se bloquea automáticamente (409) si ya existe algún usuario en el sistema.
        group.MapPost("/register", async (RegisterCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Created($"/api/users/{result.Id}", result);
        })
        .WithName("Register")
        .AllowAnonymous()
        .RequireRateLimiting("AuthRateLimiter");

        // POST /api/auth/login
        group.MapPost("/login", async (AuthenticateCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Ok(result);
        })
        .WithName("Login")
        .AllowAnonymous()
        .RequireRateLimiting("AuthRateLimiter");

        // POST /api/auth/refresh — renueva el accessToken usando el refreshToken,
        // sin pedir contraseña de nuevo. Rota el refreshToken (revoca el usado,
        // emite uno nuevo).
        group.MapPost("/refresh", async (RefreshTokenCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Ok(result);
        })
        .WithName("RefreshToken")
        .AllowAnonymous();

        // POST /api/auth/logout — revoca el refreshToken recibido. Idempotente:
        // si ya estaba revocado o no existe, igual responde 204.
        group.MapPost("/logout", async (LogoutCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.NoContent();
        })
        .WithName("Logout")
        .AllowAnonymous();

        // GET /api/auth/me — requiere JWT válido
        group.MapGet("/me", async (ISender sender) =>
        {
            var result = await sender.Send(new GetMeQuery());
            return Results.Ok(result);
        })
        .WithName("Me")
        .RequireAuthorization();
    }
}
