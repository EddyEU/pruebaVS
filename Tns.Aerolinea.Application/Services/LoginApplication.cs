namespace Tns.Aerolinea.Application.Services
{
    using DI;
    using Domain.RepositoriesContracts;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoginApplication
    {
        /// <summary>
        /// Validar usuario y clave de un cliente especifico.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Usuario ValidarUsuario(LoginFilter login)
        {
            ILoginRepository loginRepository = DependencyInjectionContainer.Resolve<ILoginRepository>();
            return loginRepository.ValidarUsuario(login);
        }
    }
}