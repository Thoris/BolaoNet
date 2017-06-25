using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class ApostasExtrasController : BaseApostasController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors

        public ApostasExtrasController(Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
                Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
                Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
                Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
                Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
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