namespace Tns.Aerolinea.Domain.DomainContracts
{
    using Application.DTO.Reserva;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVueloDomain
    {
        /// <summary>
        /// Listado de vuelos con la prioridad en los horarios.
        /// </summary>
        /// <param name="vuelos"></param>
        /// <returns></returns>
        List<VueloDTO> ConsultarVueloHorarios(List<VueloDTO> vuelos);

        /// <summary>
        /// Listado de vuelos con la prioridad en las tarifas.
        /// </summary>
        /// <param name="vuelos"></param>
        /// <returns></returns>
        List<VueloDTO> ConsultarVueloTarifas(List<VueloDTO> vuelos);
    }
}