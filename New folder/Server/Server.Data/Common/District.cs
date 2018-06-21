using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.Common
{
    public class District : BaseEntity
    {
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
