using AutoMapper;
using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace BolaoNet.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        #region Variables

        private Application.Users.UserApp _userApp;

        #endregion

        #region Constructors/Destructors

        public AccountController(Application.Users.UserApp userApp)
        {
            _userApp = userApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {         
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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


            Security.UserModelState userModel = new Security.UserModelState()
            {
                UserName = model.UserName,
                FirstName = "First Name",
                LastName = "last Name",
                Roles = new string[] { "Admin" }
            };
            
            Security.AuthenticationManagement.SaveAuthentication(Response, userModel, model.RememberMe);

            //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            //return RedirectToAction("Index", "Home");

            return new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Home", action = "Index" }));

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