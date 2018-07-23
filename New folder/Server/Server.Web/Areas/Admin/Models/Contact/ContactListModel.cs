using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vino.Server.Web.Areas.Admin.Models.Contact
{
    public class ContactListModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
    }
}