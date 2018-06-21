using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vino.Server.Services.MainServices.Common.Models;
using Vino.Server.Services.MainServices.Employees;

namespace Vino.Server.Web.Api
{
    public class EmployeeApiController : BaseApiController
    {
        private readonly EmployeeService _employeeService;

        public EmployeeApiController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<List<NameValueModel>> GetEmployee(bool withAll = false)
        {
            var models = (await _employeeService.SearchEmployee(new SearchEmployeeRequest()
            {
                Page = 0,
                PageSize = int.MaxValue,
            })).OrderBy(d => d.DisplayName).Select(d => new NameValueModel()
            {
                Name = d.DisplayName,
                Value = d.Id.ToString()
            }).ToList();
            if (withAll)
                models.Insert(0, new NameValueModel { Name = "Tất cả", Value = "0" });
            return models;
        }
	    public async Task<List<NameValueModel>> GetAllEmployees(string name = "")
	    {
		    var models = (await _employeeService.SearchEmployee(new SearchEmployeeRequest()
		    {
				Name = name,
			    Page = 0,
			    PageSize = int.MaxValue,
		    })).OrderBy(d => d.DisplayName).Select(d => new NameValueModel()
		    {
			    Name = d.DisplayName,
			    Value = d.Id.ToString()
		    }).ToList();
		    return models;
	    }

		//public Task<List<NameValueModel>> GetMockEmployee()
		//{
		//    //todo: remove the mock
		//    return Task.FromResult(
		//        Enumerable.Range(1, 7).Select(aa => new NameValueModel
		//        {
		//            Value = aa.ToString(),
		//            Name = $"CBKT {aa}"
		//        }).ToList()
		//    );
		//}
	}
}