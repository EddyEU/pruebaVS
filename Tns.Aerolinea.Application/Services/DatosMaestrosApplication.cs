namespace Tns.Aerolinea.Application.Services
{
    using DI;
    using Domain.DomainContracts;
    using DTO.DatosMaestros;
    using System.Collections.Generic;

    public class DatosMaestrosApplication
    {
        /// <summary>
        /// Obtener el listado de destinos de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        public List<CiudadDestinoDTO> ConsultarDestinos()
        {
            IDatosMaestrosRepository datosMaestrosRepository = DependencyInjectionContainer.Resolve<IDatosMaestrosRepository>();
            return datosMaestrosRepository.ConsultarDestinos();
        }

        /// <summary>
        /// Obtener el listado de orígenes de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        public List<CiudadOrigenDTO> ConsultarOrigenes()
        {
            IDatosMaestrosRepository datosMaestrosRepository = DependencyInjectionContainer.Resolve<IDatosMaestrosRepository>();
            return datosMaestrosRepository.ConsultarOrigenes();
        }
    }
}