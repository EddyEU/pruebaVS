namespace Tns.Aerolinea.Domain.Services
{
    using Application.DTO.Reserva;
    using DomainContracts;
    using System.Collections.Generic;
    using System.Linq;

    public class VueloDomain : IVueloDomain
    {
        #region IVueloDomain Implementation

        /// <summary>
        /// Listado de vuelos con la prioridad en los horarios.
        /// </summary>
        /// <param name="vuelos"></param>
        /// <returns></returns>
        public List<VueloDTO> ConsultarVueloHorarios(List<VueloDTO> vuelos)
        {
            //No es necesario devolver información e las tarifas.
            vuelos.ForEach(item => item.Tarifas = null);
            //se ordena la lista de vuelos disponibles por el horario en forma ascendente.
            return vuelos.OrderBy(vuelo => vuelo.Fecha).ThenBy(vuelo => vuelo.Salida).ToList();
        }

        /// <summary>
        /// Listado de vuelos con la prioridad en las tarifas.
        /// </summary>
        /// <param name="vuelos"></param>
        /// <returns></returns>
        public List<VueloDTO> ConsultarVueloTarifas(List<VueloDTO> vuelos)
        {
            //Seleccionar la tarifa mas baja por cada vuelo
            List<TarifaDTO> tarifasBajas = new List<TarifaDTO>();
            vuelos.ForEach(vuelo =>
            {
                tarifasBajas.Add(vuelo.Tarifas.OrderBy(item => item.ValorTiquete).First());
            });

            //Determinar el orden de los IdVuelo según las tarifas mas bajas.
            List<long> idVuelos = tarifasBajas.OrderBy(tarifa => tarifa.ValorTiquete).Select(vuelo => vuelo.IdVuelo).ToList();

            //Se ordena los vuelos según la tarifa mas baja en el tipo de asiento mas económico.
            return (from idVuelo in idVuelos
                    join vuelo in vuelos
                        on idVuelo equals vuelo.IdVuelo
                    select vuelo).ToList();
        }

        #endregion IVueloDomain Implementation
    }
}