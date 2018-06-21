using AutoMapper;
using Vino.Server.Services.Infrastructure;
using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Vino.Server.ServicesTest
{
    [TestFixture]
    public class SetUpWithDb
    {
        [SetUp]
        public void SetUp()
        {
            //AutoMapper
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperWebProfile>();
                cfg.AddProfile<AutoMapperApiProfile>();
            });
            //IoC
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            DependencyRegistra.ApiServerRegister(container);
            container.Verify();
            AsyncScopedLifestyle.BeginScope(container);
        }
    }
}
