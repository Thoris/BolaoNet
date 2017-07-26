using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class BolaoClassificacaoController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IBolaoPremioApp _bolaoPremioApp;

        #endregion

        #region Constructors/Destructors


        public BolaoClassificacaoController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IBolaoPremioApp bolaoPremioApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoPremioApp = bolaoPremioApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> list =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);


            ViewModels.Bolao.BolaoClassificacaoViewModel model = new ViewModels.Bolao.BolaoClassificacaoViewModel();
            model.Classificacao = Mapper.Map<IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>, IList<ViewModels.Bolao.ClassificacaoViewModel>>
                (list);

            //IList<ViewModels.Bolao.ClassificacaoViewModel> model =
            //    Mapper.Map<IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>, IList<ViewModels.Bolao.ClassificacaoViewModel>>
            //    (list);


            IList<Domain.Entities.Boloes.BolaoPremio> premios = _bolaoPremioApp.GetPremiosBolao(base.SelectedBolao);
            model.Premios = Mapper.Map<IList<Domain.Entities.Boloes.BolaoPremio>, IList<ViewModels.Bolao.PremioViewModel>>(premios);


            for (int c = 0; c < model.Premios.Count; c++ )
            {
                for (int i = 0; i < model.Classificacao.Count; i++)
                {
                    if (model.Premios[c].Posicao < model.Classificacao[i].Posicao)
                        break;

                    if (model.Premios[c].Posicao == model.Classificacao[i].Posicao)
                    {
                        model.Classificacao[i].BackColorName = model.Premios[c].BackColorName;
                        model.Classificacao[i].ForeColorName = model.Premios[c].ForeColorName;
                    }
                }
            }

            //int ultimo = model.Classificacao[model.Classificacao.Count - 1].Posicao ?? 0;

            //for (int c = model.Classificacao.Count - 1; c > 0; c-- )
            //{
            //    if (model.Classificacao[c].Posicao == ultimo)
            //    {
            //        model.Classificacao[c].BackColorName = "LightGray";
            //        model.Classificacao[c].ForeColorName = "White";
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            return View(model);
        }

        #endregion
    }
}