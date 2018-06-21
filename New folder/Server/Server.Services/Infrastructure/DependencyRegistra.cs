using Falcon.Web.Core.Caching;
using Falcon.Web.Core.Infrastructure;
using Falcon.Web.Core.Log;
using Falcon.Web.Core.Security;
using Falcon.Web.Core.Settings;
using SimpleInjector;
using Vino.Server.Services.ApiServices.Core;
using Vino.Server.Services.Database;
using Vino.Server.Services.Framework;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Common;
using Vino.Server.Services.MainServices.Media;
using Vino.Server.Services.MainServices.Message;
using Vino.Server.Services.MainServices.System.Log;
using UserService = Vino.Server.Services.MainServices.Users.UserService;


namespace Vino.Server.Services.Infrastructure
{
    public static class DependencyRegistra
    {
        public static void Register(Container container)
        {
            //DB
            container.Register<DataContext>(Lifestyle.Scoped);
            //Framework
            container.Register<ILogger, Logger>(Lifestyle.Scoped);
            container.Register<ITokenValidation, TokenValidation>(Lifestyle.Scoped);
            container.Register<ICacheManager, MemoryCacheManager>(Lifestyle.Scoped);
            container.Register<IEncryptionService, EncryptionService>(Lifestyle.Scoped);
            container.Register<ISettingService, SettingService>(Lifestyle.Scoped);
            container.Register<SettingService>(Lifestyle.Scoped); //to use in web admin
            container.Register<LogService>(Lifestyle.Scoped);

            //Common
            container.Register<RoleService>(Lifestyle.Scoped);
            container.Register<UserService>(Lifestyle.Transient);
	        container.Register<LookupService>(Lifestyle.Scoped);
            container.Register<ImageService>(Lifestyle.Scoped);
            container.Register<EmailAccountService>(Lifestyle.Scoped);
            container.Register<MessageTemplateService>(Lifestyle.Scoped);
			//LAST
			EngineContext.Current.Init(new SimpleContainer(container));
        }
        public  static void ApiServerRegister(Container container) 
        {
            Register(container);
			container.Register<UserAuthService>(Lifestyle.Scoped);
	        container.Register<ImageApiService>(Lifestyle.Scoped);
		}
    }
}