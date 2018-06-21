using System.Threading.Tasks;
using System.Web.Http;
using Falcon.Web.Api.Security;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Employees;
using Vino.Shared.Constants.Common;
using Vino.Shared.Dto.Common;
using Vino.Shared.Dto.Employees;

namespace Vino.Server.Api.Api
{
	[RoutePrefix("api/Employees")]
	public class EmployeesController : SecureApiController
	{
		private readonly EmployeeService _EmployeeService;
		private readonly UserAuthService _authService;
		public EmployeesController(EmployeeService EmployeeService,
			UserAuthService authService)
		{
			_EmployeeService = EmployeeService;
			_authService = authService;
		}
	
		[AllowAnonymous]
		[HttpPost]
		[Route("reset")]
		public async Task<CrudResult> Post([FromBody]string newPassword)
		{
			var res= await _authService.ChangePassword(TokenHelper.CurrentUserId(), newPassword);
			if (!res) return new CrudResult()
			{
				ErrorCode = CommonErrorStatus.KeyNotFound,
				ErrorDescription = "Không tìm thấy thông tin khách hàng"
			};
			return new CrudResult
			{
				IsOk = true
			};
		}
		// PUT: api/UserData/5
		//[HttpPut]
		//[Route("{id}")]
		//public async Task Put(int id, [FromBody]EmployeeDto value)
		//{
		//	await _EmployeeService.UpdateEmployee(TokenHelper.CurrentUserId(), value);
		//}

	}
}