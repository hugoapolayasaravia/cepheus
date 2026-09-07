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
                return Results.Created($"/api/comunes/motivos-devolucion/{result.Id}", result);
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

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetMotivoDevolucionByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetMotivoDevolucionById")
            .RequireAuthorization("MOTIVOSDEVOLUCION.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateMotivoDevolucionCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateMotivoDevolucion")
            .RequireAuthorization("MOTIVOSDEVOLUCION.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleMotivoDevolucionStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleMotivoDevolucionStatus")
            .RequireAuthorization("MOTIVOSDEVOLUCION.UPDATE");
        }
    }
}
