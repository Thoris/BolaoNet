//#define SAVE_DATA
//#define SAVE_CLASSIFICACAO

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
using System.IO;
using System.Diagnostics;
using System.Linq;
using BolaoNet.Application.Interfaces.Feed;

namespace BolaoNet.MVC.Tests
{
    [TestClass]    
    public class HappyWay
    {
        #region Variables

        private Dictionary<string, int> _pontuacao;

        #endregion

        [TestMethod]
        [Ignore]
        public void TestFullCycle2014()
        {

            #region Declaração de Variáveis

            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

            IInitializationFacadeApp initializationFacadeApp = kernel.Get<IInitializationFacadeApp>();

            MVC.AutoMapper.AutoMapperConfig.RegisterMappings();

            ICopaMundo2010FacadeApp copaMundo2010FacadeApp = kernel.Get<ICopaMundo2010FacadeApp>();
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
            IBolaoHistoricoApp bolaoHistoricoApp = kernel.Get<IBolaoHistoricoApp>();
            IRssApp rssApp = kernel.Get<IRssApp>();


            IUserFacadeApp userFacadeApp = kernel.Get<IUserFacadeApp>();

            //Mocks.HttpContextControllerMock mock = new Mocks.HttpContextControllerMock();

            #endregion

            #region Inicialização de Dados

            campeonatoApp.ClearDatabase();

            initializationFacadeApp.InitAll();



            #region Copa 2010

            //Domain.Entities.Campeonatos.Campeonato campeonato2010 =
            //    copaMundo2010FacadeApp.CreateCampeonato("Copa do Mundo 2010", false);

            //BolaoCopaMundo2010AppHelper bolaoHelper2010 = new BolaoCopaMundo2010AppHelper(
            //    apostaExtraApp,
            //    bolaoApp,
            //    bolaoPremioApp,
            //    bolaoCriterioPontosApp,
            //    bolaoCriterioPontosTimesApp,
            //    bolaoRegraApp,
            //    bolaoPontuacaoApp,
            //    bolaoHistoricoApp, 
            //    userApp, userFacadeApp, bolaoMembroApp, jogoUsuarioApp);

            //Domain.Entities.Boloes.Bolao bolao2010 = bolaoHelper2010.CreateBolao(campeonato2010);

            //bolaoHelper2010.CreateApostasUsuarios(bolao2010.Nome);

            //bolaoApp.Iniciar(new Domain.Entities.Users.User("thoris"), bolao2010);


            //bolaoHelper2010.CreateApostasUsuarios(bolao.Nome);

            //copaMundo2010FacadeApp.InsertResults(campeonato2010.Nome, new Domain.Entities.Users.User("thoris"));

            #endregion

            Domain.Entities.Campeonatos.Campeonato campeonato =
                copaMundo2014FacadeApp.CreateCampeonato("Copa do Mundo 2014", false);

            BolaoCopaMundo2014AppHelper bolaoHelper = new BolaoCopaMundo2014AppHelper(
                apostaExtraApp,
                bolaoApp,
                bolaoPremioApp,
                bolaoCriterioPontosApp,
                bolaoCriterioPontosTimesApp,
                bolaoRegraApp,
                bolaoPontuacaoApp,
                bolaoHistoricoApp);


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

            _pontuacao = new Dictionary<string, int>();
            

            for (int u = 0; u < apostasList.Length; u++)
            {
                

                #region Criação de Usuário

                int apostaTime1 = apostasList[u][0];
                int apostaTime2 = apostasList[u][1];

                _pontuacao.Add( "Usuario" + apostaTime1 + "x" + apostaTime2, 0);

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
                        ConfirmacaoEmail = "thorisbolaonet@gmail.com",
                        Email = "thorisbolaonet@gmail.com",
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
                    bolaoApostasFimReportApp,
                    notificationApp
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

#if (SAVE_CLASSIFICACAO)
            StreamWriter writerClassificacao = new StreamWriter("classificacao.txt", false, System.Text.Encoding.UTF8);
#endif

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
                        campeonatoTimeApp,
                        rssApp
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
                        campeonatoTimeApp,
                        bolaoPremioApp);

                Mocks.MvcMockHelpers.SetMockControllerContext(jogoResultadoController, userAdmin);

                var classificacaoView = bolaoClassificacaoController.Index() as ViewResult;

                Assert.IsNotNull(classificacaoView);
                Assert.IsNotNull(classificacaoView.Model);

                //IList<BolaoNet.MVC.ViewModels.Bolao.ClassificacaoViewModel> classificacaoModel =
                //    (IList<BolaoNet.MVC.ViewModels.Bolao.ClassificacaoViewModel>)classificacaoView.Model;

                //Assert.AreEqual(apostasList.Length, classificacaoModel.Count);






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
                        campeonatoTimeApp, 
                        bolaoCriterioPontosApp,
                        bolaoCriterioPontosTimesApp);


