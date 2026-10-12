using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;
using Cepheus.Application.Features.Logistica.Transacciones.CierreMensual.Common;
using Cepheus.Infrastructure.Authorization;
using Cepheus.Infrastructure.Identity;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Cepheus.Infrastructure.Persistence.UnitOfWorks;
using Cepheus.Infrastructure.Services;
using Cepheus.Infrastructure.Services.StockArticulos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JwtTokenService = Cepheus.Infrastructure.Identity.JwtTokenService;

namespace Cepheus.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IPasswordHasher, PasswordHasherService>();

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            services.Configure<EmailSettings>(configuration.GetSection("Email"));
            services.AddScoped<IEmailSender, SmtpEmailSender>();

            services.Configure<PasswordResetSettings>(configuration.GetSection("PasswordReset"));
            services.AddScoped<IPasswordResetSettings>(sp => sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<PasswordResetSettings>>().Value);

            // Autorización dinámica por Permission/permisos_roles (ver Cepheus.Infrastructure.Authorization)
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<IArticuloStockMovementService, ArticuloStockMovementService>();

            // Revaluadores del cierre mensual: uno por tipo de documento de salida.
            // Al migrar Vales de Salida y Ajustes de Inventario, agregar aquí su ICierreRevaluador.
            services.AddScoped<ICierreRevaluador, OrdenServicioSalidaRevaluador>();


            return services;
        }
    }




}
