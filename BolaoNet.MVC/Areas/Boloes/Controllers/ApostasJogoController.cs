using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasJogoController: BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;

        #endregion

        #region Constructors/Destructors


        public ApostasJogoController(
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _jogoApp = jogoApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
        }

        #endregion

        #region Methods

        public void CalcularPercentuais(ViewModels.Bolao.ApostasJogoViewModel model)
        {
            int totalTime1 = 0;
            int totalTime2 = 0;
            int totalEmpate = 0;
            int total = 0;


            for (int c=0; c < model.Apostas.Count; c++)
            {
                if (model.Apostas[c].ApostaTime1 == model.Apostas[c].ApostaTime2)
                {
                    totalEmpate++;
                }
                else if (model.Apostas[c].ApostaTime1 > model.Apostas[c].ApostaTime2)
                {
                    totalTime1++;
                }
                else
                {
                    totalTime2++;
                }

                total++;
                model.Apostas[c].TotalApostasResultado++;

                for (int i = c+1; i < model.Apostas.Count; i++)
                {                   
                    if (model.Apostas[c].ApostaTime1 == model.Apostas[i].ApostaTime1 &&
                        model.Apostas[c].ApostaTime2 == model.Apostas[i].ApostaTime2 )
                    {                        
                        model.Apostas[i].TotalApostasResultado++;
                        model.Apostas[c].TotalApostasResultado++;
                    }
                }
            }

            for (int c=0; c < model.Apostas.Count; c++)
            {
                model.Apostas[c].PercentualResultado =
                    (double)model.Apostas[c].TotalApostasResultado /
                    (double)model.Apostas.Count * (double)100;
            }

            model.PercentualEmpate = (double)totalEmpate / (double)total * (double)100;
            model.PercentualTime1 = (double)totalTime1 / (double)total * (double)100;
            model.PercentualTime2 = (double)totalTime2 / (double)total * (double)100;

        }
        private void MergeClassificacao(ViewModels.Bolao.ApostasJogoViewModel model, IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros)
        {
            for (int c=membros.Count - 1; c >= 0; c--)
            {
                for (int i=0; i < model.Apostas.Count; i++)
                {
                    if (string.Compare (model.Apostas[i].UserName, membros[c].UserName, true) == 0)
                    {
                        model.Apostas[i].Posicao = (int)membros[c].Posicao;
                        model.Apostas[i].Nome = membros[c].FullName;
                        model.Apostas[i].TotalPontosClassificacao = (int)membros[c].TotalPontos;

                        membros.RemoveAt(c);
                        break;
                    }
                }
            }
        }

        #endregion

        #region Actions

        public ActionResult Index(int id)
        {

            Domain.Entities.Campeonatos.Jogo jogo =
                _jogoApp.Load(new Domain.Entities.Campeonatos.Jogo(base.SelectedNomeCampeonato, id));

            ViewModels.Bolao.ApostasJogoViewModel model =
                Mapper.Map<Domain.Entities.Campeonatos.Jogo, ViewModels.Bolao.ApostasJogoViewModel>(jogo);


            IList<Domain.Entities.Boloes.JogoUsuario> apostas = 
                _jogoUsuarioApp.GetApostasJogo(base.SelectedBolao, jogo);

            IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel> list =
                Mapper.Map<IList<Domain.Entities.Boloes.JogoUsuario>, 
                IList<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>>(apostas);


            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);

            model.Apostas = list;

            CalcularPercentuais(model);
            MergeClassificacao(model, membros);

            model.Apostas = model.Apostas.OrderBy(x => x.Posicao).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Simular(ViewModels.Bolao.ApostasJogoViewModel model)
        {



            return View(model);
        }

        #endregion
    }
}