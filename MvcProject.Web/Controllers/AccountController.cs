using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;
using MvcProject.Core.Domain.Entity;
using MvcProject.Data.UnitOfWork;
using MvcProject.Service.Users;
using MvcProject.Web.Models.AccountModels;

namespace MvcProject.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IUnitOfWork uow)
            : base(uow)
        {
            _userService = userService;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User
                    {
                        ConfirmationId = Guid.NewGuid(),
                        DisplayName = model.UserName,
                        IsConfirmed = false,
                        LastLoginDate = DateTime.Now,
                        LastLoginIp = Request.UserHostAddress,
                        Password = model.Password,
                        ProfileImageUrl = "Content/Images/no_profile_image.png",
                        Email = model.Email,
                        UserName = model.UserName,
                        IsActive = false,
                        IsEditable = true,
                        IsDeletable = true
                    };

                    _userService.Insert(user);
                    _uow.SaveChanges();
                    _userService.SendConfirmationMail(user.Id, user.Email, Request.Url.GetLeftPart(UriPartial.Authority));

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Kullanıcı oluşturma başarısız!");
                }
            }

            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            bool isValidUser = _userService.ValidateUser(model.UserName, model.Password);
            if (ModelState.IsValid && isValidUser != null)
            {
                if (!isValidUser)
                {
                    TempData["EpostaOnayMesaj"] = "E-posta adresiniz onaylı değildir. Lütfen e-posta adresinizdeki linki kullanarak e-posta adresinizi onaylayınız.";

                    return View();
                }
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı ve ya şifre geçersiz!");
            }

            return View(model);
        }

        // RegisterModel içerisindeki Email alanını
        // RemoteAttribute ile kontrol eder
        public JsonResult ValidateEmail(string email)
        {
            var result = _userService.ValidateEmail(email);

            if (result)
            {
                return Json("Girdiğiniz e-posta adresi sistemde zaten mevcut!", JsonRequestBehavior.AllowGet);
            }

            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        // RegisterModel içerisindeki UserName alanını
        // RemoteAttribute ile kontrol eder
        public JsonResult ValidateUserName(string userName)
        {
            var result = _userService.ValidateUserName(userName);

            if (result)
            {
                return Json("Girdiğiniz kullanıcı adı sistemde zaten mevcut!", JsonRequestBehavior.AllowGet);
            }

            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ConfirmUser(Guid confirmationId)
        {
            if (string.IsNullOrEmpty(confirmationId.ToString()) || (!Regex.IsMatch(confirmationId.ToString(),
                   @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}")))
            {
                TempData["EpostaOnayMesaj"] = "Hesap geçerli değil. Lütfen e-posta adresinizdeki linke tekrar tıklayınız.";

                return View();
            }
            else
            {
                var user = _userService.Find(confirmationId);

                if (!user.IsConfirmed)
                {
                    user.IsConfirmed = true;
                    _userService.Update(user);
                    _uow.SaveChanges();

                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    TempData["EpostaOnayMesaj"] = "E-posta adresinizi onayladığınız için teşekkürler. Artık sitemize üyesiniz.";

                    return RedirectToAction("Wellcome");
                }
                else
                {
                    TempData["EpostaOnayMesaj"] = "E-posta adresiniz zaten onaylı. Giriş yapabilirsiniz.";

                    return RedirectToAction("Login");
                }
            }
        }

        public ActionResult Wellcome()
        {
            return View();
        }

        #region private methods
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }
    }
}