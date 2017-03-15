namespace Tns.Aerolinea.Application.ServicesQueryable
{
    using DI;
    using Domain.RepositoriesContracts;
    using DTO.Login;
    using System.Linq;

    public class UsuarioAplicationQueryable
    {
        /// <summary>
        /// Consulta queryable para UsuarioDTO
        /// </summary>
        /// <returns></returns>
        public IQueryable<UsuarioDTO> ConsultarUsuarios()
        {
            ILoginRepository loginRepository = DependencyInjectionContainer.Resolve<ILoginRepository>();
            return loginRepository.ConsultarUsuarios();
        }
    }
}