using AutoMapper;
using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;
        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;

        #endregion

        #region Constructors/Destructors

        public AccountController(
            Application.Interfaces.Users.IUserApp userApp, 
            Application.Interfaces.Users.IUserInRoleApp userInRoleApp, 
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp, 
            Application.Interfaces.Boloes.IBolaoApp bolaoApp, 
            Application.Interfaces.Notification.INotificationApp notificationApp
            )
        {
            _userApp = userApp;
            _userInRoleApp = userInRoleApp;
            _notificationApp = notificationApp;
            _bolaoMembroApp = bolaoMembroApp;
            _bolaoApp = bolaoApp; 
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
            
            //Buscando a lista de bolões do usuário
            IList<Domain.Entities.Boloes.BolaoMembro> list =
                _bolaoMembroApp.GetListBolaoInUsers(new Domain.Entities.Users.User(model.UserName));

            if (list.Count == 1)
            {
                Domain.Entities.Boloes.Bolao bolaoLoaded =
                    _bolaoApp.Load(new Domain.Entities.Boloes.Bolao(list[0].NomeBolao));
                
                Persist.Put<string>(BaseBolaoController.PersistNomeBolaoSelected, bolaoLoaded.Nome);
                Persist.Put<string>(BaseBolaoController.PersistNomeCampeonatoSelected, bolaoLoaded.NomeCampeonato);
                
                if (bolaoLoaded.IsIniciado == true)
                    Persist.Put<bool>(BaseBolaoController.PersistIsBolaoIniciado, true);
                else
                    Persist.Put<bool>(BaseBolaoController.PersistIsBolaoIniciado, false);
            }


            //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            //return RedirectToAction("Index", "Home");

            if (string.IsNullOrEmpty(returnUrl))
            {
                return new RedirectToRouteResult(new                   
                   RouteValueDictionary(new { 
                       area="Users", 
                       controller = "AccountHome", 
                       action = "Index" 
                   }));
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
                ModelState.AddModelError("", "Usuário e/ou email não encontrado(s).");
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
            IList<Domain.Entities.Boloes.Bolao> list = _bolaoApp.GetBoloesDisponiveis();

            bool foundBolaoDisponivel = false;

            for (int c = 0; c < list.Count; c++ )
            {
                if (list[c].IsIniciado == false || list[c].IsIniciado == null)
                {
                    foundBolaoDisponivel = true;
                    break;
                }
            }

            if (!foundBolaoDisponivel)
            {
                return RedirectToAction("RegistrationFormNoBolao");
            }
            ViewModels.Account.RegistrationUserViewModel model = new ViewModels.Account.RegistrationUserViewModel();
            model.ReceiveEmails = true;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationForm(ViewModels.Account.RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            if (string.Compare (model.Email, model.ConfirmacaoEmail, true) != 0)
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



            Domain.Entities.Users.Role[] roles = {
                                                  new Domain.Entities.Users.Role("Apostador"),
                                                  new Domain.Entities.Users.Role("Convidado"),
                                                  new Domain.Entities.Users.Role("Visitante de Bolão"),
                                                  new Domain.Entities.Users.Role("Visitante de Campeonato"),
                                               };

            for (int c=0; c < roles.Length; c++)
            {                
                _userInRoleApp.Insert(new Domain.Entities.Users.UserInRole(data.UserName, roles[c].RoleName));
            }

            string codeGenerated = _userApp.GenerateActivationCode(data);
            data.ActivateKey = codeGenerated;


            string sourceProfileImage = "~/Content/img/profile_small.jpg";
            string targetProfileImage = "~/Content/img/database/profiles/" + data.UserName + ".gif";

            targetProfileImage = Server.MapPath(targetProfileImage);
            if (System.IO.File.Exists(targetProfileImage))
                System.IO.File.Delete(targetProfileImage);

            //System.IO.File.Copy(Server.MapPath(sourceProfileImage), Server.MapPath(targetProfileImage));
            System.IO.File.Copy(Server.MapPath(sourceProfileImage), targetProfileImage);

            _notificationApp.NotifyActivationCode(data);

           


            return RedirectToAction("RegistrationFormSent", model);
        }
        public ActionResult RegistrationFormSent(ViewModels.Account.RegistrationUserViewModel model)
        {
            return View(model);
        }
        public ActionResult RegistrationFormNoBolao()
        {
            return View();
        }

        [HttpGet]        
        public ActionResult ActivateCode(string login, string key)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(key))
            {
                ViewModels.Account.ActivationCodeViewModel model = new ViewModels.Account.ActivationCodeViewModel();
                model.ActivateKey = key.Trim();
                model.UserName = login;

                return ActivateCode(model);
            }

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

            ValidationResult result = _userApp.ApproveUser(data, model.ActivateKey.Trim());

            if (!result.IsValid)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Message);
                return View();
            }

            Domain.Entities.Users.User user = _userApp.Load(data);

            IList<Domain.Entities.Boloes.Bolao> bolaoList = _bolaoApp.GetAll().ToList();

            for (int c = 0; c < bolaoList.Count; c++ )
            {
                if (bolaoList[c].IsIniciado != true)
                {
                    Domain.Entities.Boloes.BolaoMembro bolaoMembro = 
                        new Domain.Entities.Boloes.BolaoMembro(user.UserName, bolaoList[c].Nome);
                    
                    if (_bolaoMembroApp.Load (bolaoMembro) == null)
                    {
                        _bolaoMembroApp.Insert(bolaoMembro);
                    }
                }
            }

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
                //return RedirectToAction("Index", "Home", new { });
                return RedirectToAction("Index", "AccountHome", new { area = "Users" });
            }
        }
      
        public ActionResult ConfigCulture(string culture)
        {

            base.SetCulture(culture);
            return RedirectToAction("Login");
        }


        #endregion
    }
}