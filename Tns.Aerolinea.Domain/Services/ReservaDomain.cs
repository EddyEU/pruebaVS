namespace Tns.Aerolinea.Domain.Services
{
    using DomainContracts;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using Infrastructure.Excepciones;
    using Infrastructure.Mensajes;
    using Infrastructure.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReservaDomain : IReservaDomain
    {
        #region IReservaDomain Implementation

        /// <summary>
        /// Validar datos del usuario y reservas previas.
        /// </summary>
        /// <param name="filtroReserva"></param>
        /// <param name="reservasPrevias"></param>
        /// <returns></returns>
        public Reserva ValidarReserva(ReservaVueloFilter filtroReserva, List<Reserva> reservasPrevias, Usuario usuario)
        {
            //Validar que el usuario sea mayor de edad
            if ((DateTime.Today.Year - usuario.FechaNacimiento.Year) < int.Parse(ConfigurationKeys.GetKeyAppSettings("EdadMayorEdad")))
                throw new BussinesException(Messages.ErrorUsuarioMenorEdad);

            //Validar que el usuario no tenga un vuelo previamente reservado para el mismo día.
            if (reservasPrevias.Count > 0)
                throw new BussinesException(Messages.ErrorReservasPrevias);

            //Si supera todas las validaciones se crea la reserva.
            return CrearReserva(filtroReserva);
        }

        #endregion IReservaDomain Implementation

        #region Private Methods

        /// <summary>
        /// Crear objeto Reserva con los datos requeridos para su creación en la base de datos.
        /// </summary>
        /// <param name="filtroReserva"></param>
        private Reserva CrearReserva(ReservaVueloFilter filtroReserva)
        {
            Reserva reserva = new Reserva()
            {
                FechaReserva = DateTime.Now,
                IdUsuario = filtroReserva.IdUsuario,
                IdVuelo = filtroReserva.IdVuelo,
                ValorTotalReserva = filtroReserva.TiquetePasajero.Sum(item => item.ValorTiquete),
                TiquetePasajero = filtroReserva.TiquetePasajero
                                    .Select(tiquete => new TiquetePasajero()
                                    {
                                        IdTipoAsiento = tiquete.IdTipoAsiento,
                                        ValorTiquete = tiquete.ValorTiquete,
                                        Pasajero = new Pasajero()
                                        {
                                            Apellido = tiquete.Pasajero.Apellido,
                                            Cedula = tiquete.Pasajero.Cedula,
                                            Celular = tiquete.Pasajero.Celular,
                                            Correo = tiquete.Pasajero.Correo,
                                            Direccion = tiquete.Pasajero.Direccion,
                                            Nombre = tiquete.Pasajero.Nombre,
                                            Sexo = tiquete.Pasajero.Sexo,
                                            Telefono = tiquete.Pasajero.Telefono,
                                        }
                                    }).ToList()
            };

            return reserva;
        }

        #endregion Private Methods
    }
}