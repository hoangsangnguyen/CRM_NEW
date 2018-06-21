using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Falcon.Web.Api.Security;
using Vino.Server.Services.MainServices.Employees;
using Vino.Shared.Dto.Employees;

namespace Vino.Server.Api.Api
{
	[RoutePrefix("api/Employeedata")]
	public class EmployeeDataController : SecureApiController
	{
		private readonly EmployeeService _employeeService;
		public EmployeeDataController(EmployeeService employeeService)
		{
			_employeeService = employeeService;
		}
		[HttpGet]
		[Route("")]
		public async Task<EmployeeDataDto> Get(DateTimeOffset lastUpdate)
		{
			//var date = DateTimeOffset.Parse(lastUpdate, new CultureInfo("vi-VN"));
			return await _employeeService.GetEmployeeData(TokenHelper.CurrentUserId(), lastUpdate);
		}
		[HttpPut]
		[Route("{id}")]
		public async Task Put(int id, [FromBody]EmployeeDataDto value)
		{
			await _employeeService.SaveEmployeeData(id, value);
		}
	}
}