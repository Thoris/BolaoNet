using AutoMapper;
using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class AccessController : BaseUserController
    {
        #region Variables

        private Application.Users.UserApp _userApp;

        #endregion

        #region Constructors/Destructors

        public AccessController(Application.Users.UserApp userApp)
        {
            _userApp = userApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Login()
        {
            //int timeout = rememberMe ? 525600 : 30; // Timeout in minutes, 525600 = 365 days.
            //var ticket = new FormsAuthenticationTicket(userName, rememberMe, timeout);
            //string encrypted = FormsAuthentication.Encrypt(ticket);
            //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            //cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
            //cookie.HttpOnly = true; // cookie not available in javascript.
            //Response.Cookies.Add(cookie);



            ViewModels.Users.LoginViewModel model = new ViewModels.Users.LoginViewModel();


            //if (!string.IsNullOrEmpty(Response.Cookies["userName"].Value))
            //    model.UserName = Response.Cookies["userName"].Value;
            //if (!string.IsNullOrEmpty(Response.Cookies["Password"].Value))
            //    model.Password = Response.Cookies["Password"].Value;


            return View(model);
        }
        [HttpPost]
        public ActionResult Login(ViewModels.Users.LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ValidationResult res = _userApp.Login(model.UserName, model.Password);

            if (!res.IsValid)
            {
                ModelState.AddModelError("", res.Errors.FirstOrDefault().Message);
                return View();
            }

            //if (model.RememberMe)
            //{
            //    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);

                
            //    Response.Cookies["UserName"].Value = model.UserName;
            //    Response.Cookies["Password"].Value = model.Password;
            //}
            //else
            //{
            //    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            //}


            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");  
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegistrationForm()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegistrationForm(ViewModels.Users.RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Domain.Entities.Users.User data = Mapper.Map<ViewModels.Users.RegistrationUserViewModel, Domain.Entities.Users.User>(model); 

            //_userApp.RegisterUser()

            return View();
        }

        public ActionResult ActivateCode()
        {
            return View();
        }

        #endregion
    }
}