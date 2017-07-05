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
        private Application.Interfaces.Campeonatos.ICampeonatoPosicaoApp _campeonatoPosicaoApp;

        #endregion

        #region Constructors/Destructors


        public ClassificacaoApostasController(
            Application.Interfaces.Campeonatos.ICampeonatoPosicaoApp campeonatoPosicaoApp,
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
            _campeonatoPosicaoApp = campeonatoPosicaoApp;
        }

        #endregion

        #region Methods

        private void AplicarDestaques(IList<Domain.Entities.Campeonatos.CampeonatoPosicao> posicoes, ViewModels.Bolao.CampeonatoClassificacaoApostaUsuarioViewModel model)
        {
            //Percorrendo as posições em busca do mesmo nome de grupo
            for (int c = 0; c < posicoes.Count; c++)
            {
                bool found = false;

                //Percorrendo todos os grupos da coleção de classificação
                for (int g = 0; g < model.Grupos.Count; g++)
                {
                    if (string.Compare(posicoes[c].NomeGrupo, model.Grupos[g].NomeGrupo, true) == 0)
                    {
                        //Percorrendo todos os itens da classificação em busca da posição a ser destacada
                        for (int i = 0; i < model.Grupos[g].Posicoes.Count; i++)
                        {
                            //Se encontrou a posição a ser destacada
                            if (model.Grupos[g].Posicoes[i].Posicao == posicoes[c].Posicao)
                            {
                                try
                                {
                                    model.Grupos[g].Posicoes[i].BackColor = System.Drawing.Color.FromName(posicoes[c].BackColorName);
                                    model.Grupos[g].Posicoes[i].ForeColor = System.Drawing.Color.FromName(posicoes[c].ForeColorName);

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

        public ActionResult Index(ViewModels.Bolao.CampeonatoClassificacaoApostaUsuarioViewModel model)
        {

            if (model == null)
                model = new ViewModels.Bolao.CampeonatoClassificacaoApostaUsuarioViewModel();


            //Criando a fase utilizada para apresentação dos dados
            Domain.Entities.Campeonatos.CampeonatoFase fase = 
                new Domain.Entities.Campeonatos.CampeonatoFase(
                    Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria,
                    base.SelectedNomeCampeonato);


            //Buscando os pontos de highlight das posições que possuem legendas
            IList<Domain.Entities.Campeonatos.CampeonatoPosicao> posicoes = 
                _campeonatoPosicaoApp.GetPosicao(base.SelectedCampeonato, fase);



            //Se não foi selecionado nenhum usuário
            if (string.IsNullOrEmpty(model.UserName))
                model.UserName = base.UserLogged.UserName;


            model.Grupos = new List<ViewModels.Bolao.CampeonatoClassificacaoApostaGrupoViewModel>();

            //Carregando as classificações de todos os grupos
            for (int c = 0; c < base.CampeonatoData.NomeGrupos.Count; c++)
            {
                string nomeGrupo = base.CampeonatoData.NomeGrupos[c];

                if (!string.IsNullOrEmpty(nomeGrupo) && !string.IsNullOrWhiteSpace(nomeGrupo))
                {
                    //Buscando a classificação do grupo
                    IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> classificacao =
                    _bolaoCampeonatoClassificacaoUsuarioApp.LoadClassificacao(base.SelectedBolao,
                            fase,
                            new Domain.Entities.Campeonatos.CampeonatoGrupo(nomeGrupo,
                                    base.SelectedNomeCampeonato),
                            new Domain.Entities.Users.User (model.UserName));


                    //Convertendo os 
                    IList<ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel> data =
                        Mapper.Map<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
                        IList<ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel>>
                        (classificacao);

                    //Validando as posições
                    for (int i = 0; i < data.Count; i++ )                    
                        data[i].Posicao = i + 1;

                    model.Grupos.Add(new ViewModels.Bolao.CampeonatoClassificacaoApostaGrupoViewModel()
                    {
                        NomeGrupo = nomeGrupo,
                        Posicoes = data,
                    });

                }//endif grupo
            }//end for c



            AplicarDestaques(posicoes, model);

            IList<Domain.Entities.Boloes.BolaoMembro> membros = _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);
            ViewBag.Membros = new SelectList(membros, "UserName", "UserName", model.UserName);

            return View(model);

        }

        #endregion
    
    }
}