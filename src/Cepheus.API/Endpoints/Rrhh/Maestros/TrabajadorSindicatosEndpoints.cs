using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSindicatos.CreateTrabajadorSindicato;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSindicatos.GetTrabajadorSindicatosByTrabajador;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSindicatos.UpdateTrabajadorSindicato;
using MediatR;

namespace Cepheus.API.Endpoints.Rrhh.Maestros
{
    public static class TrabajadorSindicatosEndpoints
    {
        public static void MapTrabajadorSindicatosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/rrhh/maestros/trabajador-sindicatos")
                .WithTags("TrabajadorSindicato (RRHH)")
                .RequireAuthorization();

            group.MapPost("/trabajador/{trabajadorCode}", async (string trabajadorCode, CreateTrabajadorSindicatoCommand bodyCommand, ISender sender) =>
            {
                var command = bodyCommand with { TrabajadorCode = trabajadorCode };
                var result = await sender.Send(command);
                return Results.Created($"/api/rrhh/maestros/trabajador-sindicatos/trabajador/{trabajadorCode}", result);
            })
            .WithName("CreateTrabajadorSindicato")
            .RequireAuthorization("TRABAJADORSINDICATO.CREATE");

            group.MapGet("/trabajador/{trabajadorCode}", async (string trabajadorCode, ISender sender) =>
            {
                var result = await sender.Send(new GetTrabajadorSindicatosByTrabajadorQuery(trabajadorCode));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetTrabajadorSindicatoByTrabajador")
            .RequireAuthorization("TRABAJADORSINDICATO.VIEW");

            group.MapPut("/{id:long}", async (long id, UpdateTrabajadorSindicatoCommand bodyCommand, ISender sender) =>
            {
                if (id != bodyCommand.Id)
                {
                    return Results.BadRequest("El id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(bodyCommand);
                return Results.Ok(result);
            })
            .WithName("UpdateTrabajadorSindicato")
            .RequireAuthorization("TRABAJADORSINDICATO.UPDATE");
        }
    }
}
