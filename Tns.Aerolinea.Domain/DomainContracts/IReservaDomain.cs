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
        /// <returns></returns>
        Reserva ValidarReserva(ReservaVueloFilter filtroReserva, List<Reserva> reservasPrevias);
    }
}