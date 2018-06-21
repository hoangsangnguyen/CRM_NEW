using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.System.Setting.Models
{
    public class SettingModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên setting")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [Required(ErrorMessage = "Vui lòng nhập giá trị setting")]
        public string Value { get; set; }

        public bool ContinueEditing { get; set; }
    }
}