                Mocks.MvcMockHelpers.SetMockControllerContext(apostasJogoController, userAdmin);

                var apostasJogoView = apostasJogoController.Index(jogoResultadoView.JogoId) as ViewResult;

                Assert.IsNotNull(apostasJogoView);
                Assert.IsNotNull(apostasJogoView.Model);

                ViewModels.Bolao.ApostasJogoViewModel apostasJogoModel =
                    (ViewModels.Bolao.ApostasJogoViewModel)apostasJogoView.Model;

                Assert.AreEqual(apostasList.Length, apostasJogoModel.Apostas.Count);


                CheckClassificacao(
                    (string.Compare(jogoResultadoView.NomeTime1, "Brasil", true) == 0 || 
                    string.Compare(jogoResultadoView.NomeTime2, "Brasil", true) == 0),
                    jogoResultadoView.JogoId, 
                    jogoResultadoView.GolsTime1, 
                    jogoResultadoView.GolsTime2,
                    apostasJogoModel, 
                    (ViewModels.Bolao.BolaoClassificacaoViewModel)classificacaoView.Model
                    );

                #endregion


#if (SAVE_CLASSIFICACAO)
                ViewModels.Bolao.BolaoClassificacaoViewModel model =
                    (ViewModels.Bolao.BolaoClassificacaoViewModel)classificacaoView.Model;

                writerClassificacao.WriteLine("Rodada: " + jogoResultadoView.JogoId);

                writerClassificacao.WriteLine("//JOGO: " + apostasJogoModel.NomeTime1 + " " + jogoResultadoView.GolsTime1 + " x " + jogoResultadoView.GolsTime2 + " " + apostasJogoModel.NomeTime2);
                writerClassificacao.WriteLine("------------------------");



                writerClassificacao.Write("Po ");
                writerClassificacao.Write("Usuário".PadRight(15, ' ') + " ");
                writerClassificacao.Write("PTs" + " ");
                writerClassificacao.Write("Ch" + " ");
                writerClassificacao.Write("VD" + " ");
                writerClassificacao.Write("De" + " ");
                writerClassificacao.Write("Em" + " ");
                writerClassificacao.Write("Vi" + " ");
                writerClassificacao.Write("G1" + " ");
                writerClassificacao.Write("G2" + " ");
                writerClassificacao.Write("Ex" + " ");
                writerClassificacao.WriteLine();     

                for (int i = 0; i < model.Classificacao.Count; i++)
                {
                    writerClassificacao.Write(((int)(model.Classificacao[i].Posicao ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(model.Classificacao[i].UserName.ToString().PadRight(15, ' ') + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalPontos ?? 0)).ToString("000") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalPlacarCheio ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalVDE ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalDerrota ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalEmpate ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalVitoria ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalResultTime1 ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalResultTime2 ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalApostaExtra ?? 0)).ToString("00") + " ");
                    writerClassificacao.WriteLine();     
                }
#endif
            }

#if (SAVE_CLASSIFICACAO)
            writerClassificacao.Close ();
