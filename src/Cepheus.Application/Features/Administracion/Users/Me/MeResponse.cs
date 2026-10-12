namespace Cepheus.Application.Features.Administracion.Users.Me
{
    public class MeResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<string> Roles { get; set; } = new();

        /// <summary>
        /// Menú del usuario: Módulo -> Submódulo -> Programa. Solo incluye lo activo y los
        /// programas donde el usuario tiene el permiso VIEW. Deliberadamente NO va en el JWT
        /// (ver Authenticate): se calcula en cada consulta, así los cambios de permisos se
        /// reflejan de inmediato.
        /// </summary>
        public List<MenuModuloResponse> Menu { get; set; } = new();

        /// <summary>
        /// Lista plana de permisos con el mismo formato de las políticas de los endpoints,
        /// por ejemplo "USERS.VIEW" o "ROLES.UPDATE".
        /// </summary>
        public List<string> Permissions { get; set; } = new();
    }
}
