using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Web.Areas.Admin.Models.Lookup;

namespace Vino.Server.Web.Areas.Admin.Models.Calendar
{
    public class FactListModel
    {
        public string Name { get; set; }
        public NameValueModel DefaultApp { get; set; }
    }
}