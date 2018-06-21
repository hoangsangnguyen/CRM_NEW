using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Falcon.Web.Core.Infrastructure;
using Falcon.Web.Core.Log;
using FluentScheduler;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Vino.Server.Services.Infrastructure;
using Vino.Server.Services.MainServices.Tasks;

namespace Vino.Server.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            //Web api
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //AutoMapper
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperApiProfile>();
            });

            //IoC for web api
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            DependencyRegistra.ApiServerRegister(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            // MVC controllers
            //WebRegistration.Register(container);
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
			//setup schedule tasks
	        JobManager.Initialize(new TaskRegistry());
	        JobManager.JobException += (info) =>
	        {
		        using (AsyncScopedLifestyle.BeginScope(SimpleContainer.Container))
		        {
			        var logger = EngineContext.Current.Resolve<ILogger>();
			        logger.Error("Task error " + info.Name, info.Exception.ToString());
		        }
	        };
			//finish
			using (AsyncScopedLifestyle.BeginScope(container))
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Info("Vino Api Server Started!");
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