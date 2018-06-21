using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Falcon.Web.Core.Helpers;
using Falcon.Web.Mvc.Kendoui;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.Constants;
using Vino.Server.Services.Helper;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Services.MainServices.Users;
using Vino.Server.Services.MainServices.Users.Models;
using Vino.Server.Web.Areas.Admin.Models.FaclonUser;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class FalconUserController : BaseController
    {

        private readonly UserService _userService;

        //private readonly UserAuthService _userAuthService;
        //private readonly WebContext _webContext;
        //private readonly RoleService _roleService;
        //private readonly HospitalService _hospitalService;

        public FalconUserController(UserService userService)
        {
            _userService = userService;
        }


        #region User
        public ActionResult UserList()
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            return View(new UserListModel());
        }

        [HttpPost]
        public async Task<ActionResult> UserList(DataSourceRequest common, UserListModel model)
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            var user = await _userService.SearchUser(new SearchUserRequest()
            {
                Page = common.Page - 1,
                PageSize = common.PageSize,
                DisplayName = model.Display,
                UserName = model.Username,
                Role = model.Role
            });
            var gridModel = new DataSourceResult()
            {
                Data = user,
                Total = user.TotalCount
            };
            return Json(gridModel);
        }

        public ActionResult UserCreate()
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            return View(new UserModel());
        }
        [HttpPost]
        public async Task<ActionResult> UserCreate(UserModel model)
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            if (!ModelState.IsValid) return View(model);
            var result = await _userService.Create(model.UserName, model.Password,
                    model.RoleList.ToList(), model.DisplayName);
            if (!result.IsOk)
            {
                ErrorNotification(result.ErrorDescription);
                return View(model);
            }
            SuccessNotification("Thêm thành công!");
            return model.ContinueEditing
                ? RedirectToAction("UserEdit", new { id = result.ReturnId })
                : RedirectToAction("UserList");
        }

        public async Task<ActionResult> UserEdit(int id)
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            var user = await _userService.GetUserById(id);
            if (user == null) return RedirectToAction("UserList");


            var model = user.MapTo<UserModel>();
            //if (user.Roles.SplitIds().Any(d => d == ServerPermissions.Manager || d == ServerPermissions.Operator))
            //    model.HospitalId = (await _userService.GetHospitalByUserId(user.Id)).Id;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> UserEdit(UserModel model)
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            var user = await _userService.GetUserById(model.Id);
            if (user == null) return RedirectToAction("UserList");
            ModelState["Password"]?.Errors?.Clear();
            if (!ModelState.IsValid) return View(model);

            if (model.ChangePassword)
            {
                await _userService.ChangePassword(user.Id, model.Password);
            }
            await _userService.UpdateUser(model);
            //if (!_hospitalService.CheckUserHospital(model.RoleList.ToList()) &&
            //    !_hospitalService.CheckUserHospital(user.Roles.SplitIds().ToList()))
            //{
            //    //await _userService.InsertUserHospital(new UserHospitalModel()
            //    //{
            //    //    UserId = user.Id,
            //    //    HospitalId = model.Id,
            //    //});
            //    await _userService.UpdateUser(model);
            //}
            //else if (_hospitalService.CheckUserHospital(model.RoleList.ToList()) &&
            //         !_hospitalService.CheckUserHospital(user.Roles.SplitIds().ToList()))
            //{
            //    await _userService.InsertUserHospital(new UserHospitalModel()
            //    {
            //        UserId = user.Id,
            //        HospitalId = model.HospitalId,
            //    });
            //    await _userService.UpdateUser(model);
            //}
            //else if (!_hospitalService.CheckUserHospital(model.RoleList.ToList()) &&
            //         _hospitalService.CheckUserHospital(user.Roles.SplitIds().ToList()))
            //{
            //    await _userService.DeleteUserHospitalByUserId(user.Id);
            //    await _userService.UpdateUser(model);
            //}
            //else
            //{
            //    await _userService.UpdateUserHospital(model);
            //}

            SuccessNotification("Chỉnh sửa thành công!");
            return model.ContinueEditing
                ? RedirectToAction("UserEdit")
                : RedirectToAction("UserList");
        }

        [HttpPost]
        public async Task<ActionResult> UserDelete(int id)
        {
            //if (_userAuthService.GetClaimByUserId(_webContext.UserId)
            //    .All(d => d != ServerPermissions.ManageFalconUsers))
            //{
            //    ErrorNotification("Bạn không có quyền truy cập");
            //    if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            //}

            var user = await _userService.GetUserById(id);
            if (user == null) return RedirectToAction("UserList");

            await _userService.DeleteUser(id);
            SuccessNotification("Xóa thành công!");
            return RedirectToAction("UserList");
        }


        #endregion

        //#region User hospital

        //public ActionResult UserHospitalList()
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageUserHospital))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    return View(new UserHospitalListModel());
        //}

        //[HttpPost]
        //public async Task<ActionResult> UserHospitalList(DataSourceRequest common, UserHospitalListModel model)
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageUserHospital))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    var userHospital = await _userService.SearchUserHospital(new SearchUserHospitalRequest()
        //    {
        //        Page = common.Page - 1,
        //        PageSize = common.PageSize,
        //        UserName = model.UserName,
        //        HospitalId = model.HospitalId
        //    });
        //    var gridModel = new DataSourceResult()
        //    {
        //        Data = userHospital,
        //        Total = userHospital.TotalCount
        //    };
        //    return Json(gridModel);
        //}

        ////public ActionResult UserHospitalCreate()
        ////{
        ////    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        ////        .All(d => d != ServerPermissions.ManageUserHospital))
        ////    {
        ////        ErrorNotification("Bạn không có quyền truy cập");
        ////        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        ////    }

        ////    return View(new UserHospitalModel());
        ////}
        ////[HttpPost]
        ////public async Task<ActionResult> UserHospitalCreate(UserHospitalModel model)
        ////{
        ////    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        ////        .All(d => d != ServerPermissions.ManageUserHospital))
        ////    {
        ////        ErrorNotification("Bạn không có quyền truy cập");
        ////        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        ////    }

        ////    if (!ModelState.IsValid) return View(model);
        ////    await _userService.InsertUserHospital(model);
        ////    SuccessNotification("Thêm thành công!");
        ////    return model.ContinueEditing
        ////        ? RedirectToAction("UserHospitalEdit")
        ////        : RedirectToAction("UserHospitalList");
        ////}

        ////public async Task<ActionResult> UserHospitalEdit(int id)
        ////{
        ////    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        ////        .All(d => d != ServerPermissions.ManageUserHospital))
        ////    {
        ////        ErrorNotification("Bạn không có quyền truy cập");
        ////        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        ////    }

        ////    var userHospital = await _userService.GetUserHospitalById(id);
        ////    if (userHospital == null) return RedirectToAction("UserHospitalList");

        ////    var model = userHospital.MapTo<UserHospitalModel>();

        ////    return View(model);
        ////}
        ////[HttpPost]
        ////public async Task<ActionResult> UserHospitalEdit(UserHospitalModel model)
        ////{
        ////    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        ////        .All(d => d != ServerPermissions.ManageUserHospital))
        ////    {
        ////        ErrorNotification("Bạn không có quyền truy cập");
        ////        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        ////    }

        ////    var userHospital = await _userService.GetUserHospitalById(model.Id);
        ////    if (userHospital == null) return RedirectToAction("UserHospitalList");
        ////    if (!ModelState.IsValid) return View(model);

        ////    await _userService.UpdateUserHospital(model);
        ////    SuccessNotification("Chỉnh sửa thành công!");
        ////    return model.ContinueEditing
        ////        ? RedirectToAction("UserHospitalEdit")
        ////        : RedirectToAction("UserHospitalList");
        ////}

        ////[HttpPost]
        ////public async Task<ActionResult> UserHospitalDelete(int id)
        ////{
        ////    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        ////        .All(d => d != ServerPermissions.ManageUserHospital))
        ////    {
        ////        ErrorNotification("Bạn không có quyền truy cập");
        ////        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        ////    }

        ////    var userHospital = await _userService.GetUserHospitalById(id);
        ////    if (userHospital == null) return RedirectToAction("UserHospitalList");

        ////    await _userService.DeleteUserHospital(id);
        ////    SuccessNotification("Xóa thành công!");
        ////    return RedirectToAction("UserHospitalList");
        ////}

        //#endregion

        //#region operator 
        //public ActionResult OperatorList()
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    return View(new OperatorListModel());
        //}

        //[HttpPost]
        //public async Task<ActionResult> OperatorList(DataSourceRequest common, OperatorListModel model)
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    var Operator = await _userService.SearchUser(new SearchUserRequest()
        //    {
        //        Page = common.Page - 1,
        //        PageSize = common.PageSize,
        //        DisplayName = model.DisplayName,
        //        UserName = model.DisplayName,
        //        Role = ServerPermissions.Operator,
        //        HospitalId = (await _userService.GetHospitalByUserId(_webContext.UserId)).Id
        //    });
        //    var gridModel = new DataSourceResult()
        //    {
        //        Data = Operator,
        //        Total = Operator.TotalCount
        //    };
        //    return Json(gridModel);
        //}

        //public async Task<ActionResult> OperatorCreate()
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    if (!await CheckUserHospital())
        //        return RedirectToAction("OperatorList");

        //    return View(new UserModel());
        //}
        //[HttpPost]
        //public async Task<ActionResult> OperatorCreate(UserModel model)
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }
        //    if (!await CheckUserHospital())
        //        return RedirectToAction("OperatorList");

        //    if (!ModelState.IsValid) return View(model);

        //    model.HospitalId = (await _userService.GetHospitalByUserId(_webContext.UserId)).Id;
        //    var result = await _userService.InsertOperator(model);
        //    if (!result.IsOk)
        //    {
        //        ErrorNotification(result.ErrorDescription);
        //        return View(model);
        //    }
        //    SuccessNotification("Thêm thành công!");
        //    return model.ContinueEditing
        //        ? RedirectToAction("OperatorEdit", new {id = model.Id})
        //        : RedirectToAction("OperatorList");
        //}

        //public async Task<ActionResult> OperatorEdit(int id)
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    if (!await CheckUserHospital())
        //        return RedirectToAction("OperatorList");

        //    var Operator = await _userService.GetUserById(id);
        //    if (Operator == null) return RedirectToAction("OperatorList");

        //    var model = Operator.MapTo<UserModel>();

        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<ActionResult> OperatorEdit(UserModel model)
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }

        //    if (!await CheckUserHospital())
        //        return RedirectToAction("OperatorList");

        //    var Operator = await _userService.GetUserById(model.Id);
        //    if (Operator == null) return RedirectToAction("OperatorList");

        //    ModelState["Password"].Errors.Clear();
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.ChangePassword)
        //        await _userService.ChangePassword(Operator.Id, model.Password);
        //    model.RoleList = new List<string>(){ServerPermissions.Operator};
        //    await _userService.UpdateUser(model);
        //    SuccessNotification("Chỉnh sửa thành công!");
        //    return model.ContinueEditing
        //        ? RedirectToAction("OperatorEdit")
        //        : RedirectToAction("OperatorList");
        //}

        //[HttpPost]
        //public async Task<ActionResult> OperatorDelete(int id)
        //{
        //    if (_userAuthService.GetClaimByUserId(_webContext.UserId)
        //        .All(d => d != ServerPermissions.ManageOperator))
        //    {
        //        ErrorNotification("Bạn không có quyền truy cập");
        //        if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
        //    }
        //    if (!await CheckUserHospital())
        //        return RedirectToAction("OperatorList");

        //    var Operator = await _userService.GetUserById(id);
        //    if (Operator == null) return RedirectToAction("OperatorList");

        //    await _userService.DeleteOperator(id);
        //    SuccessNotification("Xóa thành công!");
        //    return RedirectToAction("OperatorList");
        //}
        //#endregion
        //private async Task<bool> CheckUserHospital()
        //{
        //    var hospital = await _userService.GetHospitalByUserId(_webContext.UserId);
        //    if (hospital.Id > 0) return true;
        //    ErrorNotification("Người dùng chưa thuộc bệnh viện nào!");
        //    return false;
        //}
    }
}