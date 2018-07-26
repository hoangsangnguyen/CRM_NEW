using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.HblLclExps
{
    public class HblLclExpListModel
    {

        public string FromDt { get; set; }
        public string ToDt { get; set; }
        public int? ExpId { get; set; }

        public string BlNumber { get; set; }
        public string BookingNumber { get; set; }

        public int? ShipperId { get; set; }
        public int? ConsigneeId { get; set; }

    }
}