using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSaluds.CreateTrabajadorSalud;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSaluds.GetTrabajadorSaludsByTrabajador;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSaluds.UpdateTrabajadorSalud;
using MediatR;

namespace Cepheus.API.Endpoints.Rrhh.Maestros
{
    public static class TrabajadorSaludsEndpoints
    {
        public static void MapTrabajadorSaludsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/rrhh/maestros/trabajador-saluds")
                .WithTags("TrabajadorSalud (RRHH)")
                .RequireAuthorization();

            group.MapPost("/trabajador/{trabajadorCode}", async (string trabajadorCode, CreateTrabajadorSaludCommand bodyCommand, ISender sender) =>
            {
                var command = bodyCommand with { TrabajadorCode = trabajadorCode };
                var result = await sender.Send(command);
                return Results.Created($"/api/rrhh/maestros/trabajador-saluds/trabajador/{trabajadorCode}", result);
            })
            .WithName("CreateTrabajadorSalud")
            .RequireAuthorization("TRABAJADORSALUD.CREATE");

            group.MapGet("/trabajador/{trabajadorCode}", async (string trabajadorCode, ISender sender) =>
            {
                var result = await sender.Send(new GetTrabajadorSaludsByTrabajadorQuery(trabajadorCode));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetTrabajadorSaludByTrabajador")
            .RequireAuthorization("TRABAJADORSALUD.VIEW");

            group.MapPut("/{id:long}", async (long id, UpdateTrabajadorSaludCommand bodyCommand, ISender sender) =>
            {
                if (id != bodyCommand.Id)
                {
                    return Results.BadRequest("El id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(bodyCommand);
                return Results.Ok(result);
            })
            .WithName("UpdateTrabajadorSalud")
            .RequireAuthorization("TRABAJADORSALUD.UPDATE");
        }
    }
}
