using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorPensions.CreateTrabajadorPension;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorPensions.GetTrabajadorPensionsByTrabajador;
using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorPensions.UpdateTrabajadorPension;
using MediatR;

namespace Cepheus.API.Endpoints.Rrhh.Maestros
{
    public static class TrabajadorPensionsEndpoints
    {
        public static void MapTrabajadorPensionsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/rrhh/maestros/trabajador-pensions")
                .WithTags("TrabajadorPension (RRHH)")
                .RequireAuthorization();

            group.MapPost("/trabajador/{trabajadorCode}", async (string trabajadorCode, CreateTrabajadorPensionCommand bodyCommand, ISender sender) =>
            {
                var command = bodyCommand with { TrabajadorCode = trabajadorCode };
                var result = await sender.Send(command);
                return Results.Created($"/api/rrhh/maestros/trabajador-pensions/trabajador/{trabajadorCode}", result);
            })
            .WithName("CreateTrabajadorPension")
            .RequireAuthorization("TRABAJADORPENSION.CREATE");

            group.MapGet("/trabajador/{trabajadorCode}", async (string trabajadorCode, ISender sender) =>
            {
                var result = await sender.Send(new GetTrabajadorPensionsByTrabajadorQuery(trabajadorCode));
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetTrabajadorPensionByTrabajador")
            .RequireAuthorization("TRABAJADORPENSION.VIEW");

            group.MapPut("/{id:long}", async (long id, UpdateTrabajadorPensionCommand bodyCommand, ISender sender) =>
            {
                if (id != bodyCommand.Id)
                {
                    return Results.BadRequest("El id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(bodyCommand);
                return Results.Ok(result);
            })
            .WithName("UpdateTrabajadorPension")
            .RequireAuthorization("TRABAJADORPENSION.UPDATE");
        }
    }
}
