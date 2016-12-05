namespace Tns.Aerolinea.Domain.DomainContracts
{
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using System.Collections.Generic;

    public interface IReservaDomain
    {
        /// <summary>
        /// Validar los datos del usuario y reservas previas
        /// </summary>
        /// <param name="filtroReserva"></param>
        /// <param name="reservasPrevias"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Reserva ValidarReserva(ReservaVueloFilter filtroReserva, List<Reserva> reservasPrevias, Usuario usuario);
    }
}