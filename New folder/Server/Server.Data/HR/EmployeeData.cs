using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.HR
{
    public class EmployeeData : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string Settings { get; set; }
    }
}
