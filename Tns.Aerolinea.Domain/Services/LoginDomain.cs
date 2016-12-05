namespace Tns.Aerolinea.Domain.Services
{
    using DomainContracts;
    using Entities.AerolineaTnsModel;
    using RepositoriesContracts;

    public class LoginDomain : ILoginDomain
    {
        #region ILoginDomain Implementation

        /// <summary>
        /// validar si un usuario esta registrado.
        /// </summary>
        /// <param name="usuario"></param>
        public bool ValidarUsuarioRegistrado(string cedula, ILoginRepository loginRepository)
        {
            //Validar que el usuario no este registrado.
            Usuario usuarioRegistrado = loginRepository.ConsultarUsuario(cedula);

            return usuarioRegistrado != null;
        }

        #endregion ILoginDomain Implementation
    }
}