using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tns.Aerolinea.Application.DI;
using Tns.Aerolinea.Application.DTO.Reserva;
using Tns.Aerolinea.Application.Services;
using Tns.Aerolinea.Entities.Filter;

namespace Tns.Aerolinea.Application.Services.Tests
{
    [TestClass()]
    public class VueloApplicationTests
    {
        [ClassInitialize()]
        public static void PedidosApplicationTestsInitialize(TestContext testContext)
        {
            DependencyInjectionContainer.InitializeContainer();
        }

        [TestMethod()]
        public void ConsultarVueloHorariosTest()
        {
            VueloApplication target = new VueloApplication();
            List<VueloDTO> vuelos = new List<VueloDTO>();
            VueloCiudadFilter filtro = new VueloCiudadFilter();
            filtro.IdOrigen = 6;
            filtro.IdDestino = 9;
            vuelos = target.ConsultarVueloHorarios(filtro);
            Assert.IsNotNull(vuelos);
        }

        [TestMethod()]
        public void ConsultarVueloTarifasTest()
        {
            VueloApplication target = new VueloApplication();
            List<VueloDTO> vuelos = new List<VueloDTO>();
            VueloCiudadFilter filtro = new VueloCiudadFilter();
            filtro.IdOrigen = 6;
            filtro.IdDestino = 9;
            vuelos = target.ConsultarVueloTarifas(filtro);
            Assert.IsNotNull(vuelos);
        }

        [TestMethod()]
        public void ConsultarEstadosVuelosTest()
        {
            VueloApplication target = new VueloApplication();
            List<EstadoVueloDTO> vuelos = new List<EstadoVueloDTO>();
            VueloCiudadFilter filtro = new VueloCiudadFilter();
            filtro.IdOrigen = 6;
            filtro.IdDestino = 9;
            vuelos = target.ConsultarEstadosVuelos(filtro);
            Assert.IsNotNull(vuelos);
        }
    }
}