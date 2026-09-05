using Cepheus.API.Endpoints.Administracion;
using Cepheus.API.Middleware;
using Cepheus.Infrastructure;
using Cepheus.Infrastructure.Persistence;
using Cepheus.Infrastructure.Persistence.Seed;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicyName = "CepheusCorsPolicy";
const string AuthRateLimiterPolicyName = "AuthRateLimiter";

builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(Cepheus.Application.AssemblyReference).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(Cepheus.Application.AssemblyReference).Assembly);

builder.Services.AddTransient(
    typeof(MediatR.IPipelineBehavior<,>),
    typeof(Cepheus.Application.Comun.Behaviors.ValidationBehavior<,>));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwt = builder.Configuration.GetSection("Jwt");
        var secretKey = jwt["SecretKey"];

        // Falla rápido y ruidoso en vez de arrancar silenciosamente con una
        // clave vacía o un placeholder conocido (que sería tan inseguro como
        // no tener autenticación). Mejor un 500 al arrancar que un JWT
        // forjable por cualquiera que haya visto el repo alguna vez.
        if (string.IsNullOrWhiteSpace(secretKey) || secretKey.Contains("CAMBIAR", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "Jwt:SecretKey no está configurado. En Development, corré " +
                "'dotnet user-secrets set \"Jwt:SecretKey\" \"<clave-real>\"' desde Cepheus.API. " +
                "En Production, configurá la variable de entorno Jwt__SecretKey.");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddAuthorization();

// CORS: orígenes permitidos vienen de appsettings (Cors:AllowedOrigins), NO
// hardcodeados acá. Así Development/Production pueden tener listas distintas
// sin tocar código (appsettings.Development.json vs appsettings.Production.json).
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        var allowedOrigins = builder.Configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>() ?? Array.Empty<string>();

        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Solo necesario si el frontend usa cookies; con JWT en header no es obligatorio, pero no molesta.
    });
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.UnmappedMemberHandling =
        System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow;
});

// Rate limiting: solo en login/register (los puntos de entrada sin auth previa,
// blanco típico de fuerza bruta). Se limita por IP, no globalmente — así un
// atacante no puede agotar la cuota de todos los usuarios legítimos.
// 5 intentos cada 1 minuto, sin cola de espera (el que se pasa, espera al
// siguiente minuto; no se le hace "esperar su turno").
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.ContentType = "application/problem+json";

        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = StatusCodes.Status429TooManyRequests,
            Title = "Demasiados intentos",
            Detail = "Se superó el límite de intentos permitidos. Intente nuevamente en un minuto.",
            Instance = context.HttpContext.Request.Path,
            Type = "https://httpstatuses.com/429"
        };

        await context.HttpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    };

    options.AddPolicy(AuthRateLimiterPolicyName, httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            }));
});

var app = builder.Build();

// Seed del árbol de Administración (Modulo "ADMIN" -> Submodulo "SEG" ->
// Programas USERS/ROLES/MODULOS/SUBMODULOS/PROGRAMAS/PERMISSIONS, con su
// CRUD estándar) + sincronización del rol Administrador con todo lo sembrado.
// Idempotente: se puede correr en cada arranque sin duplicar nada.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await AdministracionSeeder.SeedAsync(dbContext);
}

app.UseExceptionHandling();
app.UseSecurityHeaders();

// HSTS solo fuera de Development: en local, con el certificado autofirmado
// de HTTPS de desarrollo, HSTS genera más problemas (el navegador "recuerda"
// forzar HTTPS incluso si después volvés a HTTP en otro proyecto local) que
// beneficios. En Production, sobre un dominio real con certificado válido,
// sí corresponde.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(CorsPolicyName);
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();

app.MapAuthEndpoints();
app.MapUsersEndpoints();
app.MapRolesEndpoints();
app.MapModulosEndpoints();
app.MapSubmodulosEndpoints();
app.MapProgramasEndpoints();
app.MapPermissionsEndpoints();

app.Run();

