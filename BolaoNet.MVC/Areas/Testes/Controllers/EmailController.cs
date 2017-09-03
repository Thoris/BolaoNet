using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Testes.Controllers
{
    public class EmailController : BaseTestesAreaController
    {

        #region Constructors/Destructors

        public EmailController(Application.Interfaces.Testes.ITestesApp testesApp)
            : base(testesApp)
        {

        }

        #endregion

        #region Actions 

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestNotification(ViewModels.Testes.TestesViewModel model)
        {
            bool res = _testesApp.TestNotifyWelcome(model.Password, model.Email);

            if (res)
                model.ResultDescription = "Email notificado com sucesso.";
            else
                model.ResultDescription = "Senha inválida";

            return View("Index", model);
        }
        #endregion
    }
}