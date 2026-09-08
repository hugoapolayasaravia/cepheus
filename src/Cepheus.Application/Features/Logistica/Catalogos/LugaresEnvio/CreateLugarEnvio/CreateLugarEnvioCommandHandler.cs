using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.Common;
using Cepheus.Domain.Logistica.Catalogos;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.CreateLugarEnvio
{
    public class CreateLugarEnvioCommandHandler : IRequestHandler<CreateLugarEnvioCommand, LugarEnvioResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateLugarEnvioCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<LugarEnvioResponse> Handle(CreateLugarEnvioCommand request, CancellationToken cancellationToken)
        {
            var lugar = new LugarEnvio
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                Address = string.IsNullOrWhiteSpace(request.Address) ? null : request.Address.Trim(),
                IsActive = true
            };

            await _uow.LugaresEnvio.AddAsync(lugar, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(lugar);
        }

        internal static LugarEnvioResponse Map(LugarEnvio lugar) => new()
        {
            Code = lugar.Code,
            Name = lugar.Name,
            Address = lugar.Address,
            IsActive = lugar.IsActive,
            CreatedAt = lugar.CreatedAt,
            UpdatedAt = lugar.UpdatedAt,
            RowVersion = lugar.RowVersion
        };
    }
}