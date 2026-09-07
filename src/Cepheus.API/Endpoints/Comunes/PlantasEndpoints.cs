using Cepheus.Application.Features.Comunes.Plantas.CreatePlanta;
using Cepheus.Application.Features.Comunes.Plantas.GetPlantaById;
using Cepheus.Application.Features.Comunes.Plantas.GetPlantasPaginated;
using Cepheus.Application.Features.Comunes.Plantas.TogglePlantaStatus;
using Cepheus.Application.Features.Comunes.Plantas.UpdatePlanta;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class PlantasEndpoints
    {
        public static void MapPlantasEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/plantas")
                .WithTags("Plantas")
                .RequireAuthorization();

            group.MapPost("/", async (CreatePlantaCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/plantas/{result.Id}", result);
            })
            .WithName("CreatePlanta")
            .RequireAuthorization("PLANTAS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetPlantasPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetPlantasPagedQueryString")
            .RequireAuthorization("PLANTAS.VIEW");

            group.MapPost("/paged/body", async (
                GetPlantasPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetPlantasPagedBody")
            .RequireAuthorization("PLANTAS.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetPlantaByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetPlantaById")
            .RequireAuthorization("PLANTAS.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdatePlantaCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdatePlanta")
            .RequireAuthorization("PLANTAS.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new TogglePlantaStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("TogglePlantaStatus")
            .RequireAuthorization("PLANTAS.UPDATE");
        }
    }
}
