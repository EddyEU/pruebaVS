namespace Tns.Aerolinea.Domain.Services
{
    using DomainContracts;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReservaDomain : IReservaDomain
    {
        #region IReservaDomain Implementation

        /// <summary>
        /// Validar datos del usuario y reservas previas.
        /// </summary>
        /// <param name="filtroReserva"></param>
        /// <param name="reservasPrevias"></param>
        /// <returns></returns>
        public Reserva ValidarReserva(ReservaVueloFilter filtroReserva, List<Reserva> reservasPrevias)
        {
            //TODO: Validar que el usuario sea mayor de edad y que no tenga un vuelo previamente reservado para el mismo día.
            throw new NotImplementedException();
        }

        #endregion IReservaDomain Implementation
    }
}