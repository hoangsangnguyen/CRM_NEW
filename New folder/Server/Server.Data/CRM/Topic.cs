using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;
using Vino.Server.Data.Common;

namespace Vino.Server.Data.CRM
{
    public class Topic : BaseEntity
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")] public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public ImageRecord Image { get; set; }

        public string Type { get; set; }

    }
}
