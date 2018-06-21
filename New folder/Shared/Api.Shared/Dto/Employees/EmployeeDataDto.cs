using System;
using System.Collections.Generic;
using System.Text;
using Vino.Shared.Entities;

namespace Vino.Shared.Dto.Employees
{
    public class EmployeeDataDto
    {
	    public bool NeedUpdate { get; set; }
	    public DateTimeOffset LastUpdatedAt { get; set; }
		public string Settings { get; set; }
    }
}
