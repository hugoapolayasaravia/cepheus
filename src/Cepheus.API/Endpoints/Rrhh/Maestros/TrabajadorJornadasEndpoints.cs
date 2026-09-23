using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorJornadas.CreateTrabajadorJornada;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorJornadas.GetTrabajadorJornadasByTrabajador;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorJornadas.UpdateTrabajadorJornada;
using MediatR;

namespace Cepheus.API.Endpoints.Rrhh.Maestros
{
    public static class TrabajadorJornadasEndpoints
    {
        public static void MapTrabajadorJornadasEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/rrhh/maestros/trabajador-jornadas")
                .WithTags("TrabajadorJornada (RRHH)")
                .RequireAuthorization();

            group.MapPost("/trabajador/{trabajadorCode}", async (string trabajadorCode, CreateTrabajadorJornadaCommand bodyCommand, ISender sender) =>
            {
                var command = bodyCommand with { TrabajadorCode = trabajadorCode };
                var result = await sender.Send(command);
                return Results.Created($"/api/rrhh/maestros/trabajador-jornadas/trabajador/{trabajadorCode}", result);
            })
            .WithName("CreateTrabajadorJornada")
            .RequireAuthorization("TRABAJADORJORNADA.CREATE");

            group.MapGet("/trabajador/{trabajadorCode}", async (string trabajadorCode, ISender sender) =>
            {
                var result = await sender.Send(new GetTrabajadorJornadasByTrabajadorQuery(trabajadorCode));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetTrabajadorJornadaByTrabajador")
            .RequireAuthorization("TRABAJADORJORNADA.VIEW");

            group.MapPut("/{id:long}", async (long id, UpdateTrabajadorJornadaCommand bodyCommand, ISender sender) =>
            {
                if (id != bodyCommand.Id)
                {
                    return Results.BadRequest("El id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(bodyCommand);
                return Results.Ok(result);
            })
            .WithName("UpdateTrabajadorJornada")
            .RequireAuthorization("TRABAJADORJORNADA.UPDATE");
        }
    }
}
