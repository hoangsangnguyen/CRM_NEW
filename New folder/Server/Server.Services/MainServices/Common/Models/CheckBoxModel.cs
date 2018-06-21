using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.Common.Models
{
    public class CheckBoxModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool Checked { get; set; }
    }
}
