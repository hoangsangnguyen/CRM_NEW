using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.FclImps
{
    public class FclImpsListModel
    {
        public string FromDt { get; set; }
        public string ToDt { get; set; }
        public string Mbl { get; set; }
        public int? OpIcId { get; set; }
    }
}