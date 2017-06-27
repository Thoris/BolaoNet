using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseBolaoController : BaseCampeonatoController
    {
        #region Constants

        public const string PersistNomeBolaoSelected = "NomeBolaoSelected";

        #endregion

        #region Properties



        #endregion

        #region Constructors/Destructors

        public BaseBolaoController (
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
            LoadCampeonatoData();
        }

        #endregion
    }
}