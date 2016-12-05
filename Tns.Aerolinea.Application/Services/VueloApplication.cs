namespace Tns.Aerolinea.Application.Services
{
    using DI;
    using Domain.DomainContracts;
    using Domain.RepositoriesContracts;
    using DTO.Reserva;
    using Entities.Filter;
    using System.Collections.Generic;

    public class VueloApplication
    {
        /// <summary>
        /// Consulta de vuelos entre dos ciudades incluyendo la información de los horarios.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<VueloDTO> ConsultarVueloHorarios(VueloCiudadFilter filtro)
        {
            IVueloRepository vueloRepository = DependencyInjectionContainer.Resolve<IVueloRepository>();
            IVueloDomain vueloDomain = DependencyInjectionContainer.Resolve<IVueloDomain>();

            return vueloDomain.ConsultarVueloHorarios(vueloRepository.ConsultarVuelo(filtro));
        }

        /// <summary>
        /// Consulta de vuelos entre dos ciudades con prioridad en las tarifas
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<VueloDTO> ConsultarVueloTarifas(VueloCiudadFilter filtro)
        {
            IVueloRepository vueloRepository = DependencyInjectionContainer.Resolve<IVueloRepository>();
            IVueloDomain vueloDomain = DependencyInjectionContainer.Resolve<IVueloDomain>();

            return vueloDomain.ConsultarVueloTarifas(vueloRepository.ConsultarVuelo(filtro));
        }

        /// <summary>
        /// Consultar estados de los vuelos y la disponibilidad de asientos.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<EstadoVueloDTO> ConsultarEstadosVuelos(VueloCiudadFilter filtro)
        {
            IVueloRepository vueloRepository = DependencyInjectionContainer.Resolve<IVueloRepository>();
            return vueloRepository.ConsultarEstadosVuelo(filtro);
        }
    }
}