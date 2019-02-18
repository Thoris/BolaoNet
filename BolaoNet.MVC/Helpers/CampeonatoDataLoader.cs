using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Helpers
{
    public class CampeonatoDataLoader
    {
        #region Variables

        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoFaseApp _campeonatoFaseApp;
        private Application.Interfaces.Campeonatos.ICampeonatoGrupoApp _campeonatoGrupoApp;
        private Application.Interfaces.Campeonatos.ICampeonatoTimeApp _campeonatoTimeApp;

        #endregion

        #region Constructors/Destructors

        public CampeonatoDataLoader(
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp, 
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp)
        {
            _campeonatoApp = campeonatoApp;
            _campeonatoFaseApp = campeonatoFaseApp;
            _campeonatoGrupoApp = campeonatoGrupoApp;
            _campeonatoTimeApp = campeonatoTimeApp;
        }

        #endregion

        #region Methods

        public ViewModels.Base.CampeonatoDataVO LoadCampeonatoData(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            ViewModels.Base.CampeonatoDataVO res = new ViewModels.Base.CampeonatoDataVO();

            IList<Domain.Entities.Campeonatos.CampeonatoFase> fases = _campeonatoFaseApp.GetFaseCampeonato(campeonato);
            res.NomeFases = new List<string>();
            for (int c = 0; c < fases.Count; c++)
                res.NomeFases.Add(fases[c].Nome);
            
            IList<Domain.Entities.Campeonatos.CampeonatoGrupo> grupos = _campeonatoGrupoApp.GetGruposCampeonato(campeonato);
            res.NomeGrupos = new List<string>();
            for (int c = 0; c < grupos.Count; c++)
                res.NomeGrupos.Add(grupos[c].Nome);
            
            IList<int> rodadas = _campeonatoApp.GetRodadasCampeonato(campeonato);
            res.Rodadas = rodadas;

            IList<Domain.Entities.Campeonatos.CampeonatoTime> times = _campeonatoTimeApp.GetTimesCampeonato(campeonato);
            res.NomeTimes = new List<string>();
            for (int c = 0; c < times.Count; c++)
                res.NomeTimes.Add(times[c].NomeTime);


            Domain.Entities.Campeonatos.Campeonato camp = _campeonatoApp.Load(campeonato);

            res.NomeCampeonato = campeonato.Nome;
            res.TipoCampeonato = camp.TipoCampeonato;

            return res;
        }

        #endregion
    }
}