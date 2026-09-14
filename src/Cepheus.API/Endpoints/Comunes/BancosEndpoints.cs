using Cepheus.Application.Features.Comunes.Bancos.CreateBanco;
using Cepheus.Application.Features.Comunes.Bancos.GetBancoByCode;
using Cepheus.Application.Features.Comunes.Bancos.GetBancosPaginated;
using Cepheus.Application.Features.Comunes.Bancos.ToggleBancoStatus;
using Cepheus.Application.Features.Comunes.Bancos.UpdateBanco;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class BancosEndpoints
    {
        public static void MapBancosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/bancos")
                .WithTags("Bancos (Comunes)")
                .RequireAuthorization();

            group.MapPost("/", async (CreateBancoCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/bancos/{result.Code}", result);
            })
            .WithName("CreateBanco")
            .RequireAuthorization("BANCOS.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetBancosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetBancosPagedQueryString")
            .RequireAuthorization("BANCOS.VIEW");

            group.MapPost("/paged/body", async (
                GetBancosPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetBancosPagedBody")
            .RequireAuthorization("BANCOS.VIEW");

            group.MapGet("/{codigo}", async (string codigo, ISender sender) =>
            {
                var result = await sender.Send(new GetBancoByCodeQuery(codigo));
                return Results.Ok(result);
            })
            .WithName("GetBancoByCode")
            .RequireAuthorization("BANCOS.VIEW");

            group.MapPut("/{codigo}", async (string codigo, UpdateBancoCommand command, ISender sender) =>
            {
                if (!string.Equals(codigo, command.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("El código de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateBanco")
            .RequireAuthorization("BANCOS.UPDATE");

            group.MapPatch("/{codigo}/toggle-status", async (string codigo, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleBancoStatusCommand(codigo));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleBancoStatus")
            .RequireAuthorization("BANCOS.UPDATE");
        }
    }
}
