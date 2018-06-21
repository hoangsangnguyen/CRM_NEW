using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Falcon.Web.Api.Security;
using Falcon.Web.Core.Auth;
using Falcon.Web.Core.Caching;
using Falcon.Web.Core.Security;
using Vino.Server.Services.Database;
using Vino.Server.Services.Framework;
using Vino.Server.Services.Helper;
using Vino.Server.Services.Settings;
using Vino.Shared.Constants.Common;
using Vino.Shared.Dto.Common;

namespace Vino.Server.Services.MainServices.Auth
{
    public class UserAuthService
    {
        public const string AllRolesKey = "UserAuthService.AllRoles";
        private readonly DataContext _dataContext;
        private readonly IEncryptionService _encryptionService;
        private readonly ICacheManager _cacheManager;
        private readonly SettingService _settingService;
        private readonly ITokenValidation _tokenValidation;
        private const int SaltLenght = 6;
        public UserAuthService(DataContext masterContext
            , IEncryptionService encryptionService
            , ICacheManager cacheManager
            , SettingService settingService
            , ITokenValidation tokenValidation)
        {
            _dataContext = masterContext;
            _encryptionService = encryptionService;
            _cacheManager = cacheManager;
            _settingService = settingService;
            _tokenValidation = tokenValidation;
        }
        /// <summary>
        /// for api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TokenResponse> Login(TokenRequest request)
        {
            var result = new TokenResponse();
            //get user
            var user = await Validate(request.UserName, request.Password);
            if (user != null && user.UserId > 0)
            {
                var Employee = _dataContext.Employees.FirstOrDefault(x => x.UserId == user.UserId);
                if (Employee == null) return result;
                var securitySettings = _settingService.LoadSetting<SecuritySettings>();
                result.ExpiresIn = securitySettings.TokenLifeTime;
                result.AccessToken = TokenHelper.CreateToken(_tokenValidation.GetEncryptKey(),
                    result.ExpiresIn, new Ticket()
                    {
                        UserId = Employee.Id,
                        Claims = user.Claims
                    });
                result.RefreshToken = Employee.RefreshToken = $"{Employee.Id}.{Guid.NewGuid()}";
                await _dataContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task<TokenResponse> Refresh(string refreshToken)
        {
            var result = new TokenResponse();

            var EmployeeId = int.Parse(refreshToken.Split('.').First());
            var Employee = _dataContext.Employees.Find(EmployeeId);
            if (Employee == null || !Employee.User.Active || refreshToken != Employee.RefreshToken) return result;
            var securitySettings = _settingService.LoadSetting<SecuritySettings>();
            result.ExpiresIn = securitySettings.TokenLifeTime;
            result.AccessToken = TokenHelper.CreateToken(_tokenValidation.GetEncryptKey(),
                result.ExpiresIn, new Ticket()
                {
                    UserId = Employee.Id,
                    Claims = Employee.User.UserClaims.ToDictionary(x=>x.ClaimName, y=>y.ClaimValue)
                });
            result.RefreshToken = Employee.RefreshToken = $"{Employee.Id}.{Guid.NewGuid()}";
            await _dataContext.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// Validate user for web
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Ticket> Validate(string userName, string password)
        {
            var result = new Ticket();
            var user = _dataContext.Users.AsNoTracking().Include(x => x.UserClaims)
                .FirstOrDefault(x => x.UserName == userName && x.Active);
            //check password
            if (user == null
                || user.Password != _encryptionService.CreatePasswordHash(password, user.Salt)) return result;
            //find user claims
            result.UserId = user.Id;
            result.Claims = user.UserClaims.ToDictionary(x => x.ClaimName, x => x.ClaimValue);
            var roles = user.Roles.Split(SharedValues.Delimiter);
            foreach (var role in roles)
            {
                //default claims of the role
                var systemRole = await GetRole(role);
                if (systemRole == null) throw new Exception("Invalid role" + role);
                var rolePermissions = systemRole.Permissons.Split(SharedValues.Delimiter);
                foreach (var permission in rolePermissions)
                {
                    if (!result.Claims.ContainsKey(permission))
                    {
                        result.Claims.Add(permission, "");
                    }
                }
            }
            return result;
        }


        public async Task<bool> ChangePassword(int EmployeeId, string password)
        {
            var Employee = _dataContext.Employees.FirstOrDefault(f => f.Id == EmployeeId);
            if (Employee == null) return false;
            var user = _dataContext.Users
                .FirstOrDefault(x => x.Id == Employee.UserId && x.Active);
            if (user == null) return false;
            var salt = _encryptionService.CreateSaltKey(SaltLenght);
            user.Salt = salt;
            user.Password = _encryptionService.CreatePasswordHash(password, salt);
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Role> GetRole(string name)
        {
            return (await GetAll()).FirstOrDefault(x => x.SystemName == name);
        }
        public async Task<Role[]> GetAll()
        {
            var settings = _settingService.LoadSetting<SystemSettings>();
            return await _cacheManager.GetAsync(AllRolesKey,
                async () =>
                    await _dataContext.Roles.AsNoTracking().Where(x => x.Active).ToArrayAsync()
                , settings.CacheLong);
        }

        public List<string> GetClaimByUserId(int id)
        {
            var claim = new List<string>();
            var user = _dataContext.Users.Find(id);
            if (user == null || user.Deleted)
                return claim;
            var role = user.Roles.SplitIds();

            foreach (var r in role)
            {
                var systemRole = _dataContext.Roles.AsNoTracking().FirstOrDefault(d => d.SystemName == r);
                if (systemRole == null) throw new Exception("Invalid role" + role);
                var rolePermissions = systemRole.Permissons.SplitIds();
                foreach (var permission in rolePermissions)
                {
                    claim.Add(permission);
                }
            }

            return claim.Distinct().ToList();
        }
    }
}
