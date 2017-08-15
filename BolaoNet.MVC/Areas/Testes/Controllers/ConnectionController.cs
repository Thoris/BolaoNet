using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Testes.Controllers
{
    public class ConnectionController : BaseTestesAreaController
    {
        #region Constructors/Destructors

        public ConnectionController(Application.Interfaces.Testes.ITestesApp testesApp)
            : base (testesApp)
        {

        }

        #endregion

        #region Actions

        public ActionResult Index(ViewModels.Testes.TestesViewModel model)
        {
            return View(model);
        }
        public ActionResult TestConnection()
        {
            ViewModels.Testes.TestesViewModel model = new ViewModels.Testes.TestesViewModel();

            bool res = _testesApp.TestConnection();

            model.ResultTestConnection = res;

            return View("Index", model);
        }
        public ActionResult GetCurrentDateTime()
        {
            ViewModels.Testes.TestesViewModel model = new ViewModels.Testes.TestesViewModel();

            DateTime res = _testesApp.GetCurrentDateTime();

            model.ResultCurrentDateTime = res;

            return View("Index", model);
   
        }


        #endregion

    }
}