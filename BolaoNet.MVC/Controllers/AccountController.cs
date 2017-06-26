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

        private Application.Interfaces.Users.IUserApp _userApp;
        private Application.Interfaces.Users.IUserInRoleApp _userInRoleApp;
        private Application.Interfaces.Notification.INotificationApp _notificationApp;

        #endregion

        #region Constructors/Destructors

        public AccountController(Application.Interfaces.Users.IUserApp userApp, Application.Interfaces.Users.IUserInRoleApp userInRoleApp, Application.Interfaces.Notification.INotificationApp notificationApp)
        //public AccountController(Application.Interfaces.Users.IUserApp userApp, Application.Interfaces.Users.IUserInRoleApp userInRoleApp)
        {
            _userApp = userApp;
            _userInRoleApp = userInRoleApp;
            _notificationApp = notificationApp;


            

            // _notificationApp = new Infra.Notification.Mail.MailNotification("");

            
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
 
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ViewModels.Account.ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            IList<Domain.Entities.Users.User> users = _userApp.SearchByUserNameEmail(model.UserName, model.Email);

            if (users == null || users.Count == 0)
            {
                ModelState.AddModelError("", "Usuário com o email de requisição não encontrado.");
                return View();
            }

            _notificationApp.NotifySendPassword(users[0]);


            return RedirectToAction("ForgotPasswordSent", model);
        }
        public ActionResult ForgotPasswordSent(ViewModels.Account.ForgotPasswordViewModel model)
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult RegistrationForm()
        {           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationForm(ViewModels.Account.RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.Compare (model.Email, model.ConfirmacaoEmail) != 0)
            {
                ModelState.AddModelError("", "Confirmação de email inválida.");
                return View();
            }
            if (string.Compare (model.Password, model.ConfirmPassword) != 0)
            {
                ModelState.AddModelError("", "Confirmação de senha inválida.");
                return View();
            }
            if (!model.ConcordoTermos)
            {
                ModelState.AddModelError("", "É necessário concordar com os termos para prosseguir.");
                return View();
            }


            Domain.Entities.Users.User data = Mapper.Map<ViewModels.Account.RegistrationUserViewModel, Domain.Entities.Users.User>(model);

            ValidationResult result = _userApp.RegisterUser(data);

            if (!result.IsValid)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Message);
                return View();
            }

            string codeGenerated = _userApp.GenerateActivationCode(data);
            data.ActivateKey = codeGenerated;


            _notificationApp.NotifyActivationCode(data);


            return RedirectToAction("RegistrationFormSent", model);
        }
        public ActionResult RegistrationFormSent(ViewModels.Account.RegistrationUserViewModel model)
        {
            return View(model);
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            Domain.Entities.Users.User data = Mapper.Map<ViewModels.Account.ActivationCodeViewModel, Domain.Entities.Users.User>(model);


            ValidationResult result = _userApp.ApproveUser(data, model.ActivateKey);


            if (!result.IsValid)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Message);
                return View();
            }

            Domain.Entities.Users.User user = _userApp.Load (data);


            _notificationApp.NotifyWelcome(user);

            
            return RedirectToAction("ActivateCodeSucessful", model);
        }
        public ActionResult ActivateCodeSucessful(ViewModels.Account.ActivationCodeViewModel model)
        {
            return View();
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


        #endregion
    }
}