using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class ApostasExtrasController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;

        #endregion

        #region Constructors/Destructors


        public ApostasExtrasController(
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


            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> membros =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);

            IList<Domain.Entities.Boloes.ApostaExtra> extras =
                _apostaExtraApp.GetApostasBolao(base.SelectedBolao);


            IList<ViewModels.Bolao.ApostasExtrasEntryViewModel> apostasBolao =
                Mapper.Map<IList<Domain.Entities.Boloes.ApostaExtra>,
                IList<ViewModels.Bolao.ApostasExtrasEntryViewModel>>(extras);

            model.ApostasExtras = apostasBolao;
            

            IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> usuariosAgrupado =
                _apostaExtraUsuarioApp.GetApostasBolaoAgrupado(this.SelectedBolao);


            model.ApostasUsuarios = new List<ViewModels.Bolao.ApostasExtrasUsuarioEntryViewModel>();
            for (int c = 0; c < usuariosAgrupado.Count; c++)
            {
                IList<ViewModels.Bolao.ApostasExtrasUsuariosPontosViewModel> entry =
                    Mapper.Map<IList<Domain.Entities.Boloes.ApostaExtraUsuario>,
                    IList<ViewModels.Bolao.ApostasExtrasUsuariosPontosViewModel>>(usuariosAgrupado[c]);

                model.ApostasUsuarios.Add(new ViewModels.Bolao.ApostasExtrasUsuarioEntryViewModel()
                    {
                        Apostas = entry,
                        UserName = entry[0].UserName
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