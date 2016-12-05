using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Tns.Aerolinea.Application.DTO.Reserva;
using Tns.Aerolinea.Application.Services;
using Tns.Aerolinea.Entities.Filter;

namespace Tns.Aerolinea.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReservaController : Controller
    {
        #region Constants

        private const string BadRequestError = "Todos los parámetros de entrada están nulos o vacíos.";
        private const string NotFoundError = "No se ha encontrado un resultado para la consulta especificada.";
        private const string InternalServerErrorReservarVuelo = "Se ha presentado un error al reservar el vuelo. Por favor, revise la información e intente nuevamente.";

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
        [HttpPut]
        public IActionResult ReservaVuelo([FromBody]ReservaVueloFilter reservaFiltro)
        {
            try
            {
                if (reservaFiltro.IdUsuario == 0 || reservaFiltro.IdVuelo == 0 || !reservaFiltro.TiquetePasajero.Any())
                    return BadRequest(BadRequestError);

                new ReservaApplication().ReservarVuelo(reservaFiltro);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorReservarVuelo);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorReservarVuelo);
            }
        }

        /// <summary>
        /// Consultar Reservas de un usuario que estén activas, es decir que la fecha del vuela sea hoy o superior.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarReservas([FromQuery]int idUsuario)
        {
            try
            {
                if (idUsuario == 0)
                    return BadRequest(BadRequestError);

                List<ReservaDTO> reservas = new ReservaApplication().ConsultarReservas(idUsuario);
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorReservarVuelo);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorReservarVuelo);
            }
        }

        #endregion Methods
    }
}