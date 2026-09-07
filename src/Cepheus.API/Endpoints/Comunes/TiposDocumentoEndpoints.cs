using Cepheus.Application.Features.Comunes.TiposDocumento.CreateTipoDocumento;
using Cepheus.Application.Features.Comunes.TiposDocumento.GetTipoDocumentoById;
using Cepheus.Application.Features.Comunes.TiposDocumento.GetTiposDocumentoPaginated;
using Cepheus.Application.Features.Comunes.TiposDocumento.ToggleTipoDocumentoStatus;
using Cepheus.Application.Features.Comunes.TiposDocumento.UpdateTipoDocumento;
using MediatR;

namespace Cepheus.API.Endpoints.Comunes
{
    public static class TiposDocumentoEndpoints
    {
        public static void MapTiposDocumentoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/comunes/tipos-documento")
                .WithTags("TiposDocumento")
                .RequireAuthorization();

            group.MapPost("/", async (CreateTipoDocumentoCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Created($"/api/comunes/tipos-documento/{result.Id}", result);
            })
            .WithName("CreateTipoDocumento")
            .RequireAuthorization("TIPOSDOCUMENTO.CREATE");

            group.MapGet("/paged", async (
                [AsParameters] GetTiposDocumentoPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetTiposDocumentoPagedQueryString")
            .RequireAuthorization("TIPOSDOCUMENTO.VIEW");

            group.MapPost("/paged/body", async (
                GetTiposDocumentoPaginatedQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetTiposDocumentoPagedBody")
            .RequireAuthorization("TIPOSDOCUMENTO.VIEW");

            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetTipoDocumentoByIdQuery(id));
                return Results.Ok(result);
            })
            .WithName("GetTipoDocumentoById")
            .RequireAuthorization("TIPOSDOCUMENTO.VIEW");

            group.MapPut("/{id:int}", async (int id, UpdateTipoDocumentoCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("El Id de la ruta no coincide con el del cuerpo.");
                }

                var result = await sender.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateTipoDocumento")
            .RequireAuthorization("TIPOSDOCUMENTO.UPDATE");

            group.MapPatch("/{id:int}/toggle-status", async (int id, ISender sender) =>
            {
                var isActive = await sender.Send(new ToggleTipoDocumentoStatusCommand(id));
                return Results.Ok(new { IsActive = isActive });
            })
            .WithName("ToggleTipoDocumentoStatus")
            .RequireAuthorization("TIPOSDOCUMENTO.UPDATE");
        }
    }
}
