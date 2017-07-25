using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class BaseUserAreaController : AuthorizationController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;

        #endregion

        #region Constructors/Destructors

        public BaseUserAreaController(
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp
            )
        {
            _bolaoApp = bolaoApp;
            _bolaoMembroApp = bolaoMembroApp;
        }

        #endregion

        #region Methods

        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!IsCheckSelectedBolao(_bolaoMembroApp, _bolaoApp))
            {

            }
        }

        #endregion

    }
}