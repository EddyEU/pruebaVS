namespace Tns.Aerolinea.Application.Services
{
    using DI;
    using Domain.DomainContracts;
    using Domain.RepositoriesContracts;
    using DTO.Login;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using Infrastructure.Excepciones;
    using Infrastructure.Mensajes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoginApplication
    {
        /// <summary>
        /// Validar usuario y clave de un cliente especifico.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UsuarioDTO ValidarUsuario(LoginFilter login)
        {
            ILoginRepository loginRepository = DependencyInjectionContainer.Resolve<ILoginRepository>();
            return loginRepository.ValidarUsuario(login);
        }

        /// <summary>
        /// Validar usuario y clave de un cliente especifico.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public void RegistrarUsuario(LoginFilter login)
        {
            ILoginRepository loginRepository = DependencyInjectionContainer.Resolve<ILoginRepository>();
            ILoginDomain loginDomain = DependencyInjectionContainer.Resolve<ILoginDomain>();

            Usuario usuario = new Usuario()
            {
                Apellido = login.Apellido,
                Cedula = login.Cedula,
                Clave = login.Clave,
                FechaCreacion = DateTime.Now,
                Login = login.Login,
                Nombre = login.Nombre
            };

            //Verificar si el usuario ya esta registrado.
            bool UsuarioRegistrado = loginDomain.ValidarUsuarioRegistrado(usuario.Cedula, loginRepository);

            //Registrar el usuario si no existe
            if (!UsuarioRegistrado)
                loginRepository.RegistrarUsuario(usuario);
            else
                throw new BussinesException(Messages.ErrorUsuarioRegistrado);
        }

        public List<UsuarioDTO> ConsultarUsuario()
        {
            ILoginRepository loginRepository = DependencyInjectionContainer.Resolve<ILoginRepository>();
            return loginRepository.ConsultarListaUsuarios();
        }
    }
}