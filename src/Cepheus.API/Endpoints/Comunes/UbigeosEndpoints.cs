using Cepheus.Application.Features.Comunes.Ubigeos.CreateUbigeo;
using Cepheus.Application.Features.Comunes.Ubigeos.GetUbigeoById;
using Cepheus.Application.Features.Comunes.Ubigeos.GetUbigeosPaginated;
using Cepheus.Application.Features.Comunes.Ubigeos.ToggleUbigeoStatus;
using Cepheus.Application.Features.Comunes.Ubigeos.UpdateUbigeo;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class UbigeosEndpoints
    {
        public static void MapUbigeosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/ubigeos")
                .WithTags("Ubigeos")
                .RequireAuthorization();

            group.MapPost("/", async (CreateUbigeoCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/ubigeos/{result.Id}", result);
            })
            .WithName("CreateUbigeo")
            .RequireAuthorization("UBIGEOS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetUbigeosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetUbigeosPagedQueryString")
            .RequireAuthorization("UBIGEOS.VIEW");

            group.MapPost("/paged/body", async (
                GetUbigeosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetUbigeosPagedBody")
            .RequireAuthorization("UBIGEOS.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetUbigeoByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetUbigeoById")
            .RequireAuthorization("UBIGEOS.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateUbigeoCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateUbigeo")
            .RequireAuthorization("UBIGEOS.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleUbigeoStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleUbigeoStatus")
            .RequireAuthorization("UBIGEOS.UPDATE");
        }
    }
}
