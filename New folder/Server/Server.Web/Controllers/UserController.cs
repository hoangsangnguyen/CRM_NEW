using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Falcon.Web.Mvc.Security;
using Vino.Server.Services.MainServices.Auth;
using Vino.Server.Web.Models.User;

namespace Vino.Server.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserAuthService _userAuthService;

        public UserController(UserAuthService userAuthService)
        {
            this._userAuthService = userAuthService;
        }

        public ActionResult Login(string returnUrl = "")
        {
            return View(new LoginModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var ticket = await _userAuthService.Validate(model.UserName, model.Password);
                if (ticket.UserId > 0)
                {
                    //log user in
                    ticket.IsPersistent = model.RememberMe;
                    int cookieExpires = 24 * 365; //TODO make configurable
                    ticket.Expiration = DateTime.Now.AddHours(cookieExpires);
                    var encryptedTicket = new WebContextHelper().CreateCookie(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.HttpOnly = true;
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    cookie.Secure = FormsAuthentication.RequireSSL;
                    cookie.Path = FormsAuthentication.FormsCookiePath;
                    if (FormsAuthentication.CookieDomain != null)
                    {
                        cookie.Domain = FormsAuthentication.CookieDomain;
                    }
                    Response.Cookies.Add(cookie);
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "Mật khẩu hoặc tài khoản không hợp lệ");
            }
            //error
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Recover()
        {
            return null;
        }

        public ActionResult Account()
        {
            return View();
        }

    }
}