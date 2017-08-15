using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Areas.Testes.Controllers
{ 
    public class BaseTestesAreaController : BaseController
    {
        #region Variables

        protected Application.Interfaces.Testes.ITestesApp _testesApp;

        #endregion

        #region Constructors/Destructors

        public BaseTestesAreaController(Application.Interfaces.Testes.ITestesApp testesApp)
        {
            _testesApp = testesApp;
        }

        #endregion
    }
}