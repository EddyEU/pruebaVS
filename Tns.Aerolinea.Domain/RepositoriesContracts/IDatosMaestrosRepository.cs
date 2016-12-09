namespace Tns.Aerolinea.Domain.DomainContracts
{
    using Application.DTO.DatosMaestros;
    using System.Collections.Generic;

    public interface IDatosMaestrosRepository
    {
        /// <summary>
        /// Obtener el listado de orígenes de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        List<CiudadOrigenDTO> ConsultarOrigenes();

        /// <summary>
        /// Obtener el listado de destinos de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        List<CiudadDestinoDTO> ConsultarDestinos();
    }
}