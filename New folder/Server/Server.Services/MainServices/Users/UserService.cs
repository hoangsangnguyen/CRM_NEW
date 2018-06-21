using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Core.Security;
using Falcon.Web.Mvc.PageList;
using Vino.Server.Services.Constants;
using Vino.Server.Services.Database;
using Vino.Server.Services.Helper;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Users.Models;
using Vino.Shared.Constants.Common;
using Vino.Shared.Dto.Common;

namespace Vino.Server.Services.MainServices.Users
{
    public class UserService
    {
        private const int SaltLenght = 6;
        private readonly DataContext _dataContext;
        private readonly IEncryptionService _encryptionService;
        private readonly UserAuthService _userAuthService;
        public UserService(DataContext masterContext
            , IEncryptionService encryptionService
            , UserAuthService userAuthService)
        {
            _dataContext = masterContext;
            _encryptionService = encryptionService;
            _userAuthService = userAuthService;
        }

        /// <summary>
        /// Tao user dang nhap duoc web admin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public async Task<CrudResult> Create(string userName, string password, List<string> roles, string displayName = "")
        {
            //validate userName and roles before save
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user != null) return new CrudResult()
            {
                ErrorCode = CommonErrorStatus.DuplicateData,
                ErrorDescription = "Tên đăng nhập đã tồn tại vui lòng chọn tên đăng nhập khác"
            };
            foreach (var role in roles)
            {
                if (await _userAuthService.GetRole(role) == null) return new CrudResult();
            }
            //save user
            var salt = _encryptionService.CreateSaltKey(SaltLenght);
            user = new User()
            {
                UserName = userName,
                Active = true,
                Salt = salt,
                Password = _encryptionService.CreatePasswordHash(password, salt),
                Roles = string.Join(SharedValues.DelimiterString, roles),
                DisplayName = displayName
            };
            _dataContext.Users.Add(user);
            //todo create employee
            await _dataContext.SaveChangesAsync();
            return new CrudResult()
            {
                ReturnId = user.Id,
                IsOk = true
            };
        }
     
        public async Task<CrudResult> Create(string userName, string password, string role)
        {
            return await Create(userName, password, new List<string>() { role });
        }

        /// <summary>
        /// id = user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetById(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }
       

        #region User CURD


        public async Task<IPageList<UserModel>> SearchUser(SearchUserRequest request)
        {
            var query = _dataContext.Users.AsNoTracking().Where(d => !d.Deleted);

            if (!string.IsNullOrEmpty(request.UserName))
                query = query.Where(d => d.UserName.Contains(request.UserName));
            if (!string.IsNullOrEmpty(request.DisplayName))
                query = query.Where(d => d.DisplayName.Contains(request.DisplayName));
            if (!string.IsNullOrEmpty(request.Role))
                query = query.Where(d => d.Roles.Contains(request.Role));

            query = query.OrderByDescending(d => d.Id);
            var users = await query.Skip(request.Page * request.PageSize).Take(request.PageSize).ToListAsync();
            var pagelistUserModel = new PageList<UserModel>(users.MapTo<UserModel>(), request.Page, request.PageSize, query.Count());
            pagelistUserModel.ForEach(d =>
            {
                var roles = d.Roles.SplitIds();
                var roleVn = new List<string>();
                foreach (var role in roles)
                {
                    roleVn.Add(TranslateRoleVn(role));
                }
                d.Roles = roleVn.ToIds();
            });
            return pagelistUserModel;
        }

        public string TranslateRoleVn(string role)
        {
            switch (role)
            {
                case ServerPermissions.Admin:
                    return "Quản trị";
                case ServerPermissions.Manager:
                    return "Người quản lý";
                case ServerPermissions.Operator:
                    return "Vận hành hệ thống";
                case ServerPermissions.ProducingManager:
                    return "Khách hàng";
                case ServerPermissions.ProducingStaff:
                    return "Chuyên gia";
                default:
                    return role;
            }
        }
        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user == null || user.Deleted)
                return null;
            return user.MapTo<UserModel>();
        }

        public async Task UpdateUser(UserModel model)
        {
            var userUpdate = _dataContext.Users.Find(model.Id);
            if (userUpdate == null || userUpdate.Deleted) return;

            userUpdate.DisplayName = model.DisplayName;
            userUpdate.Roles = model.RoleList.ToIds();
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = _dataContext.Users.Find(id);
            if (user == null || user.Deleted) return;
            user.Active = false;
            user.Deleted = true;

            await _dataContext.SaveChangesAsync();
        }

        public async Task ChangePassword(int id, string password)
        {
            var user = _dataContext.Users.Find(id);
            if (user == null || user.Deleted) return;
            var salt = _encryptionService.CreateSaltKey(SaltLenght);
            user.Salt = salt;
            user.Password = _encryptionService.CreatePasswordHash(password, salt);
            await _dataContext.SaveChangesAsync();
        }
        #endregion

    }
}