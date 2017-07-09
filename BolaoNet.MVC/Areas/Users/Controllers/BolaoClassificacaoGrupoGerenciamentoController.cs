using AutoMapper;
using BolaoNet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class BolaoClassificacaoGrupoGerenciamentoController : BaseBolaoController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroGrupoApp _bolaoMembroGrupoApp;

        #endregion

        #region Constructors/Destructors

        public BolaoClassificacaoGrupoGerenciamentoController(
            Application.Interfaces.Boloes.IBolaoMembroGrupoApp bolaoMembroGrupoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoMembroGrupoApp = bolaoMembroGrupoApp;

        }

        #endregion
        
        #region Actions

        public ActionResult Index()
        {

            ViewModels.Users.UserGrupoComparacaoViewModel model = new ViewModels.Users.UserGrupoComparacaoViewModel();

            IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> listClassificacao =
                   _bolaoMembroGrupoApp.LoadClassificacao(base.SelectedBolao, base.UserLogged);

            model.GrupoSelecionado =
                Mapper.Map<
                IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>,
                IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView>
                >(listClassificacao);



            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> list =
               _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);


            model.Classificacao =             
                Mapper.Map<IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>, IList<ViewModels.Bolao.ClassificacaoViewModel>>
                (list);


            for (int c = 0; c < model.GrupoSelecionado.Count; c++ )
            {
                for (int i = 0; i < model.Classificacao.Count; i++)
                {
                    if (string.Compare (model.GrupoSelecionado[c].UserName, model.Classificacao[i].UserName, true) == 0)
                    {
                        model.Classificacao.RemoveAt(i);
                        break;
                    }
                }
            }


            return View(model);
        }
        public ActionResult Add(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                Domain.Entities.Boloes.BolaoMembroGrupo entry =
                    new Domain.Entities.Boloes.BolaoMembroGrupo(
                        base.UserLogged.UserName, base.SelectedNomeBolao, userName);

                if (_bolaoMembroGrupoApp.Load(entry) == null)
                    _bolaoMembroGrupoApp.Insert(entry);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Remove(string userName)
        {

            if (!string.IsNullOrEmpty(userName))
            {
                Domain.Entities.Boloes.BolaoMembroGrupo entry =
                    new Domain.Entities.Boloes.BolaoMembroGrupo(
                        base.UserLogged.UserName, base.SelectedNomeBolao, userName);

                Domain.Entities.Boloes.BolaoMembroGrupo dataLoaded = _bolaoMembroGrupoApp.Load(entry);
                if (dataLoaded != null)
                    _bolaoMembroGrupoApp.Delete(dataLoaded);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}