using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    public class LogViewerController : BaseAdminAreaController
    {
        #region Variables

        private Application.Interfaces.LogReporting.ILogReportingApp _logReportingApp;

        #endregion

        #region Constructors/Destructors

        public LogViewerController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.LogReporting.ILogReportingApp logReportingApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _logReportingApp = logReportingApp;
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