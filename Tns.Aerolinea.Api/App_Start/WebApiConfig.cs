using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Tns.Aerolinea.Application.DI;
using Tns.Aerolinea.Application.DTO.Login;

namespace Tns.Aerolinea.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            DependencyInjectionContainer.InitializeContainer();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<UsuarioDTO>("Usuarios");
            builder.EntityType<UsuarioDTO>().Filter("Cedula", "Nombre", "Login");
            builder.EntityType<UsuarioDTO>().OrderBy(System.Web.OData.Query.QueryOptionSetting.Allowed, "Cedula", "Nombre");
            builder.EntityType<UsuarioDTO>().Count();
            builder.EntityType<UsuarioDTO>().Expand();
            builder.EntityType<UsuarioDTO>().Select();

            //builder.Namespace = "UsuarioService";
            //builder.EntityType<UsuarioDTO>().Collection
            //    .Function("Ultimo")
            //    .Returns<int>();

            builder.Function("GetUsuarioNombreCompleto")
                .Returns<string>()
                .Parameter<string>("Cedula");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}