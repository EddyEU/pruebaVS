namespace Tns.Aerolinea.WebApi.Controllers
{
    using Application.Services;
    using Entities.AerolineaTnsModel;
    using Entities.Filter;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Net;

    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        #region Constants

        private const string BadRequestError = "Todos los parámetros de entrada están nulos o vacíos.";
        private const string InternalServerErrorMotivosReversion = "Error en consultar los motivos de solicitud reversión.";
        private const string NotFoundError = "No se ha encontrado un resultado para la consulta especificada.";
        private const string InternalServerErrorValidarUsuario = "Error al consultar los pedidos disponibles para hacer una solicitud de reversión.";

        #endregion Constants

        #region Private Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion Private Fields

        #region Methods

        /// <summary>
        /// Validar usuario y clave de un cliente especifico.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public IActionResult ValidarUsuario([FromQuery]LoginFilter filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(filtro.Login) || string.IsNullOrEmpty(filtro.Clave))
                    return BadRequest(BadRequestError);

                Usuario usuario = new LoginApplication().ValidarUsuario(filtro);

                if (usuario == null) return NotFound(NotFoundError);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorValidarUsuario);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorValidarUsuario);
            }
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        #endregion Methods

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}