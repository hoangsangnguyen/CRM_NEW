using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.LclExp.Models
{
    public class SearchingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public DateTimeOffset? FromDt { get; set; }
        public DateTimeOffset? ToDt { get; set; }
        public string Mbl { get; set; }
        public int? OpIcId { get; set; }
    }
}
