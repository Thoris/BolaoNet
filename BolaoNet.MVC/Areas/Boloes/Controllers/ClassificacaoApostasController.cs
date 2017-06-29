using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ClassificacaoApostasController : BaseBolaoAreaController
    {
        #region Variables
        
        private Application.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioApp _bolaoCampeonatoClassificacaoUsuarioApp;

        #endregion

        #region Constructors/Destructors


        public ClassificacaoApostasController(
            Application.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioApp bolaoCampeonatoClassificacaoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoCampeonatoClassificacaoUsuarioApp = bolaoCampeonatoClassificacaoUsuarioApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            ViewModels.Bolao.CampeonatoClassificacaoApostaUsuarioViewModel model =
                new ViewModels.Bolao.CampeonatoClassificacaoApostaUsuarioViewModel();

            model.Grupos = new List<ViewModels.Bolao.CampeonatoClassificacaoApostaGrupoViewModel>();

            for (int c = 0; c < base.CampeonatoData.NomeGrupos.Count; c++)
            {
                string nomeGrupo = base.CampeonatoData.NomeGrupos[c];

                if (!string.IsNullOrEmpty(nomeGrupo) && !string.IsNullOrWhiteSpace(nomeGrupo))
                {
                    IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> classificacao =
                    _bolaoCampeonatoClassificacaoUsuarioApp.LoadClassificacao(base.SelectedBolao,
                            new Domain.Entities.Campeonatos.CampeonatoFase(
                                Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria,
                                    base.SelectedNomeCampeonato),
                            new Domain.Entities.Campeonatos.CampeonatoGrupo(nomeGrupo,
                                    base.SelectedNomeCampeonato),
                            base.UserLogged);



                    IList<ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel> data =
                        Mapper.Map<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
                        IList<ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel>>
                        (classificacao);



                    model.Grupos.Add(new ViewModels.Bolao.CampeonatoClassificacaoApostaGrupoViewModel()
                    {
                        NomeGrupo = nomeGrupo,
                        Posicoes = data,
                    });

                    model.UserName = base.UserLogged.UserName;

                }
            }

            return View(model);

        }

        #endregion
    
    }
}