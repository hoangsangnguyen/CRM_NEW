using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.HblLclExp.Models
{
    public class SearchingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public DateTimeOffset? FromDt { get; set; }
        public DateTimeOffset? ToDt { get; set; }

        public int? LclExpId { get; set; }

        public string BlNumber { get; set; }
        public string BookingNumber { get; set; }

        public int? ShipperId { get; set; }
        public int? ConsigneeId { get; set; }
    }
}
