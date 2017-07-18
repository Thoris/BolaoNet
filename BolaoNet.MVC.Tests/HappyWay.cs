using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BolaoNet.MVC.Tests.IoC;
using Ninject;
using BolaoNet.Application.Interfaces.Campeonatos;
using BolaoNet.Application.Interfaces.Users;
using BolaoNet.Application.Interfaces.Boloes;
using BolaoNet.Application.Interfaces.Notification;
using BolaoNet.Application.Interfaces.Facade.Campeonatos;
using BolaoNet.Application.Interfaces.Facade;
using System.Web.Mvc;
using BolaoNet.Application.Interfaces.Reports;
using BolaoNet.Tests.CopaDoMundoTests.CopaDoMundo2014Tests;
using System.Web;
using System.Collections.Generic;

namespace BolaoNet.MVC.Tests
{
    [TestClass]
    public class HappyWay
    {
        [TestMethod]
        public void TestFullCycle()
        {

            #region Declaração de Variáveis

            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

            IInitializationFacadeApp initializationFacadeApp = kernel.Get<IInitializationFacadeApp>();

            MVC.AutoMapper.AutoMapperConfig.RegisterMappings();

            ICopaMundo2014FacadeApp copaMundo2014FacadeApp = kernel.Get<ICopaMundo2014FacadeApp>();
            ICampeonatoApp campeonatoApp = kernel.Get<ICampeonatoApp>();
            IJogoApp jogoApp = kernel.Get<IJogoApp>();            
            IUserApp userApp = kernel.Get<IUserApp>();
            IUserInRoleApp userInRoleApp = kernel.Get<IUserInRoleApp>();
            IBolaoMembroApp bolaoMembroApp = kernel.Get<IBolaoMembroApp>();
            IBolaoApp bolaoApp = kernel.Get<IBolaoApp>();
            INotificationApp notificationApp = kernel.Get<INotificationApp>();
            IJogoUsuarioApp jogoUsuarioApp = kernel.Get<IJogoUsuarioApp>();
            ICampeonatoFaseApp campeonatoFaseApp = kernel.Get<ICampeonatoFaseApp>();
            ICampeonatoGrupoApp campeonatoGrupoApp = kernel.Get<ICampeonatoGrupoApp>();
            ICampeonatoTimeApp campeonatoTimeApp = kernel.Get<ICampeonatoTimeApp>();
            IBolaoMembroApostasReportApp bolaoMembroApostasReportApp = kernel.Get<IBolaoMembroApostasReportApp>();
            IBolaoApostasInicioReportApp bolaoApostasInicioReportApp = kernel.Get<IBolaoApostasInicioReportApp>();
            IBolaoApostasFimReportApp bolaoApostasFimReportApp = kernel.Get<IBolaoApostasFimReportApp>();
            IApostaExtraApp apostaExtraApp = kernel.Get<IApostaExtraApp>();                
            IBolaoPremioApp bolaoPremioApp = kernel.Get<IBolaoPremioApp>();
            IBolaoCriterioPontosApp bolaoCriterioPontosApp = kernel.Get<IBolaoCriterioPontosApp>();
            IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp = kernel.Get<IBolaoCriterioPontosTimesApp>();
            IBolaoRegraApp bolaoRegraApp = kernel.Get<IBolaoRegraApp>();
            IBolaoPontuacaoApp bolaoPontuacaoApp = kernel.Get<IBolaoPontuacaoApp>();
            IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp = kernel.Get<IBolaoMembroClassificacaoApp>();

            //Mocks.HttpContextControllerMock mock = new Mocks.HttpContextControllerMock();

            #endregion

            #region Inicialização de Dados

            campeonatoApp.ClearDatabase();

            initializationFacadeApp.InitAll();

            Domain.Entities.Campeonatos.Campeonato campeonato =
                copaMundo2014FacadeApp.CreateCampeonato("Copa do Mundo 2014", false);

            BolaoCopaMundo2014AppHelper bolaoHelper = new BolaoCopaMundo2014AppHelper(
                apostaExtraApp,
                bolaoApp,
                bolaoPremioApp,
                bolaoCriterioPontosApp,
                bolaoCriterioPontosTimesApp,
                bolaoRegraApp,
                bolaoPontuacaoApp);


            Domain.Entities.Boloes.Bolao bolao = bolaoHelper.CreateBolao(campeonato);


            #endregion

            int[][] apostasList =
            {
                new int [] {0,0},
                new int [] {0,1},
                new int [] {1,0},
                new int [] {1,1},
                new int [] {0,2},
                new int [] {1,2},
                new int [] {2,0},
                new int [] {2,1},
                new int [] {2,2},                
            };

            for (int u = 0; u < apostasList.Length; u++)
            {

                #region Criação de Usuário

                int apostaTime1 = apostasList[u][0];
                int apostaTime2 = apostasList[u][1];
                MVC.Controllers.AccountController accountController =
                    new Controllers.AccountController(
                        userApp,
                        userInRoleApp,
                        bolaoMembroApp,
                        bolaoApp,
                        notificationApp
                        );
                Mocks.MvcMockHelpers.SetMockControllerContext(accountController);



                ViewModels.Account.RegistrationUserViewModel registroVO =
                    new ViewModels.Account.RegistrationUserViewModel()
                    {
                        ConcordoTermos = true,
                        //UserName = "Usuario0x0",
                        UserName = "Usuario" + apostaTime1 + "x" + apostaTime2,
                        BirthDate = DateTime.Now,
                        ConfirmacaoEmail = "teste@teste.com.br",
                        Email = "teste@teste.com.br",
                        Password = "thoris",
                        ConfirmPassword = "thoris",
                        FullName = "Thoris Pivetta",
                        Male = true,
                        PhoneNumber = "(12) 1234 1234",
                        ReceiveEmails = true,
                    };
                var registrationFormView = accountController.RegistrationForm(registroVO) as ViewResult;


                Domain.Entities.Users.User userLoaded = userApp.Load(
                    new Domain.Entities.Users.User(registroVO.UserName));

                Assert.IsNotNull(userLoaded);
                Assert.AreEqual(registroVO.UserName.ToLower(), userLoaded.UserName);
                Assert.AreEqual(registroVO.FullName, userLoaded.FullName);
                Assert.AreEqual(registroVO.Email, userLoaded.Email);
                Assert.AreEqual(registroVO.BirthDate, userLoaded.BirthDate);
                Assert.AreEqual(registroVO.Male, userLoaded.Male);
                Assert.AreEqual(registroVO.Password, userLoaded.Password);
                Assert.AreEqual(registroVO.PhoneNumber, userLoaded.PhoneNumber);
                Assert.AreEqual(registroVO.ReceiveEmails, userLoaded.ReceiveEmails);


                Assert.IsFalse(userLoaded.IsApproved);
                Assert.IsFalse(userLoaded.IsAdmin);


                ViewModels.Account.ActivationCodeViewModel activeCodeVO = new ViewModels.Account.ActivationCodeViewModel()
                {
                    ActivateKey = userLoaded.ActivateKey,
                    UserName = userLoaded.UserName
                };

                var activeCodeView = accountController.ActivateCode(activeCodeVO) as ViewResult;

                userLoaded = userApp.Load(userLoaded);


                Assert.IsTrue(userLoaded.IsApproved);
                Assert.IsFalse(userLoaded.IsAdmin);


                ViewModels.Account.LoginViewModel loginVO = new ViewModels.Account.LoginViewModel()
                {
                    UserName = registroVO.UserName,
                    Password = registroVO.Password,
                    RememberMe = false,
                };

                var loginView = accountController.Login(loginVO, null) as ViewResult;

                #endregion

                Security.CustomUserPrincipal customUser = new Security.CustomUserPrincipal(loginVO.UserName);
                customUser.FullName = registroVO.FullName;

                #region Seleção de Bolão

                MVC.Areas.Users.Controllers.UserBoloesController userBoloesController =
                    new Areas.Users.Controllers.UserBoloesController(
                        bolaoMembroApp,
                        bolaoApp,
                        campeonatoApp,
                        campeonatoFaseApp,
                        campeonatoGrupoApp,
                        campeonatoTimeApp
                        );

                Mocks.MvcMockHelpers.SetMockControllerContext(userBoloesController, customUser);

                var bolaoSelecionadoView = userBoloesController.Selecionar(bolao.Nome);

                #endregion

                #region Apostas Jogos Fase

                MVC.Areas.Apostas.Controllers.ApostasJogosController apostasJogosController
                    = new Areas.Apostas.Controllers.ApostasJogosController(
                        bolaoMembroApp,
                        bolaoApp,
                        jogoUsuarioApp,
                        campeonatoApp,
                        campeonatoFaseApp,
                        campeonatoGrupoApp,
                        campeonatoTimeApp,
                        bolaoMembroApostasReportApp);

                Mocks.MvcMockHelpers.SetMockControllerContext(apostasJogosController, customUser);
                apostasJogosController.LoadCampeonatoData();

                var apostasView = apostasJogosController.Jogos(new ViewModels.Apostas.ApostasJogosListViewModel()) as ViewResult;

                Assert.IsNotNull(apostasView);

                ViewModels.Apostas.ApostasJogosListViewModel modelApostas = (ViewModels.Apostas.ApostasJogosListViewModel)apostasView.Model;

                Assert.IsNotNull(modelApostas);
                Assert.IsNotNull(modelApostas.Apostas);
                Assert.AreEqual(48, modelApostas.Apostas.Count);

                for (int c = 0; c < modelApostas.Apostas.Count; c++)
                {
                    Assert.AreEqual(Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria, modelApostas.Apostas[c].NomeFase);

                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime1);
                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime2);

                    modelApostas.Apostas[c].SalvarApostaTime1 = apostaTime1;
                    modelApostas.Apostas[c].SalvarApostaTime2 = apostaTime2;
                }

