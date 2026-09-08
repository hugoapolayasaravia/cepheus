using Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.CreateLugarEnvio;
using Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.GetLugarEnvioByCode;
using Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.GetLugaresEnvioPaginated;
using Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.ToggleLugarEnvioStatus;
using Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.UpdateLugarEnvio;
using MediatR;

namespace Cepheus.API.Endpoints.Logistica.Catalogos
{
    public static class LugaresEnvioEndpoints
    {
        public static void MapLugaresEnvioEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/logistica/catalogos/lugares-envio")
                .WithTags("Lugares de Envío (Logística)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateLugarEnvioCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/logistica/catalogos/lugares-envio/{result.Code}", result);
            })
            .WithName("CreateLugarEnvio")
            .RequireAuthorization("LUGARESENVIO.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetLugaresEnvioPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetLugaresEnvioPagedQueryString")
            .RequireAuthorization("LUGARESENVIO.VIEW");

            group.MapPost("/paged/body", async (
                GetLugaresEnvioPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetLugaresEnvioPagedBody")
            .RequireAuthorization("LUGARESENVIO.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetLugarEnvioByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetLugarEnvioByCode")
            .RequireAuthorization("LUGARESENVIO.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateLugarEnvioCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateLugarEnvio")
            .RequireAuthorization("LUGARESENVIO.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleLugarEnvioStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleLugarEnvioStatus")
            .RequireAuthorization("LUGARESENVIO.UPDATE");
        }
    }
}