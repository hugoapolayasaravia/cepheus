using Cepheus.Application.Features.Comunes.MotivosDevolucion.CreateMotivoDevolucion;
using Cepheus.Application.Features.Comunes.MotivosDevolucion.GetMotivoDevolucionById;
using Cepheus.Application.Features.Comunes.MotivosDevolucion.GetMotivosDevolucionPaginated;
using Cepheus.Application.Features.Comunes.MotivosDevolucion.ToggleMotivoDevolucionStatus;
using Cepheus.Application.Features.Comunes.MotivosDevolucion.UpdateMotivoDevolucion;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class MotivosDevolucionEndpoints
    {
        public static void MapMotivosDevolucionEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/motivos-devolucion")
                .WithTags("MotivosDevolucion")
                .RequireAuthorization();

            group.MapPost("/", async (CreateMotivoDevolucionCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/motivos-devolucion/{result.Code}", result);
            })
            .WithName("CreateMotivoDevolucion")
            .RequireAuthorization("MOTIVOSDEVOLUCION.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetMotivosDevolucionPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetMotivosDevolucionPagedQueryString")
            .RequireAuthorization("MOTIVOSDEVOLUCION.VIEW");

            group.MapPost("/paged/body", async (
                GetMotivosDevolucionPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetMotivosDevolucionPagedBody")
            .RequireAuthorization("MOTIVOSDEVOLUCION.VIEW");

            group.MapGet("/{code}", async (string code, ISender sender) =>
            {
                var result = await sender.Send(new GetMotivoDevolucionByIdQuery(code));
                return Results.Ok(result);
            })
            .WithName("GetMotivoDevolucionById")
            .RequireAuthorization("MOTIVOSDEVOLUCION.VIEW");

            group.MapPut("/{code}", async (string code, UpdateMotivoDevolucionCommand command, ISender sender) =>
            {
                if (!string.Equals(code, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateMotivoDevolucion")
            .RequireAuthorization("MOTIVOSDEVOLUCION.UPDATE");

            group.MapPatch("/{code}/toggle-status", async (string code, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleMotivoDevolucionStatusCommand(code));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleMotivoDevolucionStatus")
            .RequireAuthorization("MOTIVOSDEVOLUCION.UPDATE");
        }
    }
}
