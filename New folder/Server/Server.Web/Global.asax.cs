using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using AutoMapper;
using Falcon.Web.Core.Infrastructure;
using Falcon.Web.Core.Log;
using Vino.Server.Services.Infrastructure;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Vino.Server.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
	        Telerik.Reporting.Services.WebApi.ReportsControllerConfiguration.RegisterRoutes(System.Web.Http.GlobalConfiguration.Configuration);

			//Web api
			GlobalConfiguration.Configure(WebApiConfig.Register);
            //AutoMapper
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperWebProfile>();
            });

            //IoC for web api
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            DependencyRegistra.Register(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            // MVC controllers
            WebRegistration.Register(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            //Fix date time serialize
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                };
            //setup MVC
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            //finish
            using (AsyncScopedLifestyle.BeginScope(container))
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Info("MasterAdmin Started!");
            }

        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            //log error
            LogException(exception);
        }
        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;
            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
                return;
            try
            {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(exc.Message, exc.ToString());
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}