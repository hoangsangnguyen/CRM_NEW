using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.Port.Model
{
    public class SearchingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string PortCode { get; set; }

        public string PortName { get; set; }
        public int? NationalityId { get; set; }
        public int? ModeId { get; set; }
    }
}
