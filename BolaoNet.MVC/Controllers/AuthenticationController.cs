
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BolaoNet.MVC.Controllers
{

    [AuthorizeRoles]
    public abstract class AuthenticationController : BaseController
    {
        #region Properties

        public bool IsBolaoIniciado
        {
            get
            {
                return Persist.Get<bool>(BaseBolaoController.PersistIsBolaoIniciado);
            }
            set
            {
                Persist.Put<bool>(BaseBolaoController.PersistIsBolaoIniciado, value);
            }
        }
        public string SelectedNomeBolao
        {
            get
            {
                return Persist.Get<string>(BaseBolaoController.PersistNomeBolaoSelected);
            }
            set
            {
                Persist.Put<string>(BaseBolaoController.PersistNomeBolaoSelected, value);
            }
        }
        protected Domain.Entities.Boloes.Bolao SelectedBolao
        {
            get
            {
                return new Domain.Entities.Boloes.Bolao(this.SelectedNomeBolao)
                {
                    NomeCampeonato = SelectedNomeCampeonato
                };
            }
        }
        public string SelectedNomeCampeonato
        {
            get
            {
                return Persist.Get<string>(BaseCampeonatoController.PersistNomeCampeonatoSelected);
            }
            set
            {
                Persist.Put<string>(BaseCampeonatoController.PersistNomeCampeonatoSelected, value);
            }
        }
        protected Domain.Entities.Campeonatos.Campeonato SelectedCampeonato
        {
            get
            {
                if (string.IsNullOrEmpty(this.SelectedNomeCampeonato))
                    return null;
                else
                {
                    return new Domain.Entities.Campeonatos.Campeonato(this.SelectedNomeCampeonato);
                }
            }
        }            
        protected virtual new CustomUserPrincipal User
        {
            get 
            {
                return HttpContext.User as CustomUserPrincipal; 
            }
        }
        public virtual Domain.Entities.Users.User UserLogged
        {
            get
            {
                if (this.User != null)
                {
                    return new Domain.Entities.Users.User(this.User.UserName)
                    {
                        FullName = this.User.FullName
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Constructors/Destructors

        public AuthenticationController()
        {

        }

        #endregion

        #region Actions

        public ActionResult Logout()
        {           
            FormsAuthentication.SignOut();

            Persist.Remove<string>(BaseBolaoController.PersistNomeBolaoSelected);
            Persist.Remove<string>(BaseBolaoController.PersistCampeonatoData);
            Persist.Remove<string>(BaseBolaoController.PersistNomeCampeonatoSelected);
            

            this.Persist.Clear();

            return RedirectToLocal("/Account/Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = ""});
            }
        }

        #endregion
    }
}