using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Common.Models;

namespace Vino.Server.Web.Api
{
    public class RoleApiController : BaseApiController
    {
        private readonly RoleService _roleService;

        public RoleApiController(RoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<List<NameValueModel>> GetRoles()
        {
            var roles = await _roleService.GetAllRoles();
            if (!roles.Any())
                return new List<NameValueModel>();
            return roles.Select(d => new NameValueModel()
            {
                Name = d.Display,
                Value = d.SystemName
            }).ToList();
        }
        public async Task<List<NameValueModel>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();
            if (!roles.Any())
                return new List<NameValueModel>();

            var res = roles.Select(d => new NameValueModel()
            {
                Name = d.Display,
                Value = d.SystemName
            }).ToList();
            res.Insert(0, new NameValueModel()
            {
                Name = "Tất cả"
            });
            return res;
        }
    }
}