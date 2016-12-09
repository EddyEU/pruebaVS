namespace Tns.Aerolinea.WebApi.Controllers
{
    using Application.DTO.Login;
    using Application.Services;
    using Entities.Filter;
    using Infrastructure.Excepciones;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using System;
    using System.Net;

    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        #region Constants

        private const string BadRequestError = "Todos los parámetros de entrada están nulos o vacíos.";
        private const string NotFoundError = "Usuario y/o clave no son correctos. Por favor verificar.";
        private const string InternalServerErrorValidarUsuario = "Error al validar el login y clave del usuario.";
        private const string InternalServerErrorRegistrarUsuario = "Error al registrar un nuevo usuario en el sistema.";

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
        [HttpGet]
        public IActionResult ValidarUsuario([FromQuery]LoginFilter filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(filtro.Login) || string.IsNullOrEmpty(filtro.Clave))
                    return BadRequest(BadRequestError);

                UsuarioDTO usuario = new LoginApplication().ValidarUsuario((LoginFilter)filtro);

                if (usuario == null) return NotFound(NotFoundError);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorValidarUsuario);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorValidarUsuario);
            }
        }

        /// <summary>
        /// Registrar un nuevo Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult RegistrarUsuario([FromBody]LoginFilter login)
        {
            try
            {
                if (login == null)
                    return BadRequest(BadRequestError);

                new LoginApplication().RegistrarUsuario(login);
                return Ok();
            }
            catch (BussinesException ex)
            {
                return StatusCode((int)HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex, InternalServerErrorRegistrarUsuario);
                return StatusCode((int)HttpStatusCode.InternalServerError, InternalServerErrorRegistrarUsuario);
            }
        }

        #endregion Methods
    }
}