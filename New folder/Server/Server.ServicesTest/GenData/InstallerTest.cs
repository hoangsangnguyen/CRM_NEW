using System.Threading.Tasks;
using Falcon.Web.Core.Infrastructure;
using Vino.Server.Services.Installation;
using NUnit.Framework;

namespace Vino.Server.ServicesTest.GenData
{
    [TestFixture]
    public class InstallerTest : SetUpWithDb
    {
        [Test]
        public async Task Seed_data()
        {
            var installer = EngineContext.Current.Resolve<Installer>();
            var result = await installer.Install();
            Assert.IsTrue(result == "Done");
        }
      
    }
}