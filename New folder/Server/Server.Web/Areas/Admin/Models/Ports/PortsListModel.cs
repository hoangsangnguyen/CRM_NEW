using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.Ports
{
    public class PortsListModel
    {
        public string PortCode { get; set; }

        public string PortName { get; set; }
        public int? NationalityId { get; set; }
        public int? ModeId { get; set; }
    }
}