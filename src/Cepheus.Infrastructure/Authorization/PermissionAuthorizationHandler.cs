using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Cepheus.Infrastructure.Authorization
{
    /// <summary>
    /// Valida un PermissionRequirement contra la cadena
    /// User -> UserRoles -> Role -> PermissionRoles -> Permission -> Programa,
    /// chequeando que el Role, el Permission y el propio User estén activos.
    /// Se ejecuta en cada request que tenga un .RequireAuthorization("X.Y") — es
    /// una query liviana (un solo roundtrip), no cachea nada a propósito: los
    /// cambios de permisos deben reflejarse de inmediato, sin esperar a que
    /// expire el JWT.
    /// </summary>
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly ApplicationDbContext _context;

        public PermissionAuthorizationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userIdValue = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdValue, out var userId))
            {
                return; // no autenticado / claim inválido -> no Succeed (falla)
            }

            var hasPermission = await _context.Users
                .Where(u => u.Id == userId && u.IsActive)
                .SelectMany(u => u.UserRoles)
                .Where(ur => ur.Role.IsActive)
                .SelectMany(ur => ur.Role.PermissionRoles)
                .AnyAsync(pr =>
                    pr.Permission.IsActive &&
                    pr.Permission.Programa.Code == requirement.ProgramaCode &&
                    pr.Permission.Code == requirement.PermissionCode);

            if (hasPermission)
            {
                context.Succeed(requirement);
            }
        }
    }

}
