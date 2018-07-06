using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasExtrasPossibilidadesController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;

        #endregion

        #region Constructors/Destructors


        public ApostasExtrasPossibilidadesController(
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp,
            Application.Interfaces.Boloes.IApostaExtraUsuarioApp apostaExtraUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoApp = jogoApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _apostaExtraApp = apostaExtraApp;
            _apostaExtraUsuarioApp = apostaExtraUsuarioApp;
        }

        #endregion

        #region Methods

        private void MergeClassificacao(ViewModels.Bolao.ApostasExtrasViewModel model, IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros)
        {
            for (int c = membros.Count - 1; c >= 0; c--)
            {
                for (int i = 0; i < model.ApostasUsuarios.Count; i++)
                {
                    if (string.Compare(model.ApostasUsuarios[i].UserName, membros[c].UserName, true) == 0)
                    {
                        model.ApostasUsuarios[i].Posicao = (int)membros[c].Posicao;
                        model.ApostasUsuarios[i].FullName = membros[c].FullName;
                        model.ApostasUsuarios[i].TotalPontosClassificacao = (int)membros[c].TotalPontos;

                        if (membros[c].TotalApostaExtra == null)
                            model.ApostasUsuarios[i].Pontos = 0;
                        else
                            model.ApostasUsuarios[i].Pontos = (int)membros[c].TotalApostaExtra;

                        membros.RemoveAt(c);
                        break;
                    }
                }
            }
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            ViewModels.Bolao.ApostasExtrasViewModel model = new ViewModels.Bolao.ApostasExtrasViewModel();

            IList<string> primeiroSegundo = new List<string>();
            IList<string> terceiroQuarto = new List<string>();

            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);


            int jogoIdFinal = 64;
            if (System.Configuration.ConfigurationManager.AppSettings["JogoFinalPrimeiro"] != null)
                int.Parse (System.Configuration.ConfigurationManager.AppSettings["JogoFinalPrimeiro"]);

            int jogoIdTerceiro = 63;
            if (System.Configuration.ConfigurationManager.AppSettings["JogoFinalTerceiro"] != null)
                int.Parse (System.Configuration.ConfigurationManager.AppSettings["JogoFinalTerceiro"]);


            //Buscando os jogos do campeonato que não ocorreram, mas que existem times definidos na fase eliminatória
            IList<Domain.Entities.Campeonatos.Jogo> jogos =
                _jogoApp.GetJogosTimesPossibilidades(base.SelectedCampeonato);


            bool foundJogoFinal = false;
            bool foundJogoTerceiro = false;

            for (int c=0; c < jogos.Count; c++)
            {
                if (jogos[c].JogoId == jogoIdFinal)
                {
                    foundJogoFinal = true;

                    if (!string.IsNullOrEmpty(jogos[c].NomeTime1))
                    {
                        primeiroSegundo.Add(jogos[c].NomeTime1);
                    }
                    if (!string.IsNullOrEmpty(jogos[c].NomeTime2))
                    {
                        primeiroSegundo.Add(jogos[c].NomeTime2);
                    }
                }
                if (jogos[c].JogoId == jogoIdTerceiro)
                {
                    foundJogoTerceiro = true;
                    
                    if (!string.IsNullOrEmpty(jogos[c].NomeTime1))
                    {
                        terceiroQuarto.Add(jogos[c].NomeTime1);
                    }
                    if (!string.IsNullOrEmpty(jogos[c].NomeTime2))
                    {
                        terceiroQuarto.Add(jogos[c].NomeTime2);
                    }
                }

                if (!foundJogoFinal && !foundJogoTerceiro)
                {
                    if (!string.IsNullOrEmpty(jogos[c].NomeTime1))
                    {
                        primeiroSegundo.Add(jogos[c].NomeTime1);
                        terceiroQuarto.Add(jogos[c].NomeTime1);
                    }
                    if (!string.IsNullOrEmpty(jogos[c].NomeTime2))
                    {
                        primeiroSegundo.Add(jogos[c].NomeTime2);
                        terceiroQuarto.Add(jogos[c].NomeTime2);
                    }
                }
            }





            IList<Domain.Entities.Boloes.ApostaExtra> extras =
                _apostaExtraApp.GetApostasBolao(base.SelectedBolao);


            IList<ViewModels.Bolao.ApostasExtrasEntryViewModel> apostasBolao =
                Mapper.Map<IList<Domain.Entities.Boloes.ApostaExtra>,
                IList<ViewModels.Bolao.ApostasExtrasEntryViewModel>>(extras);

            model.ApostasExtras = apostasBolao;
            model.Simulacao = apostasBolao;


            IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> usuariosAgrupado =
                _apostaExtraUsuarioApp.GetApostasBolaoAgrupado(this.SelectedBolao);


            model.ApostasUsuarios = new List<ViewModels.Bolao.ApostasExtrasUsuarioEntryViewModel>();
            for (int c = 0; c < usuariosAgrupado.Count; c++)
            {

                #region Verificando se existe possibilidade do time ganhar
                for (int i = 0; i < usuariosAgrupado[c].Count; i++)
                {
                    if (i <= 1)
                    {
                        for (int l = 0; l < primeiroSegundo.Count; l++)
                        {
                            if (string.Compare(primeiroSegundo[l], usuariosAgrupado[c][i].NomeTime, true) == 0)
                            {
                                usuariosAgrupado[c][i].Pontos = extras[i].TotalPontos;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < terceiroQuarto.Count; l++)
                        {
                            if (string.Compare(terceiroQuarto[l], usuariosAgrupado[c][i].NomeTime, true) == 0)
                            {
                                usuariosAgrupado[c][i].Pontos = extras[i].TotalPontos;
                                break;
                            }
                        }
                    }
                }
                #endregion

                IList<ViewModels.Bolao.ApostasExtrasUsuariosPontosViewModel> entry =
                    Mapper.Map<IList<Domain.Entities.Boloes.ApostaExtraUsuario>,
                    IList<ViewModels.Bolao.ApostasExtrasUsuariosPontosViewModel>>(usuariosAgrupado[c]);

                model.ApostasUsuarios.Add(new ViewModels.Bolao.ApostasExtrasUsuarioEntryViewModel()
                {
                    Apostas = entry,
                    UserName = entry[0].UserName,
                });
            }

            MergeClassificacao(model, membros);
            model.ApostasUsuarios = model.ApostasUsuarios.OrderBy(x => x.Posicao).ToList();

            ViewBag.Times = base.CampeonatoData.NomeTimes;

            return View(model);
        }

        #endregion
    }
}