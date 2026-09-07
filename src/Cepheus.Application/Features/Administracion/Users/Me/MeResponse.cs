namespace Cepheus.Application.Features.Administracion.Users.Me
{
    public class MeResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<string> Roles { get; set; } = new();

        // TODO: cuando se complete el patrón de Role/Permission/Modulo/Submodulo/Programa/Acceso,
        // acá se agrega el árbol completo de permisos (Modulo -> Submodulo -> Programa -> Acceso),
        // armado con una sola consulta proyectada. Deliberadamente NO va en el JWT (ver Authenticate).
    }

}
