using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Controllers
{
    public class DivulgacaoController : BaseController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoHistoricoApp _bolaoHistoricoApp;
        private Application.Interfaces.Boloes.IBolaoRegraApp _bolaoRegraApp;

        #endregion

        #region Constructors/Destructors

        public DivulgacaoController(Application.Interfaces.Boloes.IBolaoHistoricoApp bolaoHistoricoApp, Application.Interfaces.Boloes.IBolaoRegraApp bolaoRegraApp)
        {
            _bolaoHistoricoApp = bolaoHistoricoApp;
            _bolaoRegraApp = bolaoRegraApp;
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            ViewModels.Account.DivulgacaoViewModel viewModel = new ViewModels.Account.DivulgacaoViewModel();

            return View(viewModel);
        }

        #endregion
    }
}