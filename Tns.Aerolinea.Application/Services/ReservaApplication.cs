namespace Tns.Aerolinea.Application.Services
{
    using DI;
    using Domain.DomainContracts;
    using Domain.RepositoriesContracts;
    using DTO.Reserva;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using Infrastructure.Excepciones;
    using Infrastructure.Mensajes;
    using System.Collections.Generic;

    public class ReservaApplication
    {
        /// <summary>
        /// Reservar Vuelo.
        /// </summary>
        /// <param name="reservaVuelo"></param>
        public void ReservarVuelo(ReservaVueloFilter filtroReserva)
        {
            IReservaRepository reservaRepository = DependencyInjectionContainer.Resolve<IReservaRepository>();
            IReservaDomain reservaDomain = DependencyInjectionContainer.Resolve<IReservaDomain>();

            Reserva reserva = new Reserva();
            List<Reserva> reservasPrevias = new List<Reserva>();

            //Consultar Reservas previas del usuario.
            reservasPrevias = reservaRepository.ConsultarReservas(filtroReserva.IdUsuario, filtroReserva.FechaVuelo);

            //Validar datos del usuario y reservas previas.
            reserva = reservaDomain.ValidarReserva(filtroReserva, reservasPrevias);

            if (reserva != null)
                //Crear la reserva del vuelo
                reservaRepository.ReservarVuelo(reserva);
            else
                throw new BussinesException(Messages.ErrorReservaVuelo);
        }

        /// <summary>
        /// Consultar Reservas de un usuario que estén activas, es decir que la fecha del vuela sea hoy o superior.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<ReservaDTO> ConsultarReservas(int idUsuario)
        {
            IReservaRepository reservaRepository = DependencyInjectionContainer.Resolve<IReservaRepository>();
            return reservaRepository.ConsultarReservas(idUsuario);
        }
    }
}