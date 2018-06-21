using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Caching;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Services.Constants;
using Vino.Server.Services.Database;
using Vino.Server.Services.Helper;
using Vino.Server.Services.MainServices.Auth.Models;

namespace Vino.Server.Services.MainServices.Auth
{
    public class RoleService
    {

        private readonly DataContext _masterContext;
        private readonly ICacheManager _cacheManager;

        public RoleService(DataContext masterContext
            , ICacheManager cacheManager)
        {
            _masterContext = masterContext;
            _cacheManager = cacheManager;
        }

        public async Task<int> Create(Role role)
        {
            _masterContext.Roles.Add(role);
            _cacheManager.Remove(UserAuthService.AllRolesKey);
            return await _masterContext.SaveChangesAsync();
        }
       
        public Role GetRoleBySystemName(string systemName)
        {
            var role = _masterContext.Roles.AsNoTracking().FirstOrDefault(d => d.SystemName == systemName);
            return role;
        }

        public async Task<List<Role>> GetRoleByUserId(int id)
        {
            var user = await _masterContext.Users.FindAsync(id);
            if (user == null) return null;
            var roleUser = user.Roles.SplitIds();
            var role = _masterContext.Roles.Where(d => roleUser.Contains(d.SystemName));
            return role.ToList();
        }
        public async Task UpdateRole(Role role)
        {
            var p = _masterContext.Roles.FirstOrDefault(d => d.SystemName == role.SystemName);
            if (p == null) return;

            p.Display = role.Display;

            await _masterContext.SaveChangesAsync();
        }

        public async Task DeleteRole(string systemName)
        {
            var role = _masterContext.Roles.FirstOrDefault(d => d.SystemName == systemName);
            if (role == null) return;

            _masterContext.Roles.Remove(role);
            await _masterContext.SaveChangesAsync();
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var role = await _masterContext.Roles.AsNoTracking().ToListAsync();
            var roleModel = role.Select(d => d.MapTo<RoleModel>()).ToList();
            foreach (var model in roleModel)
            {
                var modelExculde = roleModel.Where(d => d.SystemName != model.SystemName).ToList();
                while (modelExculde.Any(d => d.Id == model.Id))
                {
                    model.Id++;
                }
            }

            return roleModel;
        }

        public async Task<IPageList<RoleModel>> SearchRole(SearchRoleRequest request)
        {
            var query = _masterContext.Roles.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(request.Display))
            {
                query = query.Where(d => d.Display.Contains(request.Display));
            }
            query = query.OrderByDescending(d => d.SystemName);
            var role = await query.Skip(request.Page * request.PageSize).Take(request.PageSize).ToListAsync();
            return new PageList<RoleModel>(role.MapTo<RoleModel>(), request.Page, request.PageSize, query.Count());
        }

        public async Task UpdateRole(RoleModel role)
        {
            var p = _masterContext.Roles.FirstOrDefault(d => d.SystemName == role.SystemName);
            if (p == null) return;

            p.Display = role.Display;
            p.Active = role.Active;

            await _masterContext.SaveChangesAsync();
        }

        public async Task<List<RoleClaimModel>> GetRoleClaim()
        {
            var role = await _masterContext.Roles.AsNoTracking().ToListAsync();
            var res = new List<RoleClaimModel>();
            role.ForEach(d =>
            {
                res.Add(new RoleClaimModel()
                {
                    SystemName = d.SystemName,
                    Display = d.Display,
                    Claim = GetAllClaimByRole(d.SystemName)
                });
            });
            return res;
        }

        private List<ClaimModel> GetAllClaimByRole(string role)
        {
            var res = new List<ClaimModel>();
            //tất cả claim
            var claim = ServerPermissions.DefaultClaims.Select(d => d.Value).Distinct();
            //claim của model default
            //var claimRole = Roles.DefaultClaims.Where(x => x.Key == model).Select(x => x.Value).ToList();
            //claim được thêm mới vào model
            var claimOrther = new string[] { };

            //các quyền được thêm mới không phải default
            var claimRoleOrther = _masterContext.Roles.FirstOrDefault(d => d.SystemName == role);
            if (claimRoleOrther != null)
                claimOrther = claimRoleOrther.Permissons.SplitIds();

            foreach (var value in claim)
            {
                if (claimOrther.Contains(value))
                {
                    res.Add(new ClaimModel()
                    {
                        SystemName = value,
                        Name = TranslateClaimVn(value),
                        Checked = true
                    });
                    continue;
                }
                res.Add(new ClaimModel()
                {
                    SystemName = value,
                    Name = TranslateClaimVn(value),
                });

            }
            return res;
        }

