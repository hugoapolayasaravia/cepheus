using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorLaborals.CreateTrabajadorLaboral;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorLaborals.GetTrabajadorLaboralsByTrabajador;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorLaborals.UpdateTrabajadorLaboral;
using MediatR;

namespace Cepheus.API.Endpoints.Rrhh.Maestros
{
    public static class TrabajadorLaboralsEndpoints
    {
        public static void MapTrabajadorLaboralsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/rrhh/maestros/trabajador-laborals")
                .WithTags("TrabajadorLaboral (RRHH)")
                .RequireAuthorization();

            group.MapPost("/trabajador/{trabajadorCode}", async (string trabajadorCode, CreateTrabajadorLaboralCommand bodyCommand, ISender sender) =>
            {
                var command = bodyCommand with { TrabajadorCode = trabajadorCode };
                var result = await sender.Send(command);
                return Results.Created($"/api/rrhh/maestros/trabajador-laborals/trabajador/{trabajadorCode}", result);
            })
            .WithName("CreateTrabajadorLaboral")
            .RequireAuthorization("TRABAJADORLABORAL.CREATE");

            group.MapGet("/trabajador/{trabajadorCode}", async (string trabajadorCode, ISender sender) =>
            {
                var result = await sender.Send(new GetTrabajadorLaboralsByTrabajadorQuery(trabajadorCode));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetTrabajadorLaboralByTrabajador")
            .RequireAuthorization("TRABAJADORLABORAL.VIEW");

            group.MapPut("/{id:long}", async (long id, UpdateTrabajadorLaboralCommand bodyCommand, ISender sender) =>
            {
                if (id != bodyCommand.Id)
                {
                    return Results.BadRequest("El id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(bodyCommand);
                return Results.Ok(result);
            })
            .WithName("UpdateTrabajadorLaboral")
            .RequireAuthorization("TRABAJADORLABORAL.UPDATE");
        }
    }
}
