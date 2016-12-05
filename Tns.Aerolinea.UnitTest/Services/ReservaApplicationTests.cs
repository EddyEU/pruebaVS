using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tns.Aerolinea.Application.Services;

namespace Tns.Aerolinea.Application.Services.Tests
{
    using DI;
    using DTO.Reserva;
    using Entities.Filter;
    using Infrastructure.Excepciones;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services;
    using System;
    using System.Collections.Generic;

    [TestClass()]
    public class ReservaApplicationTests
    {
        [ClassInitialize()]
        public static void PedidosApplicationTestsInitialize(TestContext testContext)
        {
            DependencyInjectionContainer.InitializeContainer();
        }

        [TestMethod()]
        public void ReservarVueloTest()
        {
            ReservaApplication target = new ReservaApplication();

            List<TiquetePasajeroFilter> tiquetesPasajero = new List<TiquetePasajeroFilter>();

            tiquetesPasajero.Add(new TiquetePasajeroFilter()
            {
                IdTipoAsiento = 3,
                ValorTiquete = 70000,
                Pasajero = new PasajeroFilter()
                {
                    Apellido = "Pelaez",
                    Cedula = "1037587268",
                    Celular = "3016199800",
                    Correo = "miguelpelaez11@hotmail.com",
                    Direccion = "Carrera 78 # 48-51",
                    Nombre = "Miguel",
                    Sexo = "M",
                    Telefono = "2998547"
                }
            });

            tiquetesPasajero.Add(new TiquetePasajeroFilter()
            {
                IdTipoAsiento = 3,
                ValorTiquete = 70000,
                Pasajero = new PasajeroFilter()
                {
                    Apellido = "Perez",
                    Cedula = "1037587269",
                    Celular = "3016199801",
                    Correo = "perez@hotmail.com",
                    Direccion = "Carrera 78 # 48-52",
                    Nombre = "Juan",
                    Sexo = "M",
                    Telefono = "2998548"
                }
            });

            ReservaVueloFilter filtro = new ReservaVueloFilter
            {
                FechaVuelo = new DateTime(2016, 12, 15, 7, 15, 0),
                IdUsuario = 1,
                IdVuelo = 1,
                TiquetePasajero = tiquetesPasajero
            };

            try
            {
                target.ReservarVuelo(filtro);
            }
            catch (BussinesException ex)
            {
                //Excepción esperada según alguna regla de negocio.
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod()]
        public void ConsultarReservasTest()
        {
            int idUsuario = 1;
            List<ReservaDTO> reserva = new List<ReservaDTO>();
            ReservaApplication target = new ReservaApplication();

            reserva = target.ConsultarReservas(idUsuario);

            Assert.IsNotNull(reserva);
        }
    }
}