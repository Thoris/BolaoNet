using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseCampeonatoController : AuthorizationController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoFaseApp _campeonatoFaseApp;
        private Application.Interfaces.Campeonatos.ICampeonatoGrupoApp _campeonatoGrupoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoTimeApp _campeonatoTimeApp;

        #endregion

        #region Properties

        protected string SelectedNomeCampeonato 
        {
            get
            {
                return base.Persist.Get<string>("SelectedCampeonato");
            }
            set
            {
                base.Persist.Put<string>("SelectedCampeonato", value);
            }
        }
        protected Domain.Entities.Campeonatos.Campeonato SelectedCampeonato
        {
            get
            {
                if (string.IsNullOrEmpty(this.SelectedNomeCampeonato))
                    return null;
                else
                {
                    return new Domain.Entities.Campeonatos.Campeonato(this.SelectedNomeCampeonato);
                }
            }
        }
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
            if (CampeonatoData == null)
            {
                this.CampeonatoData = new Helpers.CampeonatoDataLoader(
                    _campeonatoApp,
                    _campeonatoFaseApp,
                    _campeonatoGrupoApp,
                    _campeonatoTimeApp
                    ).LoadCampeonatoData(this.SelectedCampeonato);
            }
        }

        #endregion
    }
}