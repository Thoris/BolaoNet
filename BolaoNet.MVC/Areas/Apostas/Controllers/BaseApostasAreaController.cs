using BolaoNet.MVC.Controllers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class BaseApostasAreaController : BaseBolaoController
    {
        #region Properties

        #endregion
        
        #region Constructors/Destructors

        public BaseApostasAreaController(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base
            (
                campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp
            )
        {

        }

        #endregion
    }
}