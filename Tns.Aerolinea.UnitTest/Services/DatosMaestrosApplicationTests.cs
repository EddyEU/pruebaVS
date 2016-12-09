namespace Tns.Aerolinea.Application.Services.Tests
{
    using DI;
    using DTO.DatosMaestros;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Tns.Aerolinea.Application.Services;

    [TestClass()]
    public class DatosMaestrosApplicationTests
    {
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void PedidosApplicationTestsInitialize(TestContext testContext)
        {
            DependencyInjectionContainer.InitializeContainer();
        }

        [TestMethod()]
        public void ConsultarDestinosTest()
        {
            DatosMaestrosApplication target = new DatosMaestrosApplication();
            List<CiudadDestinoDTO> ciudades = new List<CiudadDestinoDTO>();
            ciudades = target.ConsultarDestinos();
            Assert.IsNotNull(ciudades);
        }

        [TestMethod()]
        public void ConsultarOrigenesTest()
        {
            DatosMaestrosApplication target = new DatosMaestrosApplication();
            List<CiudadOrigenDTO> ciudades = new List<CiudadOrigenDTO>();
            ciudades = target.ConsultarOrigenes();
            Assert.IsNotNull(ciudades);
        }
    }
}