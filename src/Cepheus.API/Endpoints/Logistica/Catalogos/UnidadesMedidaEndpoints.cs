using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.CreateUnidadMedida;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.GetUnidadMedidaByCode;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.GetUnidadesMedidaPaginated;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.ToggleUnidadMedidaStatus;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.UpdateUnidadMedida;
using MediatR;

namespace Cepheus.API.Endpoints.Logistica.Catalogos
{
    public static class UnidadesMedidaEndpoints
    {
        public static void MapUnidadesMedidaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/logistica/catalogos/unidades-medida")
                .WithTags("Unidades de Medida (Logística)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateUnidadMedidaCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/logistica/catalogos/unidades-medida/{result.Code}", result);
            })
            .WithName("CreateUnidadMedida")
            .RequireAuthorization("UNIDADESMEDIDA.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetUnidadesMedidaPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetUnidadesMedidaPagedQueryString")
            .RequireAuthorization("UNIDADESMEDIDA.VIEW");

            group.MapPost("/paged/body", async (
                GetUnidadesMedidaPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetUnidadesMedidaPagedBody")
            .RequireAuthorization("UNIDADESMEDIDA.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetUnidadMedidaByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetUnidadMedidaByCode")
            .RequireAuthorization("UNIDADESMEDIDA.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateUnidadMedidaCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateUnidadMedida")
            .RequireAuthorization("UNIDADESMEDIDA.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleUnidadMedidaStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleUnidadMedidaStatus")
            .RequireAuthorization("UNIDADESMEDIDA.UPDATE");
        }
    }
}