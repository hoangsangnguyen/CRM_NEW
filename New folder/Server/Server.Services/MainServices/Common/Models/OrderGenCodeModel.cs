using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.BaseService;

namespace Vino.Server.Services.MainServices.Common.Models
{
    public class OrderGenCodeModel : BaseDto
    {
        public string OrderPrefix { get; set; }
        /// <summary>
        /// Ngay hien tai
        /// </summary>
        public DateTime CurrentDate { get; set; }

        public int Begin { get; set; }
        public int CurrentNumber { get; set; }
        public int End { get; set; }
    }
}