                apostasView = apostasJogosController.SaveJogos(modelApostas) as ViewResult;


                #endregion

                #region Apostas Oitavas

                apostasView = apostasJogosController.Jogos(null) as ViewResult;

                Assert.IsNotNull(apostasView);

                modelApostas = (ViewModels.Apostas.ApostasJogosListViewModel)apostasView.Model;

                Assert.IsNotNull(modelApostas);
                Assert.IsNotNull(modelApostas.Apostas);
                Assert.AreEqual(8, modelApostas.Apostas.Count);

                for (int c = 0; c < modelApostas.Apostas.Count; c++)
                {
                    Assert.AreEqual(Domain.Entities.Campeonatos.CampeonatoFase.FaseOitavasFinal, modelApostas.Apostas[c].NomeFase);

                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime1);
                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime2);

                    modelApostas.Apostas[c].SalvarApostaTime1 = apostaTime1;
                    modelApostas.Apostas[c].SalvarApostaTime2 = apostaTime2;
                }
                apostasView = apostasJogosController.SaveJogos(modelApostas) as ViewResult;


                #endregion

                #region Apostas Quartas


                apostasView = apostasJogosController.Jogos(null) as ViewResult;

                Assert.IsNotNull(apostasView);

                modelApostas = (ViewModels.Apostas.ApostasJogosListViewModel)apostasView.Model;

                Assert.IsNotNull(modelApostas);
                Assert.IsNotNull(modelApostas.Apostas);
                Assert.AreEqual(4, modelApostas.Apostas.Count);

                for (int c = 0; c < modelApostas.Apostas.Count; c++)
                {
                    Assert.AreEqual(Domain.Entities.Campeonatos.CampeonatoFase.FaseQuartasFinal, modelApostas.Apostas[c].NomeFase);

                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime1);
                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime2);

                    modelApostas.Apostas[c].SalvarApostaTime1 = apostaTime1;
                    modelApostas.Apostas[c].SalvarApostaTime2 = apostaTime2;
                }
                apostasView = apostasJogosController.SaveJogos(modelApostas) as ViewResult;

                #endregion

                #region Apostas Semi-finais


                apostasView = apostasJogosController.Jogos(null) as ViewResult;

                Assert.IsNotNull(apostasView);

                modelApostas = (ViewModels.Apostas.ApostasJogosListViewModel)apostasView.Model;

                Assert.IsNotNull(modelApostas);
                Assert.IsNotNull(modelApostas.Apostas);
                Assert.AreEqual(2, modelApostas.Apostas.Count);

                for (int c = 0; c < modelApostas.Apostas.Count; c++)
                {
                    Assert.AreEqual(Domain.Entities.Campeonatos.CampeonatoFase.FaseSemiFinal, modelApostas.Apostas[c].NomeFase);

                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime1);
                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime2);

                    modelApostas.Apostas[c].SalvarApostaTime1 = apostaTime1;
                    modelApostas.Apostas[c].SalvarApostaTime2 = apostaTime2;
                }
                apostasView = apostasJogosController.SaveJogos(modelApostas) as ViewResult;

                #endregion

                #region Apostas Final

                apostasView = apostasJogosController.Jogos(null) as ViewResult;

                Assert.IsNotNull(apostasView);

                modelApostas = (ViewModels.Apostas.ApostasJogosListViewModel)apostasView.Model;

                Assert.IsNotNull(modelApostas);
                Assert.IsNotNull(modelApostas.Apostas);
                Assert.AreEqual(2, modelApostas.Apostas.Count);

                for (int c = 0; c < modelApostas.Apostas.Count; c++)
                {
                    Assert.AreEqual(Domain.Entities.Campeonatos.CampeonatoFase.FaseFinal, modelApostas.Apostas[c].NomeFase);

                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime1);
                    Assert.IsNull(modelApostas.Apostas[c].SalvarApostaTime2);

                    modelApostas.Apostas[c].SalvarApostaTime1 = apostaTime1;
                    modelApostas.Apostas[c].SalvarApostaTime2 = apostaTime2;
                }
                apostasView = apostasJogosController.SaveJogos(modelApostas) as ViewResult;

                #endregion

            }


            Security.CustomUserPrincipal userAdmin = new Security.CustomUserPrincipal("thoris");
            userAdmin.FullName = "Thoris Pivetta";

            #region Início de Bolão

            MVC.Areas.Admin.Controllers.BolaoIniciarPararController bolaoIniciarPararController =
                new Areas.Admin.Controllers.BolaoIniciarPararController(
                    bolaoMembroApp,
                    bolaoApp,
                    campeonatoApp,
                    campeonatoFaseApp,
                    campeonatoGrupoApp,
                    campeonatoTimeApp,
                    bolaoMembroApostasReportApp,
                    bolaoApostasInicioReportApp,
                    bolaoApostasFimReportApp
                    );

            Mocks.MvcMockHelpers.SetMockControllerContext(bolaoIniciarPararController, userAdmin);

            var bolaoIniciarPararVIew = bolaoIniciarPararController.Iniciar() as ViewResult;

            #endregion

            #region Resultados a serem incluidos

            IList<int> jogoLabels = new List<int>();
            IList<int> time1 = new List<int>();
            IList<int> time2 = new List<int>();
            IList<int?> penaltis1 = new List<int?>();
            IList<int?> penaltis2 = new List<int?>();


            //Rodada 1
            jogoLabels.Add(1); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(2); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(3); time1.Add(1); time2.Add(5); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(4); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(5); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(6); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(7); time1.Add(1); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(8); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(9); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(10); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(11); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(12); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(13); time1.Add(4); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(14); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(15); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(16); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);


            //Rodada 2
            jogoLabels.Add(17); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(18); time1.Add(0); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(19); time1.Add(2); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(20); time1.Add(0); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(21); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(22); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(23); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(24); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(25); time1.Add(2); time2.Add(5); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(26); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(27); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(28); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(29); time1.Add(2); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(30); time1.Add(2); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(31); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(32); time1.Add(2); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);

            //Rodada 3
            jogoLabels.Add(33); time1.Add(1); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(34); time1.Add(1); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(35); time1.Add(0); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(36); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(37); time1.Add(1); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(38); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(39); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(40); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(41); time1.Add(0); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(42); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(43); time1.Add(2); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(44); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(45); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(46); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(47); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(48); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);


            //Oitavas
            jogoLabels.Add(49); time1.Add(1); time2.Add(1); penaltis1.Add(3); penaltis2.Add(2);
            jogoLabels.Add(50); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(51); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(52); time1.Add(1); time2.Add(1); penaltis1.Add(4); penaltis2.Add(3);
            jogoLabels.Add(53); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(54); time1.Add(0); time2.Add(0); penaltis1.Add(2); penaltis2.Add(1);
            jogoLabels.Add(55); time1.Add(0); time2.Add(0); penaltis1.Add(1); penaltis2.Add(0);
            jogoLabels.Add(56); time1.Add(0); time2.Add(0); penaltis1.Add(2); penaltis2.Add(1);

            //Quartas
            jogoLabels.Add(57); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(58); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(59); time1.Add(0); time2.Add(0); penaltis1.Add(3); penaltis2.Add(2);
            jogoLabels.Add(60); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);

            //Semi
            jogoLabels.Add(61); time1.Add(1); time2.Add(7); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(62); time1.Add(0); time2.Add(0); penaltis1.Add(2); penaltis2.Add(4);

            //Final
            jogoLabels.Add(63); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(64); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);


            #endregion

            for (int c= 0; c < jogoLabels.Count; c++)
            {
                #region Inclusão de Resultado


                MVC.Areas.Campeonatos.Controllers.JogosController jogosController =
                    new Areas.Campeonatos.Controllers.JogosController (
                        jogoApp, 
                        campeonatoApp, 
                        campeonatoFaseApp, 
                        campeonatoGrupoApp, 
                        campeonatoTimeApp
                        );

                Mocks.MvcMockHelpers.SetMockControllerContext(jogosController, userAdmin);
                jogosController.LoadCampeonatoData();
                
                var jogosView = jogosController.Index(new ViewModels.Campeonatos.CampeonatoJogosListViewModel())  as ViewResult;



                MVC.Areas.Resultados.Controllers.JogoResultadoController jogoResultadoController =
                    new Areas.Resultados.Controllers.JogoResultadoController(
                        bolaoMembroApp,
                        bolaoApp,
                        jogoApp, 
                        campeonatoApp, 
                        campeonatoFaseApp, 
                        campeonatoGrupoApp, 
                        campeonatoTimeApp
                        );

                Mocks.MvcMockHelpers.SetMockControllerContext(jogoResultadoController, userAdmin);
                jogoResultadoController.LoadCampeonatoData();
                

                ViewModels.Resultados.JogoResultadoViewModel jogoResultadoView = 
                    new ViewModels.Resultados.JogoResultadoViewModel();

                jogoResultadoView.JogoId = jogoLabels[c];
                jogoResultadoView.GolsTime1 = time1[c];
                jogoResultadoView.GolsTime2 = time2[c];
                jogoResultadoView.PenaltisTime1 = penaltis1[c];
                jogoResultadoView.PenaltisTime2 = penaltis2[c];                
                jogoResultadoView.NomeCampeonato = campeonato.Nome;


                Mocks.MvcMockHelpers.SetMockControllerContext(jogoResultadoController, userAdmin);

                var resultadoView = jogoResultadoController.Salvar(jogoResultadoView) as ViewResult;




                MVC.Areas.Boloes.Controllers.BolaoClassificacaoController bolaoClassificacaoController =
                    new Areas.Boloes.Controllers.BolaoClassificacaoController(
                        bolaoMembroApp,
                        bolaoApp,
                        bolaoMembroClassificacaoApp,
                        campeonatoApp,
                        campeonatoFaseApp,
                        campeonatoGrupoApp,
                        campeonatoTimeApp);

                Mocks.MvcMockHelpers.SetMockControllerContext(jogoResultadoController, userAdmin);

                var classificacaoView = bolaoClassificacaoController.Index() as ViewResult;

                Assert.IsNotNull(classificacaoView);
                Assert.IsNotNull(classificacaoView.Model);

                IList<BolaoNet.MVC.ViewModels.Bolao.ClassificacaoViewModel> classificacaoModel =
                    (IList<BolaoNet.MVC.ViewModels.Bolao.ClassificacaoViewModel>)classificacaoView.Model;

                Assert.AreEqual(apostasList.Length, classificacaoModel.Count);






                MVC.Areas.Boloes.Controllers.ApostasJogoController apostasJogoController =
                    new Areas.Boloes.Controllers.ApostasJogoController(
                        bolaoMembroClassificacaoApp,
                        jogoApp,
                        jogoUsuarioApp,
                        bolaoMembroApp,
                        bolaoApp,
                        campeonatoApp,
                        campeonatoFaseApp,
                        campeonatoGrupoApp,
                        campeonatoTimeApp);


                Mocks.MvcMockHelpers.SetMockControllerContext(apostasJogoController, userAdmin);

                var apostasJogoView = apostasJogoController.Index(jogoResultadoView.JogoId) as ViewResult;

                Assert.IsNotNull(apostasJogoView);
                Assert.IsNotNull(apostasJogoView.Model);

                ViewModels.Bolao.ApostasJogoViewModel apostasJogoModel =
                    (ViewModels.Bolao.ApostasJogoViewModel)apostasJogoView.Model;

                Assert.AreEqual(apostasList.Length, apostasJogoModel.Apostas.Count);

                #endregion
            }

            #region Apostas Extras 

            MVC.Areas.Resultados.Controllers.ApostasExtrasResultadoController apostasExtrasResultadoController =
                new Areas.Resultados.Controllers.ApostasExtrasResultadoController(
                    apostaExtraApp,
                    bolaoMembroApp,
                    bolaoApp,
                    campeonatoApp,
                    campeonatoFaseApp,
                    campeonatoGrupoApp,
                    campeonatoTimeApp);
            Mocks.MvcMockHelpers.SetMockControllerContext(apostasExtrasResultadoController, userAdmin);

            IList<ViewModels.Resultados.ApostaExtraViewModel> apostaExtraModel = 
                new List<ViewModels.Resultados.ApostaExtraViewModel>();

            apostaExtraModel.Add (new ViewModels.Resultados.ApostaExtraViewModel () 
                {
                    NomeBolao = bolao.Nome,
                    Posicao = 1,
                    NomeTimeValidado = "Alemanha",
                    SalvarNomeTime = null,
                });
            apostaExtraModel.Add (new ViewModels.Resultados.ApostaExtraViewModel () 
                {
                    NomeBolao = bolao.Nome,
                    Posicao = 2,
                    NomeTimeValidado = "Argentina",
                    SalvarNomeTime = null,
                });
            apostaExtraModel.Add (new ViewModels.Resultados.ApostaExtraViewModel () 
                {
                    NomeBolao = bolao.Nome,
                    Posicao = 3,
                    NomeTimeValidado = "Holanda",
                    SalvarNomeTime = null,
                });
            apostaExtraModel.Add (new ViewModels.Resultados.ApostaExtraViewModel () 
                {
                    NomeBolao = bolao.Nome,
                    Posicao = 4,
                    NomeTimeValidado = "Brasil",
                    SalvarNomeTime = null,
                });

            var apostaExtraView = apostasExtrasResultadoController.Salvar(apostaExtraModel) as ViewResult;

            #endregion
        }
    }
}
