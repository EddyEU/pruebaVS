namespace Tns.Aerolinea.Data.Repositories
{
    using Application.DTO.Login;
    using Domain.RepositoriesContracts;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using Model;
    using System.Linq;

    public class LoginRepository : ILoginRepository
    {
        #region ILoginRepository Implementation

        /// <summary>
        /// Validar usuario y clave de un cliente especifico.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UsuarioDTO ValidarUsuario(LoginFilter filtro)
        {
            var usuarioValido = new UsuarioDTO();

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                var usuario = context.Set<Usuario>()
                    .Where(item => item.Login == filtro.Login
                         && item.Clave == filtro.Clave);

                usuarioValido = usuario.Select(usuarioDto => new UsuarioDTO()
                {
                    Apellido = usuarioDto.Apellido,
                    Cedula = usuarioDto.Cedula,
                    IdUsuario = usuarioDto.IdUsuario,
                    Login = usuarioDto.Login,
                    Nombre = usuarioDto.Nombre,
                    FechaNacimiento = usuarioDto.FechaNacimiento
                }).FirstOrDefault();
            }

            return usuarioValido;
        }

        /// <summary>
        /// Consultar usuario por cedula.
        /// </summary>
        /// <returns></returns>
        public Usuario ConsultarUsuario(string cedula)
        {
            Usuario usuarioValido = null;

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                usuarioValido = context.Set<Usuario>()
                    .Where(usuario => usuario.Cedula.Trim().ToUpper() == cedula.Trim().ToUpper()).FirstOrDefault();
            }

            return usuarioValido;
        }

        /// <summary>
        /// Consultar usuario por id.
        /// </summary>
        /// <returns></returns>
        public Usuario ConsultarUsuario(int idUsuario)
        {
            Usuario usuarioValido = null;

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                usuarioValido = context.Set<Usuario>()
                    .Where(usuario => usuario.IdUsuario == idUsuario).FirstOrDefault();
            }

            return usuarioValido;
        }

        /// <summary>
        /// Registrar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        public void RegistrarUsuario(Usuario usuario)
        {
            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                context.Set<Usuario>().Add(usuario);
                context.SaveChanges();
            }
        }

        #endregion ILoginRepository Implementation
    }
}