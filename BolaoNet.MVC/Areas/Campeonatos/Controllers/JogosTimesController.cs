using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class JogosTimesController: BaseCampeonatoAreaController
    {
        #region Constructors/Destructors

        public JogosTimesController(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
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