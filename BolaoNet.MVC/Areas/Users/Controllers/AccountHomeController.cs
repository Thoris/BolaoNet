using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class AccountHomeController : BaseUserAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroGrupoApp _bolaoMembroGrupoApp;
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors

        public AccountHomeController(
            Application.Interfaces.Boloes.IBolaoApp bolaoApp, 
            Application.Interfaces.Boloes.IBolaoMembroGrupoApp bolaoMembroGrupoApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp
            )
        {
            _bolaoApp = bolaoApp;
            _bolaoMembroGrupoApp = bolaoMembroGrupoApp;
            _jogoUsuarioApp = jogoUsuarioApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index ()
        {
            int totalProximoJogo = 5;
            int totalPontosObtidos = 5;


            ViewModels.Users.PaginaPrincipalModelView model = new ViewModels.Users.PaginaPrincipalModelView();


            IList<Domain.Entities.ValueObjects.UserBoloesVO> listBoloes = _bolaoApp.GetBoloesUsuario(base.UserLogged);

            model.Posicoes =
                Mapper.Map<
                IList<Domain.Entities.ValueObjects.UserBoloesVO>, 
                IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoPosicoesViewModel>
                >(listBoloes);


            IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO> listSaldo = _bolaoApp.GetBoloesSaldoUsuario(base.UserLogged);

            model.Saldo =
                Mapper.Map<
                IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO>,
                IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoSaldoDevedorViewModel>
                >(listSaldo);


            if (base.SelectedBolao != null && !string.IsNullOrEmpty(base.SelectedBolao.Nome))
            {
                IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> listClassificacao =
                    _bolaoMembroGrupoApp.LoadClassificacao(base.SelectedBolao, base.UserLogged);

                model.ComparacaoMembros =
                    Mapper.Map<
                    IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>,
                    IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView>
                    >(listClassificacao);

                for (int c = 0; c < model.ComparacaoMembros.Count; c++)
                {
                    if (c == 0)
                        model.ComparacaoMembros[c].PosicaoIndividual = 1;
                    else
                    {
                        if (model.ComparacaoMembros[c].TotalPontos ==
                            model.ComparacaoMembros[c - 1].TotalPontos)
                        {
                            model.ComparacaoMembros[c].PosicaoIndividual = model.ComparacaoMembros[c - 1].PosicaoIndividual;
                        }
                        else
                        {
                            model.ComparacaoMembros[c].PosicaoIndividual = c + 1;
                        }
                    }

                }
            }
            else
            {
                model.ComparacaoMembros = new List<ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView>();
            }


            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> proximos = 
                _jogoUsuarioApp.LoadProximosJogosUsuario(base.UserLogged, totalProximoJogo);

            model.ProximasApostas = Mapper.Map<
                    IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                    IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalProximaApostaViewModel>
                    >(proximos);



            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> obtidos =
                _jogoUsuarioApp.LoadPontosObtidos(base.UserLogged, totalPontosObtidos);

            model.PontosObtidos = Mapper.Map<
                    IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                    IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalPontosObtidosViewModel>
                    >(obtidos);

            
            return View(model);
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public new ActionResult Profile(ViewModels.Users.UserProfileViewModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ViewModels.Users.UserChangePasswordViewModel model)
        {
            return View();
        }

        public ActionResult Logoff()
        {
             return base.Logout();            
        }


        #endregion
    }
}