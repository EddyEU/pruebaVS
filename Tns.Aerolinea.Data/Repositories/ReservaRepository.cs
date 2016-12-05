namespace Tns.Aerolinea.Data.Repositories
{
    using Application.DTO.Reserva;
    using Domain.RepositoriesContracts;
    using Entities.AerolineaTnsModel;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReservaRepository : IReservaRepository
    {
        #region IReservaRepository Implementation

        /// <summary>
        /// Reservar Vuelo.
        /// </summary>
        /// <param name="reservaVuelo"></param>
        public void ReservarVuelo(Reserva reserva)
        {
            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                //Crear una reserva de un vuelo con los pasajeros especificados.
                context.Set<Reserva>().Add(reserva);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Consultar Reservas de un usuario por fecha.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<Reserva> ConsultarReservas(int idUsuario, DateTime fecha)
        {
            List<Reserva> reservas = null;

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                reservas = context.Reserva.Where(reserva => reserva.Vuelo.Fecha.Date == fecha.Date && reserva.IdUsuario == idUsuario).ToList();
            }

            return reservas;
        }

        /// <summary>
        /// Consultar Reservas de un usuario que estén activas, es decir que la fecha del vuela sea hoy o superior.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<ReservaDTO> ConsultarReservas(int idUsuario)
        {
            List<ReservaDTO> reservasUsuario = null;

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                var reservas = context.Reserva.Where(reserva => reserva.Vuelo.Fecha.Date >= DateTime.Today.Date && reserva.IdUsuario == idUsuario).ToList();

                reservasUsuario = reservas.Select(reserva => new ReservaDTO()
                {
                    Aerolinea = reserva.Vuelo.Aerolinea.Nombre,
                    CiudadDestino = reserva.Vuelo.Destino.Ciudad.NombreCiudad,
                    CiudadOrigen = reserva.Vuelo.Origen.Ciudad.NombreCiudad,
                    FechaReserva = reserva.FechaReserva,
                    FechaVuelo = reserva.Vuelo.Fecha,
                    HoraSalidaVuelo = reserva.Vuelo.Salida,
                    IdDestino = reserva.Vuelo.IdDestino,
                    IdOrigen = reserva.Vuelo.IdOrigen,
                    IdReserva = reserva.IdReserva,
                    IdUsuario = reserva.IdUsuario,
                    IdVuelo = reserva.IdVuelo,
                    Usuario = reserva.Usuario.Nombre.Trim() + reserva.Usuario.Apellido.Trim(),
                    ValorTotalReserva = reserva.ValorTotalReserva,
                    Pasajeros = reserva.TiquetePasajero.Select(tiquetePasajero => new PasajeroDTO()
                    {
                        Apellido = tiquetePasajero.Pasajero.Apellido,
                        Cedula = tiquetePasajero.Pasajero.Cedula,
                        Celular = tiquetePasajero.Pasajero.Celular,
                        Correo = tiquetePasajero.Pasajero.Correo,
                        Direccion = tiquetePasajero.Pasajero.Direccion,
                        IdPasajero = tiquetePasajero.IdPasajero,
                        Nombre = tiquetePasajero.Pasajero.Nombre,
                        Sexo = tiquetePasajero.Pasajero.Sexo,
                        Telefono = tiquetePasajero.Pasajero.Telefono
                    }).ToList()
                }).ToList();

                return reservasUsuario;
            }
        }

        #endregion IReservaRepository Implementation
    }
}