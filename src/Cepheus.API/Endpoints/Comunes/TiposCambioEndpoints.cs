using Cepheus.Application.Features.Comunes.TiposCambio.CreateTipoCambio;
using Cepheus.Application.Features.Comunes.TiposCambio.GetTipoCambioByDate;
using Cepheus.Application.Features.Comunes.TiposCambio.GetTipoCambioById;
using Cepheus.Application.Features.Comunes.TiposCambio.GetTiposCambioPaginated;
using Cepheus.Application.Features.Comunes.TiposCambio.UpdateTipoCambio;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class TiposCambioEndpoints
    {
        public static void MapTiposCambioEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/tipos-cambio")
                .WithTags("TiposCambio")
                .RequireAuthorization();

            group.MapPost("/", async (CreateTipoCambioCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/tipos-cambio/{result.Id}", result);
            })
            .WithName("CreateTipoCambio")
            .RequireAuthorization("TIPOSCAMBIO.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetTiposCambioPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetTiposCambioPagedQueryString")
            .RequireAuthorization("TIPOSCAMBIO.VIEW");

            group.MapPost("/paged/body", async (
                GetTiposCambioPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetTiposCambioPagedBody")
            .RequireAuthorization("TIPOSCAMBIO.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetTipoCambioByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetTipoCambioById")
            .RequireAuthorization("TIPOSCAMBIO.VIEW");

            group.MapGet("/by-date/{date}", async (DateOnly date, ISender sender) =>
            {
                var result = await sender.Send(new GetTipoCambioByDateQuery(date));
                return Results.Ok(result);
            })
            .WithName("GetTipoCambioByDate")
            .RequireAuthorization("TIPOSCAMBIO.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateTipoCambioCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateTipoCambio")
            .RequireAuthorization("TIPOSCAMBIO.UPDATE");
        }
    }
}
