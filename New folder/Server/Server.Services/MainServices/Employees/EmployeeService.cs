using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Data.HR;
using Vino.Server.Services.Constants;
using Vino.Server.Services.Database;
using Vino.Server.Services.MainServices.Employees.Models;
using Vino.Server.Services.MainServices.Users;
using Vino.Shared.Dto.Common;
using Vino.Shared.Dto.Employees;

namespace Vino.Server.Services.MainServices.Employees
{
    public class EmployeeService
    {
        private readonly DataContext _dataContext;
        private readonly UserService _userService;
        public EmployeeService(DataContext dataContext
            , UserService userService)
        {
            _dataContext = dataContext;
            _userService = userService;

        }
        public async Task<EmployeeDataDto> GetEmployeeData(int employeeId, DateTimeOffset clientDate)
        {
            var data = await _dataContext.EmployeeData.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (data == null) return new EmployeeDataDto();
            if (data.LastUpdatedAt >= clientDate) return new EmployeeDataDto()
            {
                LastUpdatedAt = clientDate
            };
            var result = data.MapTo<EmployeeDataDto>();
            result.NeedUpdate = true;
            return result;
        }
        public async Task SaveEmployeeData(int employeeId, EmployeeDataDto data)
        {

            var employeeData = await _dataContext.EmployeeData.FirstOrDefaultAsync(f => f.EmployeeId == employeeId)
                               ?? new EmployeeData()
                               {
                                   EmployeeId = employeeId,
                               };
            if (employeeData.LastUpdatedAt < data.LastUpdatedAt)
            {
                //TODO
                employeeData.LastUpdatedAt = DateTimeOffset.Now;
            }
            if (employeeData.Id == 0)
                _dataContext.EmployeeData.Add(employeeData);
            await _dataContext.SaveChangesAsync();
        }

        #region Employee
        public async Task<IPageList<EmployeeModel>> SearchEmployee(SearchEmployeeRequest request)
        {
            var query = _dataContext.Employees.AsNoTracking().Where(d => !d.Deleted);
            if (!string.IsNullOrEmpty(request.DisplayName))
                query = query.Where(d => d.DisplayName.Contains(request.DisplayName));
            if (!string.IsNullOrEmpty(request.Email))
                query = query.Where(d => d.Email.Contains(request.Email));
            if (!string.IsNullOrEmpty(request.Phone))
                query = query.Where(d => d.Phone.Contains(request.Phone));
            if (!string.IsNullOrEmpty(request.Username))
                query = query.Where(d => d.User.UserName.Contains(request.Username));
            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(d => d.FullName.Contains(request.Name));
            if (!string.IsNullOrEmpty(request.DeviceType))
                query = query.Where(d => d.Apps.Contains(request.DeviceType));

            var employee = await query.OrderByDescending(d => d.Id).Skip(request.Page * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            var model = employee.MapTo<EmployeeModel>();
            model.ForEach(d =>
            {
                //d.HasDevice = _dataContext.MobileDevices.Any(v => v.EmployeeId == d.Id && !v.Deleted);
            });

            return new PageList<EmployeeModel>(model, request.Page, request.PageSize, query.Count());
        }
        public async Task DeleteEmployee(int employeeId)
        {
            if (employeeId == 0)
                return;

            var employee = _dataContext.Employees.Find(employeeId);
            if (employee == null || employee.Deleted)
                return;

            employee.Deleted = true;

            await _dataContext.SaveChangesAsync();
        }
        public virtual async Task<CrudResult> InsertEmployee(EmployeeModel employeeModel)
        {
            if (employeeModel == null)
                throw new ArgumentNullException(nameof(employeeModel));

            var employee = employeeModel.MapTo<Employee>();

            var now = DateTimeOffset.Now;
            employee.CreatedAt = now;
            employee.DisplayName = employeeModel.FullName;
            employee.DayOfBirth = string.IsNullOrEmpty(employeeModel.DayOfBirth) ? (DateTime?)null : DateTime.Parse(employeeModel.DayOfBirth, new CultureInfo("vi-VN"));
            var crudResult = await _userService.Create(employeeModel.UserName, employeeModel.Password,
                new List<string>() { ServerPermissions.Employee }, employeeModel.FullName);
            if (!crudResult.IsOk) return crudResult;

            employee.UserId = crudResult.ReturnId;

            _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();
            employeeModel.Id = employee.Id;
            return new CrudResult()
            {
                IsOk = true
            };
        }

        public virtual async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            if (employeeModel == null)
                throw new ArgumentNullException(nameof(employeeModel));

            var employee = _dataContext.Employees.Find(employeeModel.Id);
            if (employee == null || employee.Deleted)
                return;
            //EmployeeModel.MapTo(Employee);
            employee.FullName = employeeModel.FullName;
            employee.DisplayName = employeeModel.FullName;
            employee.Phone = employeeModel.Phone;
            employee.Email = employeeModel.Email;
            employee.DayOfBirth = string.IsNullOrEmpty(employeeModel.DayOfBirth) ? (DateTime?)null : DateTime.Parse(employeeModel.DayOfBirth, new CultureInfo("vi-VN"));
            employee.Address = employeeModel.Address;
            employee.Note = employeeModel.Note;
            employee.ProvinceId = employeeModel.ProvinceId;
            employee.DistrictId = employeeModel.DistrictId;
            employee.Apps = employeeModel.Apps;

            await _dataContext.SaveChangesAsync();
        }

        public virtual Employee GetEmployeeById(int employeeId)
        {
            if (employeeId == 0)
                return null;

            var employee = _dataContext.Employees.Find(employeeId);
            if (employee == null || employee.Deleted)
                return null;
            return employee;
        }
        public async Task<Employee> GetEmployeeByUserId(int userId)
        {
            if (userId == 0)
                return null;

            var employee = await _dataContext.Employees.FirstOrDefaultAsync(f => f.UserId == userId);
            if (employee == null || employee.Deleted)
                return null;
            return employee;
        }
        #endregion

        #region mobiledevice

       // public int CountMobileDevice() => _dataContext.MobileDevices.AsNoTracking().Where(d => !d.Deleted).Distinct().Count();

        #endregion
    }
}
