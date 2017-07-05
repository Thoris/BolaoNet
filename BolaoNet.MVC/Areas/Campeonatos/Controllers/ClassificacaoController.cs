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
        private Application.Interfaces.Campeonatos.ICampeonatoPosicaoApp _campeonatoPosicaoApp;

        #endregion

        #region Constructors/Destructors

        public ClassificacaoController(
            Application.Interfaces.Campeonatos.ICampeonatoPosicaoApp campeonatoPosicaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoClassificacaoApp campeonatoClassificacaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _campeonatoClassificacaoApp = campeonatoClassificacaoApp;
            _campeonatoPosicaoApp = campeonatoPosicaoApp;
        }

        #endregion

        #region Methods


        private void AplicarDestaques(IList<Domain.Entities.Campeonatos.CampeonatoPosicao> posicoes, IList<ViewModels.Campeonatos.CampeonatoClassificacaoGrupoViewModel> model)
        {
            //Percorrendo as posições em busca do mesmo nome de grupo
            for (int c = 0; c < posicoes.Count; c++)
            {
                bool found = false;

                //Percorrendo todos os grupos da coleção de classificação
                for (int g = 0; g < model.Count; g++)
                {
                    if (string.Compare(posicoes[c].NomeGrupo, model[g].NomeGrupo, true) == 0)
                    {
                        //Percorrendo todos os itens da classificação em busca da posição a ser destacada
                        for (int i = 0; i < model[g].Posicoes.Count; i++)
                        {
                            //Se encontrou a posição a ser destacada
                            if (model[g].Posicoes[i].Posicao == posicoes[c].Posicao)
                            {
                                try
                                {
                                    model[g].Posicoes[i].BackColor = System.Drawing.Color.FromName(posicoes[c].BackColorName);
                                    model[g].Posicoes[i].ForeColor = System.Drawing.Color.FromName(posicoes[c].ForeColorName);

                                    found = true;
                                    break;
                                }
                                catch
                                {

                                }
                            }//endif posição encontrada

                        }//end for i

                        if (found)
                            break;

                    }//endif grupo


                }//end for g

                posicoes.RemoveAt(c);
                c--;
            }//end for c

        }

        #endregion

        #region Actions

        public ActionResult Index()
        {

            IList<ViewModels.Campeonatos.CampeonatoClassificacaoGrupoViewModel> model = 
                new List<ViewModels.Campeonatos.CampeonatoClassificacaoGrupoViewModel>();


            //Criando a fase utilizada para apresentação dos dados
            Domain.Entities.Campeonatos.CampeonatoFase fase =
                new Domain.Entities.Campeonatos.CampeonatoFase(
                    Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria,
                    base.SelectedNomeCampeonato);


            //Buscando os pontos de highlight das posições que possuem legendas
            IList<Domain.Entities.Campeonatos.CampeonatoPosicao> posicoes =
                _campeonatoPosicaoApp.GetPosicao(base.SelectedCampeonato, fase);


            for (int c = 0; c < base.CampeonatoData.NomeGrupos.Count; c++ )
            {
                string nomeGrupo = base.CampeonatoData.NomeGrupos[c];

                if (!string.IsNullOrEmpty (nomeGrupo) && !string.IsNullOrWhiteSpace (nomeGrupo))
                {
                    IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> classificacao =
                        _campeonatoClassificacaoApp.LoadClassificacao(base.SelectedCampeonato,
                            fase,
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

            AplicarDestaques(posicoes, model);

            return View(model);
        }

        #endregion
    }
}