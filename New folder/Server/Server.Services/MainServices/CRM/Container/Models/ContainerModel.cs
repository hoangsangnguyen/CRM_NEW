using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Data;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.CRM.Container.Models
{
    public class ContainerModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại container")]
        public string Type { get; set; }

        public string TypeName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn mã container")]
        public string ContainerNo { get; set; }

        public string SealNo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn số lượng")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn unit")]
        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public string DescriptionOfGoods { get; set; }

        public double Nw { get; set; }
        public double Gw { get; set; }
        public double Cbm { get; set; }
    }
}
