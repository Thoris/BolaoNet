using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{ 
    public abstract class AuthorizationController : AuthenticationController
    {
        #region Constructors/Destructors

        public AuthorizationController()
        {
        }

        #endregion

        #region Methods

        public bool IsUserInRole(PermissionLevel level)
        {

            CustomUserPrincipal user = this.HttpContext.User as CustomUserPrincipal;
            if (user != null)
            {
                return false;
            }
            string desc = PermissionLevelDesc.Levels[(int)level];

            return user.IsInRole(desc);

        }
        public bool IsUserInRole(PermissionLevel [] levels)
        {
            CustomUserPrincipal user = this.HttpContext.User as CustomUserPrincipal;

            if (user != null)
            {
                for (int c=0; c < levels.Length; c++)
                {
                    string desc = PermissionLevelDesc.Levels[(int)levels[c]];

                    if (user.IsInRole(desc))
                        return true;
                }
                //user.Roles
            }

            return false;
        }

        //http://www.dotnettricks.com/learn/mvc/custom-authentication-and-authorization-in-aspnet-mvc

        protected bool IsCheckSelectedBolao(Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp, Application.Interfaces.Boloes.IBolaoApp bolaoApp)
        {
            if (string.IsNullOrEmpty(base.SelectedNomeBolao))
            {
                IList<Domain.Entities.Boloes.BolaoMembro> list =
                    bolaoMembroApp.GetListBolaoInUsers(base.UserLogged);

                if (list.Count == 1)
                {
                    this.SelectedNomeBolao = list[0].NomeBolao;

                    Domain.Entities.Boloes.Bolao bolaoLoaded = bolaoApp.Load(base.SelectedBolao);

                    this.SelectedNomeCampeonato = bolaoLoaded.NomeCampeonato;
                    this.IsBolaoIniciado = bolaoLoaded.IsIniciado == true ? true : false;

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}