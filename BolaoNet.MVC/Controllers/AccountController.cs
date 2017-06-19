﻿using AutoMapper;
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
        private Application.Users.UserInRoleApp _userInRoleApp;

        #endregion

        #region Constructors/Destructors

        public AccountController(Application.Users.UserApp userApp, Application.Users.UserInRoleApp userInRoleApp)
        {
            _userApp = userApp;
            _userInRoleApp = userInRoleApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Login()
        {         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ViewModels.Account.LoginViewModel model, string returnUrl)
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


            Domain.Entities.Users.User user = _userApp.Load(new Domain.Entities.Users.User(model.UserName));

            IList<Domain.Entities.Users.Role> roles = _userInRoleApp.GetRolesInUser(user);

            string[] roleStrings = null;
            if (roles.Count > 0)
            {
                roleStrings = new string[roles.Count];
                for (int c=0; c < roles.Count; c++)
                {
                    roleStrings[c] = roles[c].RoleName;
                }
            }

            Security.UserModelState userModel = new Security.UserModelState()
            {
                UserName = model.UserName,
                FirstName = user.FullName,
                LastName = "",
                Roles = roleStrings
            };
            
            Security.AuthenticationManagement.SaveAuthentication(Response, userModel, model.RememberMe);

            //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            //return RedirectToAction("Index", "Home");

            if (string.IsNullOrEmpty(returnUrl))
            {
                return new RedirectToRouteResult(new
                   RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            else
            {
                return RedirectToLocal(returnUrl);
            }
        }

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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ViewModels.Account.ForgotPasswordViewModel model)
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult RegistrationForm()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegistrationForm(ViewModels.Account.RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Domain.Entities.Users.User data = Mapper.Map<ViewModels.Account.RegistrationUserViewModel, Domain.Entities.Users.User>(model);

            //_userApp.RegisterUser()

            return View();
        }

        [HttpGet]        
        public ActionResult ActivateCode()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateCode(ViewModels.Account.ActivationCodeViewModel model)
        {
            return View();
        }

        #endregion
    }
}