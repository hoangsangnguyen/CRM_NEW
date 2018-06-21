using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.Common
{
    public class Province : BaseEntity
    {
        [MaxLength(256)]
        public string Name { get; set; }

        private IList<District> _districts;
        public virtual IList<District> Districts => _districts ?? (_districts = new List<District>());
    }
}
