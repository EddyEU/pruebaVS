namespace Tns.Aerolinea.Domain.RepositoriesContracts
{
    using Application.DTO.Reserva;
    using Entities.AerolineaTnsModel;
    using System;
    using System.Collections.Generic;

    public interface IReservaRepository
    {
        /// <summary>
        /// Reservar Vuelo.
        /// </summary>
        /// <param name="reservaVuelo"></param>
        void ReservarVuelo(Reserva reserva);

        /// <summary>
        /// Consultar Reservas de un usuario por fecha.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        List<Reserva> ConsultarReservas(int idUsuario, DateTime fecha);

        /// <summary>
        /// Consultar Reservas de un usuario que estén activas, es decir que la fecha del vuela sea hoy o superior.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        List<ReservaDTO> ConsultarReservas(int idUsuario);
    }
}