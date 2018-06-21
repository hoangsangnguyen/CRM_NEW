using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;

namespace Vino.Server.Data.Common
{
    public class ImageRecord : BaseEntity
    {
        public string FileName { get; set; }
        public string RelativePath { get; set; }
        public string AbsolutePath { get; set; }
        public bool IsExternal { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsUsed { get; set; }
    }
}
