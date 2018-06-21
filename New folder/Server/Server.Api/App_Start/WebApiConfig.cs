using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Falcon.Web.Api.ExceptionHandle;
using Falcon.Web.Api.Security;

namespace Vino.Server.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new WebApiAuthHandler());
            //global exception handler
            config.Services.Replace(typeof(IExceptionHandler), new WebApiExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
