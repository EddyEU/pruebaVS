namespace Tns.Aerolinea.Domain.RepositoriesContracts
{
    using Entities.AerolineaTnsModel;
    using Entities.Filter;

    public interface ILoginRepository
    {
        Usuario ValidarUsuario(LoginFilter login);
    }
}