namespace Tns.Aerolinea.Api.Controllers
{
    using Application.DTO.Login;
    using Application.Services;
    using Application.ServicesQueryable;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Routing;

    //[ODataRoutePrefix("Usuarios")]
    public class UsuariosController : ODataController
    {
        [EnableQuery]
        public IQueryable<UsuarioDTO> Get()
        {
            return new UsuarioAplicationQueryable().ConsultarUsuarios();
        }

        //[HttpGet]
        //[EnableQuery]
        //public IHttpActionResult Get()
        //{
        //    return Ok(new LoginApplication().ConsultarUsuario().AsQueryable());
        //}

        [HttpGet]
        [ODataRoute("GetUsuarioNombreCompleto(Cedula={cedula})")]
        public IHttpActionResult GetUsuarioNombreCompleto([FromODataUri] string cedula)
        {
            UsuarioDTO usuario = new LoginApplication().ConsultarUsuario().FirstOrDefault(item => item.Cedula == cedula);
            string nombreCompleto = $"{usuario.Nombre} {usuario.Apellido}";
            return Ok(nombreCompleto);
        }

        //[HttpGet]
        //public IHttpActionResult Ultimo()
        //{
        //    var idUsuario = new UsuarioAplicationQueryable().ConsultarUsuarios().Max(x => x.Id);
        //    return Ok(idUsuario);
        //}
    }
}