using BolaoNet.Application.Interfaces.Boloes;
using BolaoNet.Application.Interfaces.Campeonatos;
using BolaoNet.Application.Interfaces.Facade;
using BolaoNet.Application.Interfaces.Facade.Campeonatos;
using BolaoNet.Application.Interfaces.Feed;
using BolaoNet.Application.Interfaces.Notification;
using BolaoNet.Application.Interfaces.Reports;
using BolaoNet.Application.Interfaces.Users;
using BolaoNet.Tests;
using BolaoNet.Tests.CopaAmericaTests.BolaoCopaAmericaTests;
using BolaoNet.Tests.CopaDoMundoTests.BolaoCopaDoMundoTests;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.Tests
{
    public class BolaoCopaAmerica2019
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
            ICopaAmerica2019FacadeApp copaAmerica2019FacadeApp = kernel.Get<ICopaAmerica2019FacadeApp>();
            IBolaoAcertoTimePontoApp bolaoAcertoTimePontoApp = kernel.Get<IBolaoAcertoTimePontoApp>();


            IUserFacadeApp userFacadeApp = kernel.Get<IUserFacadeApp>();


            #endregion

            #region Inicialização de Dados

            campeonatoApp.ClearDatabase();

            initializationFacadeApp.InitAll();

            #endregion

            #region Copa 2019

            Domain.Entities.Campeonatos.Campeonato campeonato =
                copaAmerica2019FacadeApp.CreateCampeonato("Copa América 2019", false);

            BolaoCopaAmerica2019AppHelper bolaoHelper2019 = new BolaoCopaAmerica2019AppHelper(
                apostaExtraApp,
                bolaoApp,
                bolaoPremioApp,
                bolaoCriterioPontosApp,
                bolaoCriterioPontosTimesApp,
                bolaoRegraApp,
                bolaoPontuacaoApp,
                bolaoHistoricoApp,
                bolaoMembroApp,
                bolaoAcertoTimePontoApp);

            Domain.Entities.Boloes.Bolao bolao2018 = bolaoHelper2019.CreateBolao(campeonato);





            //bolaoHelper2018.(bolao2018.Nome);

            //bolaoApp.Iniciar(new Domain.Entities.Users.User("thoris"), bolao2010);


            //bolaoHelper2010.CreateApostasUsuarios(bolao.Nome);

            //copaMundo2010FacadeApp.InsertResults(campeonato2010.Nome, new Domain.Entities.Users.User("thoris"));

            #endregion
        }
    }
}