#endif


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

        [TestMethod]
        [Ignore]
        public void TestFullCycle()
        {

            #region Declaração de Variáveis

            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

            IInitializationFacadeApp initializationFacadeApp = kernel.Get<IInitializationFacadeApp>();

            MVC.AutoMapper.AutoMapperConfig.RegisterMappings();

            ICopaMundo2010FacadeApp copaMundo2010FacadeApp = kernel.Get<ICopaMundo2010FacadeApp>();
            ICopaMundo2014FacadeApp copaMundo2018FacadeApp = kernel.Get<ICopaMundo2014FacadeApp>();
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
            IBolaoHistoricoApp bolaoHistoricoApp = kernel.Get<IBolaoHistoricoApp>();
            IRssApp rssApp = kernel.Get<IRssApp>();


            IUserFacadeApp userFacadeApp = kernel.Get<IUserFacadeApp>();

            //Mocks.HttpContextControllerMock mock = new Mocks.HttpContextControllerMock();

            #endregion

            #region Inicialização de Dados

            campeonatoApp.ClearDatabase();

            initializationFacadeApp.InitAll();



            #region Copa 2010

            //Domain.Entities.Campeonatos.Campeonato campeonato2010 =
            //    copaMundo2010FacadeApp.CreateCampeonato("Copa do Mundo 2010", false);

            //BolaoCopaMundo2010AppHelper bolaoHelper2010 = new BolaoCopaMundo2010AppHelper(
            //    apostaExtraApp,
            //    bolaoApp,
            //    bolaoPremioApp,
            //    bolaoCriterioPontosApp,
            //    bolaoCriterioPontosTimesApp,
            //    bolaoRegraApp,
            //    bolaoPontuacaoApp,
            //    bolaoHistoricoApp, 
            //    userApp, userFacadeApp, bolaoMembroApp, jogoUsuarioApp);

            //Domain.Entities.Boloes.Bolao bolao2010 = bolaoHelper2010.CreateBolao(campeonato2010);

            //bolaoHelper2010.CreateApostasUsuarios(bolao2010.Nome);

            //bolaoApp.Iniciar(new Domain.Entities.Users.User("thoris"), bolao2010);


            //bolaoHelper2010.CreateApostasUsuarios(bolao.Nome);

            //copaMundo2010FacadeApp.InsertResults(campeonato2010.Nome, new Domain.Entities.Users.User("thoris"));

            #endregion

            Domain.Entities.Campeonatos.Campeonato campeonato =
                copaMundo2018FacadeApp.CreateCampeonato("Copa do Mundo 2018", false);

            BolaoCopaMundo2014AppHelper bolaoHelper = new BolaoCopaMundo2014AppHelper(
                apostaExtraApp,
                bolaoApp,
                bolaoPremioApp,
                bolaoCriterioPontosApp,
                bolaoCriterioPontosTimesApp,
                bolaoRegraApp,
                bolaoPontuacaoApp,
                bolaoHistoricoApp);


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
                
                //9
                new int [] {3,0},
                new int [] {3,1},
                new int [] {3,2},
                new int [] {3,3},
                new int [] {3,4},
                new int [] {3,5},
                new int [] {3,6},
                new int [] {3,7},
                new int [] {3,8},

                //18
                new int [] {4,0},
                new int [] {4,1},
                new int [] {4,2},
                new int [] {4,3},
                new int [] {4,4},
                new int [] {4,5},
                new int [] {4,6},
                new int [] {4,7},
                new int [] {4,8},

                //27
                new int [] {5,0},
                new int [] {5,1},
                new int [] {5,2},
                new int [] {5,3},
                new int [] {5,4},
                new int [] {5,5},
                new int [] {5,6},
                new int [] {5,7},
                new int [] {5,8},
            
                //36
                new int [] {6,0},
                new int [] {6,1},
                new int [] {6,2},
                new int [] {6,3},
                new int [] {6,4},
                new int [] {6,5},
                new int [] {6,6},
                new int [] {6,7},
                new int [] {6,8},

                //45
                new int [] {7,0},
                new int [] {7,1},
                new int [] {7,2},
                new int [] {7,3},
                new int [] {7,4},
                new int [] {7,5},
                new int [] {7,6},
                new int [] {7,7},
                new int [] {7,8},

                //54
            };

            _pontuacao = new Dictionary<string, int>();


            for (int u = 0; u < apostasList.Length; u++)
            {


                #region Criação de Usuário

                int apostaTime1 = apostasList[u][0];
                int apostaTime2 = apostasList[u][1];

                _pontuacao.Add("Usuario" + apostaTime1 + "x" + apostaTime2, 0);

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
                        ConfirmacaoEmail = "thorisbolaonet@gmail.com",
                        Email = "thorisbolaonet@gmail.com",
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
                    bolaoApostasFimReportApp,
                    notificationApp
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

#if (SAVE_CLASSIFICACAO)
            StreamWriter writerClassificacao = new StreamWriter("classificacao.txt", false, System.Text.Encoding.UTF8);
#endif

            for (int c = 0; c < jogoLabels.Count; c++)
            {
                #region Inclusão de Resultado


                MVC.Areas.Campeonatos.Controllers.JogosController jogosController =
                    new Areas.Campeonatos.Controllers.JogosController(
                        jogoApp,
                        campeonatoApp,
                        campeonatoFaseApp,
                        campeonatoGrupoApp,
                        campeonatoTimeApp
                        );

                Mocks.MvcMockHelpers.SetMockControllerContext(jogosController, userAdmin);
                jogosController.LoadCampeonatoData();

                var jogosView = jogosController.Index(new ViewModels.Campeonatos.CampeonatoJogosListViewModel()) as ViewResult;



                MVC.Areas.Resultados.Controllers.JogoResultadoController jogoResultadoController =
                    new Areas.Resultados.Controllers.JogoResultadoController(
                        bolaoMembroApp,
                        bolaoApp,
                        jogoApp,
                        campeonatoApp,
                        campeonatoFaseApp,
                        campeonatoGrupoApp,
                        campeonatoTimeApp,
                        rssApp
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
                        campeonatoTimeApp,
                        bolaoPremioApp);

                Mocks.MvcMockHelpers.SetMockControllerContext(jogoResultadoController, userAdmin);

                var classificacaoView = bolaoClassificacaoController.Index() as ViewResult;

                Assert.IsNotNull(classificacaoView);
                Assert.IsNotNull(classificacaoView.Model);

                //IList<BolaoNet.MVC.ViewModels.Bolao.ClassificacaoViewModel> classificacaoModel =
                //    (IList<BolaoNet.MVC.ViewModels.Bolao.ClassificacaoViewModel>)classificacaoView.Model;

                //Assert.AreEqual(apostasList.Length, classificacaoModel.Count);






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
                        campeonatoTimeApp,
                        bolaoCriterioPontosApp,
                        bolaoCriterioPontosTimesApp);


                Mocks.MvcMockHelpers.SetMockControllerContext(apostasJogoController, userAdmin);

                var apostasJogoView = apostasJogoController.Index(jogoResultadoView.JogoId) as ViewResult;

                Assert.IsNotNull(apostasJogoView);
                Assert.IsNotNull(apostasJogoView.Model);

                ViewModels.Bolao.ApostasJogoViewModel apostasJogoModel =
                    (ViewModels.Bolao.ApostasJogoViewModel)apostasJogoView.Model;

                Assert.AreEqual(apostasList.Length, apostasJogoModel.Apostas.Count);


                CheckClassificacao(
                    (string.Compare(jogoResultadoView.NomeTime1, "Brasil", true) == 0 ||
                    string.Compare(jogoResultadoView.NomeTime2, "Brasil", true) == 0),
                    jogoResultadoView.JogoId,
                    jogoResultadoView.GolsTime1,
                    jogoResultadoView.GolsTime2,
                    apostasJogoModel,
                    (ViewModels.Bolao.BolaoClassificacaoViewModel)classificacaoView.Model
                    );

                #endregion


#if (SAVE_CLASSIFICACAO)
                ViewModels.Bolao.BolaoClassificacaoViewModel model =
                    (ViewModels.Bolao.BolaoClassificacaoViewModel)classificacaoView.Model;

                writerClassificacao.WriteLine("Rodada: " + jogoResultadoView.JogoId);

                writerClassificacao.WriteLine("//JOGO: " + apostasJogoModel.NomeTime1 + " " + jogoResultadoView.GolsTime1 + " x " + jogoResultadoView.GolsTime2 + " " + apostasJogoModel.NomeTime2);
                writerClassificacao.WriteLine("------------------------");



                writerClassificacao.Write("Po ");
                writerClassificacao.Write("Usuário".PadRight(15, ' ') + " ");
                writerClassificacao.Write("PTs" + " ");
                writerClassificacao.Write("Ch" + " ");
                writerClassificacao.Write("VD" + " ");
                writerClassificacao.Write("De" + " ");
                writerClassificacao.Write("Em" + " ");
                writerClassificacao.Write("Vi" + " ");
                writerClassificacao.Write("G1" + " ");
                writerClassificacao.Write("G2" + " ");
                writerClassificacao.Write("Ex" + " ");
                writerClassificacao.WriteLine();     

                for (int i = 0; i < model.Classificacao.Count; i++)
                {
                    writerClassificacao.Write(((int)(model.Classificacao[i].Posicao ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(model.Classificacao[i].UserName.ToString().PadRight(15, ' ') + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalPontos ?? 0)).ToString("000") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalPlacarCheio ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalVDE ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalDerrota ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalEmpate ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalVitoria ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalResultTime1 ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalResultTime2 ?? 0)).ToString("00") + " ");
                    writerClassificacao.Write(((int)(model.Classificacao[i].TotalApostaExtra ?? 0)).ToString("00") + " ");
                    writerClassificacao.WriteLine();     
                }
