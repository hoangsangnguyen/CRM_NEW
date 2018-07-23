using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.Customer
{
    public class CustomerListModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ContactId { get; set; }
        public int? LocationId { get; set; }
    }
}