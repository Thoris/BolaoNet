using BolaoNet.Application.Interfaces.Boloes;
using BolaoNet.Application.Interfaces.Campeonatos;
using BolaoNet.Application.Interfaces.Facade;
using BolaoNet.Application.Interfaces.Facade.Campeonatos;
using BolaoNet.Application.Interfaces.Feed;
using BolaoNet.Application.Interfaces.Notification;
using BolaoNet.Application.Interfaces.Reports;
using BolaoNet.Application.Interfaces.Users;
using BolaoNet.Tests;
using BolaoNet.Tests.CopaDoMundoTests.CopaDoMundo2014Tests;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.Tests
{
    public class BolaoCopa2018
    {

        public void TestFullCycle()
        {

            #region Declaração de Variáveis

            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

            IInitializationFacadeApp initializationFacadeApp = kernel.Get<IInitializationFacadeApp>();

            MVC.AutoMapper.AutoMapperConfig.RegisterMappings();

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
            ICopaMundo2018FacadeApp copaMundo2018FacadeApp = kernel.Get<ICopaMundo2018FacadeApp>();
            

            IUserFacadeApp userFacadeApp = kernel.Get<IUserFacadeApp>();
             

            #endregion

            #region Inicialização de Dados

            campeonatoApp.ClearDatabase();

            initializationFacadeApp.InitAll();

            #endregion

            #region Copa 2018

            Domain.Entities.Campeonatos.Campeonato campeonato2018 =
                copaMundo2018FacadeApp.CreateCampeonato("Copa do Mundo 2018", false);

            BolaoCopaMundo2018AppHelper bolaoHelper2018 = new BolaoCopaMundo2018AppHelper(
                apostaExtraApp,
                bolaoApp,
                bolaoPremioApp,
                bolaoCriterioPontosApp,
                bolaoCriterioPontosTimesApp,
                bolaoRegraApp,
                bolaoPontuacaoApp,
                bolaoHistoricoApp);

            Domain.Entities.Boloes.Bolao bolao2018 = bolaoHelper2018.CreateBolao(campeonato2018);

            //bolaoHelper2010.CreateApostasUsuarios(bolao2010.Nome);

            //bolaoApp.Iniciar(new Domain.Entities.Users.User("thoris"), bolao2010);


            //bolaoHelper2010.CreateApostasUsuarios(bolao.Nome);

            //copaMundo2010FacadeApp.InsertResults(campeonato2010.Nome, new Domain.Entities.Users.User("thoris"));

            #endregion
        }
    }
}