#endif
            }

#if (SAVE_CLASSIFICACAO)
            writerClassificacao.Close ();
#endif


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

            apostaExtraModel.Add(new ViewModels.Resultados.ApostaExtraViewModel()
            {
                NomeBolao = bolao.Nome,
                Posicao = 1,
                NomeTimeValidado = "Alemanha",
                SalvarNomeTime = null,
            });
            apostaExtraModel.Add(new ViewModels.Resultados.ApostaExtraViewModel()
            {
                NomeBolao = bolao.Nome,
                Posicao = 2,
                NomeTimeValidado = "Argentina",
                SalvarNomeTime = null,
            });
            apostaExtraModel.Add(new ViewModels.Resultados.ApostaExtraViewModel()
            {
                NomeBolao = bolao.Nome,
                Posicao = 3,
                NomeTimeValidado = "Holanda",
                SalvarNomeTime = null,
            });
            apostaExtraModel.Add(new ViewModels.Resultados.ApostaExtraViewModel()
            {
                NomeBolao = bolao.Nome,
                Posicao = 4,
                NomeTimeValidado = "Brasil",
                SalvarNomeTime = null,
            });

            var apostaExtraView = apostasExtrasResultadoController.Salvar(apostaExtraModel) as ViewResult;

            #endregion
        }

        private void CheckPosition(IOrderedEnumerable<KeyValuePair<string, int>> list, string userName, int posicao, int pontos, ViewModels.Bolao.BolaoClassificacaoViewModel bolaoClassificacaoModel)
        {
            int pos = 0;
            int pt = -1;
            int count = 1;
            foreach (KeyValuePair<string, int> pair in list)
            {
                if (pt != pair.Value)
                {
                    pos = count;
                    pt = pair.Value;
                }


                if (string.Compare (pair.Key, userName, true) == 0)
                {
                    Assert.AreEqual(posicao, pos );
                    Assert.AreEqual(pontos, pt);
                    break;
                }
                count++;
            }

            for (int c=0; c < bolaoClassificacaoModel.Classificacao.Count; c++)
            {
                if (string.Compare (bolaoClassificacaoModel.Classificacao[c].UserName, userName, true) == 0)
                {
                    Assert.AreEqual(posicao, bolaoClassificacaoModel.Classificacao[c].Posicao);
                    Assert.AreEqual(pontos, bolaoClassificacaoModel.Classificacao[c].TotalPontos);
                    return;
                }
            }

        }
        private void CheckClassificacao(bool isMultiploTime, int idJogo, int time1, int time2, ViewModels.Bolao.ApostasJogoViewModel apostasJogoModel, ViewModels.Bolao.BolaoClassificacaoViewModel bolaoClassificacaoModel)
        {

            for (int c = 0; c < apostasJogoModel.Apostas.Count; c++)
            {
                _pontuacao[apostasJogoModel.Apostas[c].UserName] += (int)apostasJogoModel.Apostas[c].Pontos;
            }

            var sortedDict = from entry in _pontuacao orderby entry.Value descending select entry;

#if(SAVE_DATA)
            StreamWriter writer = new StreamWriter("log.txt", true);
            int pos = 0;
            int pt = -1;
            int count = 1;

            writer.WriteLine("//JOGO: " + apostasJogoModel.NomeTime1 + " " + time1 + " x " +
                time2 + " " + apostasJogoModel.NomeTime2);
            writer.WriteLine("case " + idJogo + ":");

            foreach (KeyValuePair<string, int> pair in sortedDict)
            {
                if (pt != pair.Value)
                {
                    pos = count;
                    pt = pair.Value;
                }

                writer.WriteLine("CheckPosition(sortedDict, \"" + pair.Key + "\", " + pos + ", " + pt + ", bolaoClassificacaoModel);");
                count++;
            }

            writer.WriteLine("break;");

            writer.Close();
#endif


            //return;


            switch(idJogo)
            {
                //JOGO: Brasil 3 x 1 Croácia
                case 1:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 8, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 6, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 2, 6, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 4, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 0, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 0, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 0, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 6, 0, bolaoClassificacaoModel);
                    break;
                //JOGO: México 1 x 0 Camarões
                case 2:
                    CheckPosition(sortedDict, "Usuario1x0", 1, 16, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x1", 2, 11, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 4, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 1, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 1, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 0, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 0, bolaoClassificacaoModel);
                    break;
                //JOGO: Espanha 1 x 5 Holanda
                case 3:
                    CheckPosition(sortedDict, "Usuario1x0", 1, 17, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x1", 2, 11, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 4, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 1, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 0, bolaoClassificacaoModel);
                    break;
                //JOGO: Chile 3 x 1 Austrália
                case 4:
                    CheckPosition(sortedDict, "Usuario1x0", 1, 20, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x1", 2, 15, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 13, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 6, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 1, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 0, bolaoClassificacaoModel);
                    break;
                //JOGO: Colômbia 3 x 0 Grécia
                case 5:
                    CheckPosition(sortedDict, "Usuario1x0", 1, 24, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x1", 2, 18, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 17, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 6, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 0, bolaoClassificacaoModel);
                    break;
                //JOGO: Costa do Marfim 2 x 1 Japão
                case 6:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 28, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 27, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 21, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 7, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 6, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 5, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 1, bolaoClassificacaoModel);
                    break;
                //JOGO: Uruguai 1 x 3 Costa Rica
                case 7:
                    CheckPosition(sortedDict, "Usuario1x0", 1, 28, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x1", 1, 28, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 21, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 9, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 7, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 6, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 1, bolaoClassificacaoModel);
                    break;
                //JOGO: Inglaterra 1 x 2 Itália
                case 8:
                    CheckPosition(sortedDict, "Usuario1x0", 1, 29, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x1", 2, 28, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 21, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 13, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 8, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 2, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 2, bolaoClassificacaoModel);
                    break;
                //JOGO: Suíça 2 x 1 Equador
                case 9:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 38, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 32, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 25, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 14, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 9, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 9, 2, bolaoClassificacaoModel);
                    break;
                //JOGO: França 3 x 0 Honduras
                case 10:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 41, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 36, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 29, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 14, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 9, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 3, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 3, bolaoClassificacaoModel);
                    break;
                //JOGO: Argentina 2 x 1 Bósnia e Herzegovina
                case 11:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 39, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 33, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 15, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 10, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 4, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 9, 3, bolaoClassificacaoModel);
                    break;
                //JOGO: Irã 0 x 0 Nigéria
                case 12:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 34, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 16, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 15, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 7, 13, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 11, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 9, bolaoClassificacaoModel);
                    break;
                //JOGO: Alemanha 4 x 0 Portugal
                case 13:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 54, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 44, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 38, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 16, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 15, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 7, 14, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 11, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 9, bolaoClassificacaoModel);
                    break;
                //JOGO: Gana 1 x 2 Estados Unidos
                case 14:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 54, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 45, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 38, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 29, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 16, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 15, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 14, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 10, bolaoClassificacaoModel);
                    break;
                //JOGO: Bélgica 2 x 1 Argélia
                case 15:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 48, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 42, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 29, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 20, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 17, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 15, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 8, 14, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 11, bolaoClassificacaoModel);
                    break;
                //JOGO: Rússia 1 x 1 Coreia do Sul
                case 16:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 49, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 42, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 30, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 27, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 21, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 7, 19, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 16, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 15, bolaoClassificacaoModel);
                    break;
                //JOGO: Brasil 0 x 0 México
                case 17:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 44, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 39, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 37, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 30, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 26, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 8, 23, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 17, bolaoClassificacaoModel);
                    break;
                //JOGO: Camarões 0 x 4 Croácia
                case 18:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 44, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 37, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 33, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 7, 27, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 26, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 21, bolaoClassificacaoModel);
                    break;
                //JOGO: Espanha 2 x 3 Chile
                case 19:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 66, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 45, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 37, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 36, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 7, 30, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 27, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 24, bolaoClassificacaoModel);
                    break;
                //JOGO: Austrália 0 x 2 Holanda
                case 20:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 66, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 45, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 41, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 37, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 7, 34, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 34, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 28, bolaoClassificacaoModel);
                    break;
                //JOGO: Colômbia 2 x 1 Costa do Marfim
                case 21:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 76, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 54, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 49, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 41, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 38, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 7, 35, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 34, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 29, bolaoClassificacaoModel);
                    break;
                //JOGO: Japão 0 x 0 Grécia
                case 22:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 76, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 55, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 3, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 50, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 43, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 7, 36, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 35, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 34, bolaoClassificacaoModel);
                    break;
                //JOGO: Uruguai 2 x 1 Inglaterra
                case 23:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 86, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 54, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 51, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 5, 44, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 40, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 7, 37, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 35, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 35, bolaoClassificacaoModel);
                    break;
                //JOGO: Itália 0 x 1 Costa Rica
                case 24:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 87, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 54, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 52, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 47, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 45, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 7, 43, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 39, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 35, bolaoClassificacaoModel);
                    break;
                //JOGO: Suíça 2 x 5 França
                case 25:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 55, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 52, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 50, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 46, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 45, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 42, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 36, bolaoClassificacaoModel);
                    break;
                //JOGO: Honduras 1 x 2 Equador
                case 26:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 59, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 56, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 55, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 52, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 46, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 46, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 37, bolaoClassificacaoModel);
                    break;
                //JOGO: Argentina 1 x 0 Irã
                case 27:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 91, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 69, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 59, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 57, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 47, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 46, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 37, bolaoClassificacaoModel);
                    break;
                //JOGO: Nigéria 1 x 0 Bósnia e Herzegovina
                case 28:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 94, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 63, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 54, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 48, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 46, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 37, bolaoClassificacaoModel);
                    break;
                //JOGO: Alemanha 2 x 2 Gana
                case 29:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 95, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 59, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 59, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 47, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 47, bolaoClassificacaoModel);
                    break;
                //JOGO: Estados Unidos 2 x 2 Portugal
                case 30:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 96, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 60, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 57, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 8, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 48, bolaoClassificacaoModel);
                    break;
                //JOGO: Bélgica 1 x 0 Rússia
                case 31:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 99, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 69, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 61, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 59, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 57, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 8, 53, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 48, bolaoClassificacaoModel);
                    break;
                //JOGO: Coreia do Sul 2 x 4 Argélia
                case 32:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 70, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 5, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 6, 59, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 8, 56, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 51, bolaoClassificacaoModel);
                    break;
                //JOGO: Camarões 1 x 4 Brasil
                case 33:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 91, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 72, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 70, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 62, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 61, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 58, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 57, bolaoClassificacaoModel);
                    break;
                //JOGO: Croácia 1 x 3 México
                case 34:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 92, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 76, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 70, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 62, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 60, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 58, bolaoClassificacaoModel);
                    break;
                //JOGO: Austrália 0 x 3 Espanha
                case 35:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 92, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 70, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 69, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 66, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 62, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 58, bolaoClassificacaoModel);
                    break;
                //JOGO: Holanda 2 x 0 Chile
                case 36:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 104, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 96, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 80, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 69, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 67, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 62, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 59, bolaoClassificacaoModel);
                    break;
                //JOGO: Japão 1 x 4 Colômbia
                case 37:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 104, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 97, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 83, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 80, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 72, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 67, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 67, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 63, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 59, bolaoClassificacaoModel);
                    break;
                //JOGO: Grécia 2 x 1 Costa do Marfim
                case 38:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 114, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 3, 84, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 83, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 73, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 67, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 67, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 64, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 60, bolaoClassificacaoModel);
                    break;
                //JOGO: Itália 0 x 1 Uruguai
                case 39:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 115, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 86, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 84, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 83, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 6, 71, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 7, 68, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 65, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 60, bolaoClassificacaoModel);
                    break;
                //JOGO: Costa Rica 0 x 0 Inglaterra
                case 40:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 115, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 101, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 86, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 4, 85, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 84, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 78, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 72, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 70, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 65, bolaoClassificacaoModel);
                    break;
                //JOGO: Honduras 0 x 3 Suíça
                case 41:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 115, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 101, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 85, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 76, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 70, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 65, bolaoClassificacaoModel);
                    break;
                //JOGO: Equador 0 x 0 França
                case 42:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 115, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 3, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 3, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 86, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 77, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 75, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 70, bolaoClassificacaoModel);
                    break;
                //JOGO: Nigéria 2 x 3 Argentina
                case 43:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 116, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 3, 92, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 3, 92, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 87, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 80, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 75, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 71, bolaoClassificacaoModel);
                    break;
                //JOGO: Bósnia e Herzegovina 3 x 1 Irã
                case 44:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 120, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 105, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 3, 93, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 92, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 90, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 80, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 76, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 71, bolaoClassificacaoModel);
                    break;
                //JOGO: Estados Unidos 0 x 1 Alemanha
                case 45:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 121, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 105, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 3, 103, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 95, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 90, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 90, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 84, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 77, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 71, bolaoClassificacaoModel);
                    break;
                //JOGO: Portugal 2 x 1 Gana
                case 46:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 131, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 108, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 3, 104, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 95, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 94, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 90, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 84, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 78, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 72, bolaoClassificacaoModel);
                    break;
                //JOGO: Coreia do Sul 0 x 1 Bélgica
                case 47:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 132, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 2, 114, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 108, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 98, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 94, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 91, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 7, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 8, 79, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 72, bolaoClassificacaoModel);
                    break;
                //JOGO: Argélia 1 x 1 Rússia
                case 48:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 133, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 2, 115, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 109, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 4, 99, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 96, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 94, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 7, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 77, bolaoClassificacaoModel);
                    break;
                //JOGO: Brasil 1 x 1 Chile
                case 49:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 135, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 2, 117, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 111, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 4, 109, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 106, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 6, 101, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 7, 94, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 9, 87, bolaoClassificacaoModel);
                    break;
                //JOGO: Colômbia 2 x 0 Uruguai
                case 50:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 139, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 2, 117, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 115, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 4, 109, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 107, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 104, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 7, 101, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 8, 88, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 88, bolaoClassificacaoModel);
                    break;
                //JOGO: Holanda 2 x 1 México
                case 51:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 149, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 2, 118, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 118, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 4, 110, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 108, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 107, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 7, 101, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 89, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 88, bolaoClassificacaoModel);
                    break;
                //JOGO: Costa Rica 1 x 1 Grécia
                case 52:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 150, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 2, 120, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 3, 119, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 119, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 5, 112, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 108, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 7, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 94, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 88, bolaoClassificacaoModel);
                    break;
                //JOGO: França 2 x 0 Nigéria
                case 53:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 154, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 2, 123, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 120, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 119, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 118, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 6, 113, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 7, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 95, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 88, bolaoClassificacaoModel);
                    break;
                //JOGO: Alemanha 0 x 0 Argélia
                case 54:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 154, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 2, 125, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 124, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 4, 123, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 120, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 119, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 7, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 8, 100, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 89, bolaoClassificacaoModel);
                    break;
                //JOGO: Argentina 0 x 0 Suíça
                case 55:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 154, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 133, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 130, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 125, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 121, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 120, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 105, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 90, bolaoClassificacaoModel);
                    break;
                //JOGO: Bélgica 0 x 0 Estados Unidos
                case 56:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 154, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 143, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 135, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 126, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 122, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 121, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 110, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 91, bolaoClassificacaoModel);
                    break;
                //JOGO: Brasil 2 x 1 Colômbia
                case 57:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 174, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 143, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 137, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 132, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 129, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 124, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 112, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 102, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 91, bolaoClassificacaoModel);
                    break;
                //JOGO: França 0 x 1 Alemanha
                case 58:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 175, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 144, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 138, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 134, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 5, 132, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 129, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 112, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 105, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 95, bolaoClassificacaoModel);
                    break;
                //JOGO: Holanda 0 x 0 Costa Rica
                case 59:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 175, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 154, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 143, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 4, 135, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 5, 133, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 130, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 117, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 105, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 96, bolaoClassificacaoModel);
                    break;
                //JOGO: Argentina 1 x 0 Bélgica
                case 60:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 178, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 155, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 144, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 143, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 135, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 134, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 117, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 106, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 96, bolaoClassificacaoModel);
                    break;
                //JOGO: Brasil 1 x 7 Alemanha
                case 61:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 178, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 155, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 146, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 145, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 141, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 134, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 117, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 114, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 102, bolaoClassificacaoModel);
                    break;
                //JOGO: Holanda 0 x 0 Argentina
                case 62:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 178, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 165, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 151, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 146, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 5, 142, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 6, 135, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 122, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 114, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 103, bolaoClassificacaoModel);
                    break;
                //JOGO: Brasil 3 x 0 Holanda
                case 63:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 184, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 167, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 3, 154, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 4, 151, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 143, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 142, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 122, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 114, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 103, bolaoClassificacaoModel);
                    break;
                //JOGO: Alemanha 0 x 0 Argentina
                case 64:
                    CheckPosition(sortedDict, "Usuario2x1", 1, 184, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x0", 2, 177, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x1", 3, 156, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x0", 4, 155, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x0", 5, 144, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x1", 6, 143, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario2x2", 7, 127, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario1x2", 8, 114, bolaoClassificacaoModel);
                    CheckPosition(sortedDict, "Usuario0x2", 9, 104, bolaoClassificacaoModel);
                    break;

            }
        }

        //public void TestGeneratePdfMembro()
        //{

        //    Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

        //    IBolaoMembroApostasReportApp _bolaoMembroApostasReportApp = 
        //        kernel.Get<IBolaoMembroApostasReportApp>();

        //    IBolaoMembroApostasReportApp bolaoMembroApostasReportApp =
        //        kernel.Get<IBolaoMembroApostasReportApp>();


        //    Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data =
        //        _bolaoMembroApostasReportApp.GetData(
        //            new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014"),
        //            new Domain.Entities.Users.User("usuario1x1"));

        //    Stream streamReport = bolaoMembroApostasReportApp.Generate(
        //        "gif",
        //        @"..\..\..\BolaoNet.MVC\Content\img\database\profiles2",
        //        @"..\..\..\BolaoNet.MVC\Content\img\database\times2", 
        //        data);

        //    if (System.IO.File.Exists("file.pdf"))
        //        System.IO.File.Delete("file.pdf");

        //    using (var fileStream = File.Create("file.pdf"))
        //    {
        //        streamReport.Seek(0, SeekOrigin.Begin);
        //        streamReport.CopyTo(fileStream);
        //    }

        //    Process.Start("file.pdf");
             
        //}
    }
}
