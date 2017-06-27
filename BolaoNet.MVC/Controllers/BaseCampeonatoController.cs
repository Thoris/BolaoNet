using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseCampeonatoController : AuthorizationController
    {
        #region Constants

        public const string PersistNomeCampeonatoSelected = "NomeCampeonatoSelected";

        #endregion

        #region Variables

        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoFaseApp _campeonatoFaseApp;
        private Application.Interfaces.Campeonatos.ICampeonatoGrupoApp _campeonatoGrupoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoTimeApp _campeonatoTimeApp;

        #endregion

        #region Properties

        protected ViewModels.Base.CampeonatoDataVO CampeonatoData { get; set; }
        protected Application.Interfaces.Campeonatos.ICampeonatoApp CampeonatoApp 
        {
            get 
            { 
                return _campeonatoApp; 
            } 
        }
        protected Application.Interfaces.Campeonatos.ICampeonatoFaseApp CampeonatoFaseApp
        {
            get
            {
                return _campeonatoFaseApp;
            }
        }
        protected Application.Interfaces.Campeonatos.ICampeonatoGrupoApp CampeonatoGrupoApp
        {
            get
            {
                return _campeonatoGrupoApp;
            }
        }
        protected Application.Interfaces.Campeonatos.ICampeonatoTimeApp CampeonatoTimeApp
        {
            get 
            { 
                return _campeonatoTimeApp; 
            } 
        }
        #endregion

        #region Constructors/Destructors

        public BaseCampeonatoController(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
        {
            _campeonatoApp = campeonatoApp;
            _campeonatoFaseApp = campeonatoFaseApp;
            _campeonatoGrupoApp = campeonatoGrupoApp;
            _campeonatoTimeApp = campeonatoTimeApp;
        }

        #endregion

        #region Methods

        protected void LoadCampeonatoData()
        {
            if (string.IsNullOrEmpty(SelectedNomeCampeonato))
            {
                if (this.CampeonatoData == null)
                    this.CampeonatoData = new ViewModels.Base.CampeonatoDataVO();
                return;
            }

            this.CampeonatoData = base.Persist.Get<ViewModels.Base.CampeonatoDataVO>("CampeonatoData");


            if (this.CampeonatoData == null || string.Compare (this.SelectedNomeCampeonato, this.CampeonatoData.NomeCampeonato, true) != 0)
            {
                this.CampeonatoData = new Helpers.CampeonatoDataLoader(
                    _campeonatoApp,
                    _campeonatoFaseApp,
                    _campeonatoGrupoApp,
                    _campeonatoTimeApp
                    ).LoadCampeonatoData(this.SelectedCampeonato);


                base.Persist.Put<ViewModels.Base.CampeonatoDataVO>("CampeonatoData", this.CampeonatoData);
            }
        }

        #endregion
    }
}