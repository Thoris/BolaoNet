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






            Domain.Services.Reports.BolaoMembroApostasReportService report = new Domain.Services.Reports.BolaoMembroApostasReportService(
                "thoris",
                kernel.Get<ILogging>(),
                kernel.Get<IBolaoService>(),
                kernel.Get<IApostaExtraUsuarioService>(),
                kernel.Get<IJogoUsuarioService>(),
                kernel.Get<IUserService>(),
                kernel.Get<IBolaoCampeonatoClassificacaoUsuarioService>(),
                kernel.Get<ICampeonatoGrupoApp>(),
                kernel.Get<ICampeonatoApp>(),
                new Infra.Reports.Pdf.PdfBolaoMembroApostasReport()
                );

            Stream res =
                report.Generate("", "", "",
                report.GetData(new Domain.Entities.Boloes.Bolao("Copa do Mundo 2018"),
                new Domain.Entities.Users.User("thoris")));


            StreamWriter writer = new StreamWriter(res);
            





            CopaDoMundoTests.BolaoCopaDoMundoTests.BolaoCopaMundo2014UserApostasAppTests test;

            test = new CopaDoMundoTests.BolaoCopaDoMundoTests.BolaoCopaMundo2014UserApostasAppTests(
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


            //test.TestCreateBolaoCopaDoMundo2014();
            Domain.Entities.Boloes.Bolao bolao =new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014");

            test.CreateUserApostasFixo(bolao, "Usuario0x0", "usuario0x0@hotmail.com", 0, 0);
            test.CreateUserApostasFixo(bolao, "Usuario1x0", "usuario0x0@hotmail.com", 1, 0);
            test.CreateUserApostasFixo(bolao, "Usuario0x1", "usuario0x0@hotmail.com", 0, 1);
            test.CreateUserApostasFixo(bolao, "Usuario1x1", "usuario0x0@hotmail.com", 1, 1); 
            test.CreateUserApostasFixo(bolao, "Usuario2x0", "usuario0x0@hotmail.com", 2, 0);
            test.CreateUserApostasFixo(bolao, "Usuario2x1", "usuario0x0@hotmail.com", 2, 1);
            test.CreateUserApostasFixo(bolao, "Usuario0x2", "usuario0x0@hotmail.com", 0, 2);
            test.CreateUserApostasFixo(bolao, "Usuario1x2", "usuario0x0@hotmail.com", 1, 2);
            test.CreateUserApostasFixo(bolao, "Usuario2x2", "usuario0x0@hotmail.com", 2, 2);
           


            Pontuacao.CalculoPontuacaoTests t = new Pontuacao.CalculoPontuacaoTests();
            t.TestAll();



            //Domain.Services.Reports.BolaoMembroApostasReportService report = new Domain.Services.Reports.BolaoMembroApostasReportService(
            //    "thoris",
            //    kernel.Get<ILogging>(),
            //    kernel.Get<IBolaoService>(),
            //    kernel.Get<IApostaExtraUsuarioService>(),
            //    kernel.Get<IJogoUsuarioService>(),
            //    kernel.Get<IUserService>(),
            //    new Infra.Reports.Pdf.PdfBolaoMembroApostasReport()
            //    );
            
            //Stream res =
            //    report.Generate("", "", "", 
            //    report.GetData(new Domain.Entities.Boloes.Bolao ("Copa do Mundo 2014"), new Domain.Entities.Users.User("thoris")));



            return;

            //ICopaMundo2014FacadeService copaFacadeService = kernel.Get<ICopaMundo2014FacadeService>();

            //IUserDao userDao = kernel.Get<IUserDao>();
            //IUserService userService = kernel.Get<IUserService>();
            //IUserApp userApp = kernel.Get<IUserApp>();
            





            test.TestUserManagement();
            //test.TestCreateBolaoCopaDoMundo2014();
        }

        #endregion
    }
}
