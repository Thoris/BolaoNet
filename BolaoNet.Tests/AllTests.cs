using BolaoNet.Application.Interfaces.Boloes;
using BolaoNet.Application.Interfaces.Campeonatos;
using BolaoNet.Application.Interfaces.Facade;
using BolaoNet.Application.Interfaces.Facade.Campeonatos;
using BolaoNet.Application.Interfaces.Users;
using BolaoNet.Domain.Interfaces.Repositories.Users;
using BolaoNet.Domain.Interfaces.Services.Boloes;
using BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos;
using BolaoNet.Domain.Interfaces.Services.Logging;
using BolaoNet.Domain.Interfaces.Services.Users;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests
{
    public class AllTests
    {
        #region Methods

        public void Execute()
        {
            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();
            

            CopaDoMundoTests.CopaDoMundo2014Tests.BolaoCopaMundo2014UserApostasAppTests test;



            Pontuacao.CalculoPontuacaoTests t = new Pontuacao.CalculoPontuacaoTests();
            t.TestAll();



            Domain.Services.Reports.BolaoMembroApostasReportService report = new Domain.Services.Reports.BolaoMembroApostasReportService(
                "thoris",
                kernel.Get<ILogging>(),
                kernel.Get<IBolaoService>(),
                kernel.Get<IApostaExtraUsuarioService>(),
                kernel.Get<IJogoUsuarioService>(),
                kernel.Get<IUserService>(),
                new Infra.Reports.Pdf.PdfBolaoMembroApostasReport()
                );
            
            Stream res =
                report.Generate("", "", "", 
                report.GetData(new Domain.Entities.Boloes.Bolao ("Copa do Mundo 2014"), new Domain.Entities.Users.User("thoris")));



            return;

            //ICopaMundo2014FacadeService copaFacadeService = kernel.Get<ICopaMundo2014FacadeService>();

            //IUserDao userDao = kernel.Get<IUserDao>();
            //IUserService userService = kernel.Get<IUserService>();
            //IUserApp userApp = kernel.Get<IUserApp>();
            


            test = new CopaDoMundoTests.CopaDoMundo2014Tests.BolaoCopaMundo2014UserApostasAppTests(
                kernel.Get<IUserApp>(),
                kernel.Get<IJogoUsuarioApp>(),
                kernel.Get<IJogoApp>(),
                kernel.Get<IBolaoApp>(),
                kernel.Get<IBolaoMembroApp>(),
                kernel.Get<ICampeonatoApp>(),
                kernel.Get<IUserFacadeApp>(),
                kernel.Get<IApostaExtraApp>(),
                kernel.Get<ICopaMundo2014FacadeApp>()
                );


            test.TestUserManagement();
            //test.TestCreateBolaoCopaDoMundo2014();
        }

        #endregion
    }
}
