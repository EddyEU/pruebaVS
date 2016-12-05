namespace Tns.Aerolinea.WebApi.Controllers
{
    using Application.DTO.Reserva;
    using Application.Services;
    using Entities.Filter;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]/[action]")]
    public class VueloController : Controller
    {
        #region Constants

        private const string BadRequestError = "Todos los parámetros de entrada están nulos o vacíos.";
        private const string NotFoundError = "No se ha encontrado un resultado para la consulta especificada.";
        private const string InternalServerErrorConsultarVuelo = "Error al consultar los vuelos disponibles.";
        private const string InternalServerErrorConsultarEstadosVuelo = "Error al consultar el estado de los vuelos disponibles.";

        #endregion Constants

        #region Private Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion Private Fields

        #region Methods

        /// <summary>
        /// Consultar los vuelos de todas las aerolíneas entre dos ciudades incluyendo sus horarios.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarVuelosHorarios([FromQuery]VueloCiudadFilter vueloFiltro)
        {
            try
            {
                if (vueloFiltro.IdOrigen == 0 || vueloFiltro.IdDestino == 0)
                    return BadRequest(BadRequestError);

                List<VueloDTO> vuelos = new VueloApplication().ConsultarVueloHorarios(vueloFiltro);

                if (!vuelos.Any()) return NotFound(NotFoundError);

                return Ok(vuelos);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorConsultarVuelo);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorConsultarVuelo);
            }
        }

        /// <summary>
        /// Consulta de vuelos entre dos ciudades con prioridad en las tarifas.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarVuelosTarifas([FromQuery]VueloCiudadFilter vueloFiltro)
        {
            try
            {
                if (vueloFiltro.IdOrigen == 0 || vueloFiltro.IdDestino == 0)
                    return BadRequest(BadRequestError);

                List<VueloDTO> vuelos = new VueloApplication().ConsultarVueloTarifas(vueloFiltro);

                if (!vuelos.Any()) return NotFound(NotFoundError);

                return Ok(vuelos);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorConsultarVuelo);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorConsultarVuelo);
            }
        }

        /// <summary>
        /// Consultar estados de los vuelos y la disponibilidad de asientos.
        /// </summary>
        /// <param name="vueloFiltro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarEstadosVuelos([FromQuery]VueloCiudadFilter vueloFiltro)
        {
            try
            {
                if (vueloFiltro.IdOrigen == 0 || vueloFiltro.IdDestino == 0)
                    return BadRequest(BadRequestError);

                List<EstadoVueloDTO> vuelos = new VueloApplication().ConsultarEstadosVuelos(vueloFiltro);

                if (!vuelos.Any()) return NotFound(NotFoundError);

                return Ok(vuelos);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorConsultarEstadosVuelo);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorConsultarEstadosVuelo);
            }
        }

        #endregion Methods
    }
}