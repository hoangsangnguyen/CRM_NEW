using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Settings;

namespace Vino.Server.Services.Settings
{
    public class SystemSettings : ISettings
    {
        public int CacheLong { get; set; }
        public int CacheNormal { get; set; }
        public int CacheShort { get; set; }
        public string Domain { get; set; }
    }
}
