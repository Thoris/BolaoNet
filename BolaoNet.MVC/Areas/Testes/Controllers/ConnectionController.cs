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

        public ActionResult Index()
        {
            return View();
        }

        #endregion

    }
}