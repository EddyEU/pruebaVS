namespace Tns.Aerolinea.Application.Services.Tests
{
    using DI;
    using DTO.Login;
    using Entities.Filter;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            UsuarioDTO usuario = new UsuarioDTO();
            LoginFilter filtro = new LoginFilter();
            filtro.Login = "tns";
            filtro.Clave = "tnsclave";
            usuario = target.ValidarUsuario(filtro);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void RegistrarUsuarioTest()
        {
            LoginApplication target = new LoginApplication();

            LoginFilter filtro = new LoginFilter
            {
                Nombre = "David",
                Apellido = "Lopez",
                Cedula = "708743564",
                Login = "david",
                Clave = "davidclave"
            };

            target.RegistrarUsuario(filtro);
        }
    }
}