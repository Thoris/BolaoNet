using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class BaseCampeonatoAreaController : BaseCampeonatoController
    {
        #region Constructors/Destructors

        public BaseCampeonatoAreaController(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
        }

        #endregion
    }
}