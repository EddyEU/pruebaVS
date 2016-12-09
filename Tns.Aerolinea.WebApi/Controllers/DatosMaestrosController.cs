namespace Tns.Aerolinea.WebApi.Controllers
{
    using Application.DTO.DatosMaestros;
    using Application.Services;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    [Route("api/[controller]/[action]")]
    public class DatosMaestrosController : Controller
    {
        #region Constants

        private const string BadRequestError = "Todos los parámetros de entrada están nulos o vacíos.";
        private const string NotFoundError = "Usuario y/o clave no son correctos. Por favor verificar.";
        private const string InternalServerErrorConsultarOrigen = "Error al consultar el listado de ciudades y aeropuertos que son orígenes.";
        private const string InternalServerErrorConsultarDestino = "Error al consultar el listado de ciudades y aeropuertos que son destinos.";

        #endregion Constants

        #region Private Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion Private Fields

        #region Methods

        /// <summary>
        /// Obtener el listado de destinos de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        public IActionResult ConsultarDestinos()
        {
            try
            {
                List<CiudadDestinoDTO> ciudadesDestino = new DatosMaestrosApplication().ConsultarDestinos();

                if (!ciudadesDestino.Any()) return NotFound(NotFoundError);

                return Ok(ciudadesDestino);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorConsultarDestino);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorConsultarDestino);
            }
        }

        /// <summary>
        /// Obtener el listado de origenes de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        public IActionResult ConsultarOrigenes()
        {
            try
            {
                List<CiudadOrigenDTO> ciudadesOrigen = new DatosMaestrosApplication().ConsultarOrigenes();

                if (!ciudadesOrigen.Any()) return NotFound(NotFoundError);

                return Ok(ciudadesOrigen);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorConsultarOrigen);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorConsultarOrigen);
            }
        }

        #endregion Methods
    }
}