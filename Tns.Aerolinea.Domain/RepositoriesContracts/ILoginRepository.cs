namespace Tns.Aerolinea.Domain.RepositoriesContracts
{
    using Application.DTO.Login;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;

    public interface ILoginRepository
    {
        /// <summary>
        /// Validar usuario y clave de un cliente especifico.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        UsuarioDTO ValidarUsuario(LoginFilter filtro);

        /// <summary>
        /// Consultar usuario por cedula.
        /// </summary>
        /// <returns></returns>
        Usuario ConsultarUsuario(string cedula);

        /// <summary>
        /// Registrar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        void RegistrarUsuario(Usuario usuario);
    }
}