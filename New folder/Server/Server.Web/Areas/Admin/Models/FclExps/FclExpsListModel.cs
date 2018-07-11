using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.FclExps
{
    public class FclExpsListModel
    {
        public string FromDt { get; set; }
        public string ToDt { get; set; }
        public string Mbl { get; set; }
        public int? OpIcId { get; set; }
    }
}