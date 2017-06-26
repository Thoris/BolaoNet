using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseBolaoController : BaseCampeonatoController
    {
        #region Properties

        protected string SelectedNomeBolao
        {
            get
            {
                return base.Persist.Get<string>("SelectedBolao");
            }
            set
            {
                base.Persist.Put<string>("SelectedBolao", value);
            }
        }
        protected Domain.Entities.Boloes.Bolao SelectedBolao
        {
            get
            {
                return new Domain.Entities.Boloes.Bolao(this.SelectedNomeBolao)
                {
                    NomeCampeonato = base.SelectedNomeCampeonato
                };
            }
        }

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

        }

        #endregion
    }
}