        public async Task UpdateClaimByRole(RoleClaimUpdateModel model)
        {
            var query = model.RoleClaims.GroupBy(d => d.RoleSystemName).ToList();
            var roles = _masterContext.Roles.ToList();
            roles.ForEach(v =>
            {
                var r = query.FirstOrDefault(d => d.Key == v.SystemName);
                if (r == null)
                {
                    v.Permissons = string.Empty;
                    return;
                }
                v.Permissons = string.Join(";", r.Select(f => f.ClaimSystemName));
            });
            await _masterContext.SaveChangesAsync();
            //await _localApisCacheManagerService.ClearCampusCache(CacheResetTypes.Roles);
        }

        public bool CheckRoleSystemNameExist(string newSystemName, string oldSystemName = "")
        {
            var role = _masterContext.Roles.Where(d => d.SystemName == newSystemName);
            if (!string.IsNullOrEmpty(oldSystemName))
                role = role.Where(d => d.SystemName != oldSystemName);
            return role.Any();
        }

        public string TranslateClaimVn(string claim)
        {
            switch (claim)
            {
                case ServerPermissions.AccessAdminPanel:
                    return "Truy cập trang quản trị";
                case ServerPermissions.ManageFalconUsers:
                    return "Quản lý User";
                case ServerPermissions.ManageExaminationProcedure:
                    return "Quản lý quy trình bệnh viện";
                case ServerPermissions.ManageMessageTemplates:
                    return "Quản lý tin nhắn biểu mẫu";
                case ServerPermissions.ManageSettings:
                    return "Quản lý settings";
                case ServerPermissions.ManageActivityLog:
                    return "Quản lý nhật ký hoạt động";
                case ServerPermissions.ManageEmailAccounts:
                    return "Quản lý tài khoản email";
                case ServerPermissions.ManageSystemLog:
                    return "Quản lý nhật ký hệ thống";
                case ServerPermissions.ManageMessageQueue:
                    return "Quản lý hàng chờ tin nhắn";
                case ServerPermissions.ManageMaintenance:
                    return "Quản lý bảo trì";
                case ServerPermissions.ManageScheduleTasks:
                    return "Quản lý công việc tự động";
                case ServerPermissions.ManageHospital:
                    return "Quản lý bệnh viện";
                case ServerPermissions.ManageRole:
                    return "Quản lý vai trò/quyền";
                case ServerPermissions.ManageLookup:
                    return "Quản lý lookup";
                case ServerPermissions.ManageUserHospital:
                    return "Quản lý user - bệnh viện";
                case ServerPermissions.ManageNews:
                    return "Quản lý tin tức";
                case ServerPermissions.ManageFeedback:
                    return "Quản lý góp ý";
                case ServerPermissions.ManageMap:
                    return "Quản lý bản đồ";
                case ServerPermissions.ManageRoom:
                    return "Quản lý phòng khám";
                case ServerPermissions.ManageShift:
                    return "Quản lý cá khám";
                case ServerPermissions.ManageProduct:
                    return "Quản lý dịch vụ khám";
                case ServerPermissions.ManageMasterItem:
                    return "Quản lý lịch khám tổng";
                case ServerPermissions.ManageNewsHospital:
                    return "Quản lý tin tức (bệnh viện)";
                case ServerPermissions.ManageFeedbackHospital:
                    return "Quản lý góp ý (bệnh viện)";
                case ServerPermissions.ManageMapHospital:
                    return "Quản lý bản đồ (bệnh viện)";
                case ServerPermissions.ManageExaminationProcedureHospital:
                    return "Quản lý quy trình bệnh viện (bệnh viện)";
                case ServerPermissions.ManageRoomHospital:
                    return "Quản lý phòng khám (bệnh viện)";
                case ServerPermissions.ManageShiftHospital:
                    return "Quản lý cá khám (bệnh viện)";
                case ServerPermissions.ManageProductHospital:
                    return "Quản lý dịch vụ khám (bệnh viện)";
                case ServerPermissions.ManageMasterItemHospital:
                    return "Quản lý lịch khám tổng (bệnh viện)";
                case ServerPermissions.ManageCalendarException:
                    return "Quản lý ngày nghỉ";
                case ServerPermissions.ManageCalendarExceptionHospital:
                    return "Quản lý ngày nghỉ (bệnh viện)";
                case ServerPermissions.ManageOperator:
                    return "Quản lý nhân viện vận hành hệ thống";
                case ServerPermissions.ManageReserved:
                    return "Quản lý đặt lịch khám";
                case ServerPermissions.ManageReservedHospital:
                    return "Quản lý đặt lịch khám (bệnh viện)";
                default:
                        return claim;
            }
        }
    }
}


