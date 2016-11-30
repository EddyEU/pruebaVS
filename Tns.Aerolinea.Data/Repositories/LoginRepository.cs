namespace Tns.Aerolinea.Data.Repositories
{
    using Domain.RepositoriesContracts;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoginRepository : ILoginRepository
    {
        public Usuario ValidarUsuario(LoginFilter login)
        {
            var usuarioValido = new Usuario();

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                usuarioValido = context.Set<Usuario>()
                    .Where(usuario => usuario.Login == login.Login
                         && usuario.Clave == login.Clave).FirstOrDefault();
            }

            return usuarioValido;
        }
    }
}