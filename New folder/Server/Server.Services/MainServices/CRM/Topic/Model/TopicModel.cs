using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Data.Common;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.Topic.Model
{
    public class TopicModel : BaseDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")] public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public int? ImageId { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }

    }
}
