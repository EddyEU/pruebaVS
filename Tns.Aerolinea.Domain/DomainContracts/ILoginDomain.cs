namespace Tns.Aerolinea.Domain.DomainContracts
{
    using Entities.AerolineaTnsModel;
    using RepositoriesContracts;

    public interface ILoginDomain
    {
        /// <summary>
        /// Registrar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        bool ValidarUsuarioRegistrado(string cedula, ILoginRepository loginRepository);
    }
}