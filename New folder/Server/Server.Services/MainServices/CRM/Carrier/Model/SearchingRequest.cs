using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.Carrier.Model
{
    public class SearchingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Cell { get; set; }

        public int? CountryId { get; set; }
    }
}
