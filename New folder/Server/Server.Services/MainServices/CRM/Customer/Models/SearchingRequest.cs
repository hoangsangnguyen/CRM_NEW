using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.CRM.Customer.Models
{
    public class SearchingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ContactId { get; set; }
        public int? LocationId { get; set; }
    }
}
