namespace Tns.Aerolinea.Domain.RepositoriesContracts
{
    using Application.DTO.Reserva;
    using Entities.Filter;
    using System.Collections.Generic;

    public interface IVueloRepository
    {
        /// <summary>
        /// Consulta de vuelos entre dos ciudades incluyendo la información de los horarios.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        List<VueloDTO> ConsultarVuelo(VueloCiudadFilter filtro);

        /// <summary>
        /// Consultar el estados de los vuelos entre dos ciudades.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        List<EstadoVueloDTO> ConsultarEstadosVuelo(VueloCiudadFilter filtro);
    }
}