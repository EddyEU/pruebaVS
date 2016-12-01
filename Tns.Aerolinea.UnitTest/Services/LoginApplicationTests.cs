using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tns.Aerolinea.Application.DI;
using Tns.Aerolinea.Application.Services;
using Tns.Aerolinea.Entities.AerolineaTnsModel;
using Tns.Aerolinea.Entities.Filter;

namespace Tns.Aerolinea.Application.Services.Tests
{
    [TestClass()]
    public class LoginApplicationTests
    {
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void PedidosApplicationTestsInitialize(TestContext testContext)
        {
            DependencyInjectionContainer.InitializeContainer();
        }

        [TestMethod()]
        public void ValidarUsuarioTest()
        {
            LoginApplication target = new LoginApplication();
            Usuario usuario = new Usuario();
            LoginFilter filtro = new LoginFilter();
            filtro.Login = "tns";
            filtro.Clave = "tnsclave";
            usuario = target.ValidarUsuario(filtro);
            Assert.IsNotNull(usuario);
        }
    }
}