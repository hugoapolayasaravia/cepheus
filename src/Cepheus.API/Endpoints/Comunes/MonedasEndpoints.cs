using Cepheus.Application.Features.Comunes.Monedas.CreateMoneda;
using Cepheus.Application.Features.Comunes.Monedas.GetMonedaById;
using Cepheus.Application.Features.Comunes.Monedas.GetMonedasPaginated;
using Cepheus.Application.Features.Comunes.Monedas.ToggleMonedaStatus;
using Cepheus.Application.Features.Comunes.Monedas.UpdateMoneda;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class MonedasEndpoints
    {
        public static void MapMonedasEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/monedas")
                .WithTags("Monedas")
                .RequireAuthorization();

            group.MapPost("/", async (CreateMonedaCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/monedas/{result.Id}", result);
            })
            .WithName("CreateMoneda")
            .RequireAuthorization("MONEDAS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetMonedasPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetMonedasPagedQueryString")
            .RequireAuthorization("MONEDAS.VIEW");

            group.MapPost("/paged/body", async (
                GetMonedasPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetMonedasPagedBody")
            .RequireAuthorization("MONEDAS.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetMonedaByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetMonedaById")
            .RequireAuthorization("MONEDAS.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateMonedaCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateMoneda")
            .RequireAuthorization("MONEDAS.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleMonedaStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleMonedaStatus")
            .RequireAuthorization("MONEDAS.UPDATE");
        }
    }
}
