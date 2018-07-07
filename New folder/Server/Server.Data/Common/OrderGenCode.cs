using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.Common
{
    public class OrderGenCode : BaseEntity
    {
        /// <summary>
        /// Tien to
        /// </summary>
        public string OrderPrefix { get; set; }
        /// <summary>
        /// Ngay hien tai
        /// </summary>
        public DateTimeOffset CurrentDate { get; set; }

        public int Begin { get; set; }
        public int CurrentNumber { get; set; }
        public int End { get; set; }

    }
}
