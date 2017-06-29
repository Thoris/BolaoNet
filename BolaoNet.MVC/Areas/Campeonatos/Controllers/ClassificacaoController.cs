using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class ClassificacaoController : BaseCampeonatoAreaController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.ICampeonatoClassificacaoApp _campeonatoClassificacaoApp;

        #endregion

        #region Constructors/Destructors

        public ClassificacaoController(
            Application.Interfaces.Campeonatos.ICampeonatoClassificacaoApp campeonatoClassificacaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _campeonatoClassificacaoApp = campeonatoClassificacaoApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {

            IList<ViewModels.Campeonatos.CampeonatoClassificacaoGrupoViewModel> model = 
                new List<ViewModels.Campeonatos.CampeonatoClassificacaoGrupoViewModel>();


            for (int c = 0; c < base.CampeonatoData.NomeGrupos.Count; c++ )
            {
                string nomeGrupo = base.CampeonatoData.NomeGrupos[c];

                if (!string.IsNullOrEmpty (nomeGrupo) && !string.IsNullOrWhiteSpace (nomeGrupo))
                {
                    IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> classificacao =
                        _campeonatoClassificacaoApp.LoadClassificacao(base.SelectedCampeonato,
                            new Domain.Entities.Campeonatos.CampeonatoFase(
                                Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria,
                                base.SelectedNomeCampeonato),
                            new Domain.Entities.Campeonatos.CampeonatoGrupo(nomeGrupo,
                                base.SelectedNomeCampeonato), 0);


                    IList<ViewModels.Campeonatos.CampeonatoClassificacaoEntryViewModel> data =
                        Mapper.Map<IList<Domain.Entities.Campeonatos.CampeonatoClassificacao>,
                        IList<ViewModels.Campeonatos.CampeonatoClassificacaoEntryViewModel>>
                        (classificacao);

                    model.Add(new ViewModels.Campeonatos.CampeonatoClassificacaoGrupoViewModel()
                        {
                            NomeGrupo = nomeGrupo,
                            Posicoes = data,
                        });

                }
            }

            return View(model);
        }

        #endregion
    }
}