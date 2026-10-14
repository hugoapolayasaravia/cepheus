using Cepheus.Application.Features.Comunes.PeriodosIgv.CreatePeriodoIgv;
using Cepheus.Application.Features.Comunes.PeriodosIgv.GetPeriodoIgvByDate;
using Cepheus.Application.Features.Comunes.PeriodosIgv.GetPeriodoIgvById;
using Cepheus.Application.Features.Comunes.PeriodosIgv.GetPeriodosIgvPaginated;
using Cepheus.Application.Features.Comunes.PeriodosIgv.UpdatePeriodoIgv;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class PeriodosIgvEndpoints
    {
        public static void MapPeriodosIgvEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/periodos-igv")
                .WithTags("PeriodosIgv")
                .RequireAuthorization();

            group.MapPost("/", async (CreatePeriodoIgvCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/periodos-igv/{result.Id}", result);
            })
            .WithName("CreatePeriodoIgv")
            .RequireAuthorization("PERIODOSIGV.CREATE");

            group.MapGet("/paged", async ([AsParameters] GetPeriodosIgvPaginatedQuery query, ISender sender) =>
                Results.Ok(await sender.Send(query)))
            .WithName("GetPeriodosIgvPagedQueryString")
            .RequireAuthorization("PERIODOSIGV.VIEW");

            group.MapPost("/paged/body", async (GetPeriodosIgvPaginatedQuery query, ISender sender) =>
                Results.Ok(await sender.Send(query)))
            .WithName("GetPeriodosIgvPagedBody")
            .RequireAuthorization("PERIODOSIGV.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
                Results.Ok(await sender.Send(new GetPeriodoIgvByIdQuery(id))))
            .WithName("GetPeriodoIgvById")
            .RequireAuthorization("PERIODOSIGV.VIEW");

            group.MapGet("/by-date/{date}", async (DateOnly date, ISender sender) =>
                Results.Ok(await sender.Send(new GetPeriodoIgvByDateQuery(date))))
            .WithName("GetPeriodoIgvByDate")
            .RequireAuthorization("PERIODOSIGV.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdatePeriodoIgvCommand command, ISender sender) =>
            {
                if (id != command.Id)
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");

                return Results.Ok(await sender.Send(command));
            })
            .WithName("UpdatePeriodoIgv")
            .RequireAuthorization("PERIODOSIGV.UPDATE");
        }
    }
}
