using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.SiLclExp
{
    public class SiLclExpListModel
    {

        public string FromDt { get; set; }
        public string ToDt { get; set; }

        public int? LclExpId { get; set; }

        public string ReferenceNo { get; set; }

        public string BookingNumber { get; set; }

        public int? ShipperId { get; set; }
        public int? ConsigneeId { get; set; }
    }
}