using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.Carriers
{
    public class CarriersListModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Cell { get; set; }

        public int? CountryId { get; set; }

    }
}