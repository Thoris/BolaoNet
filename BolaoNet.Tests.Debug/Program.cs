using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Debug
{
     
    class Program
    {

        static void Main(string[] args)
        {
            //ApartmentState state  = Thread.CurrentThread.GetApartmentState();
            //Thread t = new Thread(new ThreadStart(delegate()
            //{
            //    using (var browser = new IE())
            //    {
            //        browser.GoTo("http://thorisbolaonet.somee.com/Account/Login");
            //        browser.Page<Exploratory.Watin.Pages.LoginPage>().Logon("usuario0x0", "thoris", false);
            //        //Assert.IsTrue(browser.ContainsText("WatiN"));
            //    }
            //}));
            //t.ApartmentState = ApartmentState.STA;
            //t.Start();
            //t.Join();







            BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock m = new LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock();
            Domain.Interfaces.Repositories.DadosBasicos.ITimeDao dao = m.Setup();

            //long total = dao.Count();
            //ICollection<Domain.Entities.DadosBasicos.Time> list = dao.GetAll();
            //dao.Insert(new Domain.Entities.DadosBasicos.Time("T"));
            //dao.Load(new Domain.Entities.DadosBasicos.Time("T"));
            //dao.Delete(new Domain.Entities.DadosBasicos.Time("T"));


            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao> x = new LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao>(dao);

            x.TestInsert();
            x.TestGetAll();
            
            x.TestDelete();
            x.TestGetAll();
            x.TestGetList();
            x.TestLoad();
            x.TestUpdate();

            x.TestCount();
            x.TestCountWhere();
            


            //new Tests.AllTests().Execute();
            new MVC.Tests.Execution().Execute();

            //Domain.Interfaces.Services.Boloes.IBolaoService b =
            //     new BolaoNet.Application.FactoryApp("thoris", "http://localhost:9586/").CreateBolaoService();

            //b.Load(new Domain.Entities.Boloes.Bolao("Copa do Mundio 2014"));
            //b.Iniciar(new Domain.Entities.Users.User("thoris"), new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014"));



            //Dao.EF.UnitOfWork uow = new Dao.EF.UnitOfWork();

            //Dao.EF.Campeonatos.CampeonatoRepositoryDao dao = new Dao.EF.Campeonatos.CampeonatoRepositoryDao(uow);
            //dao.Load(new Entities.Campeonatos.Campeonato());

            //DAO
            //BolaoNet.Dao.IFactoryDao factoryDao = new BolaoNet.Dao.EF.FactoryDaoEF();


            //Dao.Boloes.IJogoUsuarioDao test = factoryDao.CreateJogoUsuarioDao();
            //test.CalculeTime("teste", DateTime.Now,
            //    new Entities.Boloes.Bolao("Copa do Mundo 2014"),
            //    new Entities.Users.User("thoris"),
            //    new Entities.DadosBasicos.Time("Brasil"),
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"));


            //test.CalculeGrupo("teste", DateTime.Now,
            //    new Entities.Boloes.Bolao("Copa do Mundo 2014"),
            //    new Entities.Users.User("thoris"),
            //    new Entities.Campeonatos.Campeonato("Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"));

            //test.CalculeDependencia("teste", DateTime.Now,
            //    new Entities.Boloes.Bolao("Copa do Mundo 2014"),
            //    new Entities.Users.User("thoris"),
            //    new Entities.Campeonatos.Jogo("Copa do Mundo 2014", 1) { NomeTime1 = "Brasil", NomeTime2 = "Croácia" },
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"), 1, 1, 2, 1);

            //test.CalculeFinal("teste", DateTime.Now,
            //    new Entities.Boloes.Bolao("Copa do Mundo 2014"),
            //    new Entities.Users.User("thoris"),
            //    new Entities.Campeonatos.Jogo("Copa do Mundo 2014", 1) { NomeTime1 = "Brasil", NomeTime2 = "Croácia" },
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"), 1, 1, 2, 1);


            //test.CalculePontos("teste", DateTime.Now,
            //    1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, true, 1, new Entities.Boloes.JogoUsuario());

            //test.ProcessAposta("teste", DateTime.Now,
            //    new Entities.Boloes.Bolao("Copa do Mundo 2014"),
            //    new Entities.Users.User("thoris"),
            //    new Entities.Campeonatos.Jogo("Copa do Mundo 2014", 1),
            //    0, 1, 1, 2, 1, null);


            //test.Validacao("teste", DateTime.Now, new Entities.Campeonatos.Jogo("Copa do Mundo 2014", 1),
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"), 1, new Entities.DadosBasicos.Time("Brasil"),
            //    new Entities.DadosBasicos.Time("Croácia"), 1, 2, 0, 0, new Entities.Users.User("thoris"));


            //Dao.Boloes.IBolaoMembroDao test2 = factoryDao.CreateBolaoMembroDao();
            //test2.OrganizePontosRodada("teste", DateTime.Now,
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"), new Entities.Boloes.Bolao("Copa do Mundo 2014"), 1);


            //int pontosEmpate, pontosVitoria, pontosDerrota, pontosGanhador, pontosPerdedor, pontosTime1, pontosTime2, 
            //    pontosVDE, pontosErro, pontosGanhadorFora, pontosGanhadorDentro, pontosPerdedorFora, 
            //    pontosPerdedorDentro, pontosEmpateGols, pontosGolsTime1, pontosGolsTime2, pontosCheio;

            //Dao.Boloes.IBolaoCriterioPontosDao test3 = factoryDao.CreateBolaoCriterioPontosDao();
            //test3.BuscaPontos("teste", DateTime.Now, new Entities.Boloes.Bolao("Copa do Mundo 2014"),
            //    out pontosEmpate, out pontosVitoria, out pontosDerrota, out pontosGanhador, out pontosPerdedor, out pontosTime1, out pontosTime2,
            //    out pontosVDE, out pontosErro, out pontosGanhadorFora, out pontosGanhadorDentro, out pontosPerdedorFora,
            //    out pontosPerdedorDentro, out pontosEmpateGols, out pontosGolsTime1, out pontosGolsTime2, out pontosCheio);

            //Dao.Campeonatos.ICampeonatoClassificacaoDao test4 = factoryDao.CreateCampeonatoClassificacaoDao();
            //test4.LoadRodada("teste", DateTime.Now, 1, new Entities.Campeonatos.Campeonato("Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"));

            //test4.Organize("teste", DateTime.Now, 1, new Entities.Campeonatos.Campeonato("Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoFase("Classificatória", "Copa do Mundo 2014"),
            //    new Entities.Campeonatos.CampeonatoGrupo("A", "Copa do Mundo 2014"));

            //Dao.Campeonatos.IJogoDao test5 = factoryDao.CreateJogoDao();
            //test5.InsertResult("teste", DateTime.Now, new Entities.Campeonatos.Jogo("Copa do Mundo 2014", 1), 
            //   1, 0, 2, 0, true, new Entities.Users.User("thoris"));


            ////BO
            //BolaoNet.Business.Interfaces.IFactoryBO factoryBo = new BolaoNet.Business.FactoryBO("usuario", factoryDao);

            //BolaoNet.Business.Facade.InitializationFacadeBO initializationFacadeBO = new Business.Facade.InitializationFacadeBO(factoryBo);
            //initializationFacadeBO.InitAll();
            
            //TestsVS.Business.Facade.BolaoCopaMundo2014UserFacadeBO bo = new TestsVS.Business.Facade.BolaoCopaMundo2014UserFacadeBO(factoryBo);
            //bo.CreateAllData();


            //Integration.FactoryIntegration factoryIntegration = new Integration.FactoryIntegration("thoris", "http://localhost:43817/");
            //Reports.Base.FactoryReport factoryReport = new Reports.Base.FactoryReport(
            //    "thoris", Reports.Base.ReportType.Pdf, ".\\", ".\\", "jpg", "file.pdf");

            //Reports.DataReports.CopaMundoApostasUserReport report = 
            //    new Reports.DataReports.CopaMundoApostasUserReport(factoryIntegration, factoryReport);


            ////report.GenerateApostasUser(new Entities.Boloes.Bolao("Copa do Mundo 2014"), new Entities.Users.User("thoris"));


            //report.GenerateApostasUsers(new Entities.Boloes.Bolao("Copa do Mundo 2014"));

            

        }
    }
}
