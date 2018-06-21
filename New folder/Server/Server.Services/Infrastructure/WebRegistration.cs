using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Mvc.Security;
using SimpleInjector;

namespace Vino.Server.Services.Infrastructure
{
    public class WebRegistration
    {
        public static void Register(Container container)
        {
            //web context
            container.Register<WebContext>(Lifestyle.Scoped);

        }
    }
}
