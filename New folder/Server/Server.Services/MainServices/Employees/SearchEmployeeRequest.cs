using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.Employees
{
    public class SearchEmployeeRequest
    {
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
