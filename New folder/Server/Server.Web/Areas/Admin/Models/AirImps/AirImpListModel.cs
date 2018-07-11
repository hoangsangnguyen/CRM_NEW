using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.AirImps
{
    public class AirImpListModel
    {
        public string FromDt { get; set; }
        public string ToDt { get; set; }
        public string MawbNumber { get; set; }
        public int? OpIcId { get; set; }
    }
}