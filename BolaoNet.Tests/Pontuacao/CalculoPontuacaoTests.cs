using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Pontuacao
{
    [TestClass]
    public class CalculoPontuacaoTests
    {
        #region Variables

        private Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao _dao;
        int pontosEmpate = 0;
        int pontosVitoria = 0;
        int pontosDerrota = 0;
        int pontosGanhador = 0;
        int pontosPerdedor = 0;
        int pontosTime1 = 0;
        int pontosTime2 = 0;
        int pontosVDE = 0;
        int pontosErro = 0;
        int pontosGanhadorFora = 0;
        int pontosGanhadorDentro = 0;
        int pontosPerdedorFora = 0;
        int pontosPerdedorDentro = 0;
        int pontosEmpateGols = 0;
        int pontosGolsTime1 = 0;
        int pontosGolsTime2 = 0;
        int pontosCheio = 0;


        bool isMultiploTime = false;
        int multiploTime = 0;

        int pontosTime1Total;
        int pontosTime2Total;
        int pontosTotal;

        bool countEmpate;
        bool countVitoria;
        bool countDerrota;
        bool countGanhador;
        bool countPerdedor;
        bool countTime1;
        bool countTime2;
        bool countVDE;
        bool countErro;
        bool countGanhadorFora;
        bool countGanhadorDentro;
        bool countPerdedorFora;
        bool countPerdedorDentro;
        bool countEmpateGols;
        bool countGolsTime1;
        bool countGolsTime2;
        bool countCheio;

        int pontosResultados;

        int errorNumber;
        string errorDescription;

        string currentUserName = "";
        DateTime currentDateTime = DateTime.Now;

        #endregion

        #region Constructors/Destructors

        public CalculoPontuacaoTests(Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao dao)
        {
            _dao = dao;
        }
        public CalculoPontuacaoTests()
        {
            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

            _dao = kernel.Get<Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao>();
        }

        #endregion

        #region Methods

        public void TestAll()
        {
            TestPontuacaoJogo0a0Aposta0a0();
            TestPontuacaoJogo0a0Aposta1a0();
            TestPontuacaoJogo0a0Aposta0a1();
            TestPontuacaoJogo0a0Aposta1a1();
            TestPontuacaoJogo0a0Aposta2a0();
            TestPontuacaoJogo0a0Aposta2a1();
            TestPontuacaoJogo0a0Aposta0a2();
            TestPontuacaoJogo0a0Aposta1a2();
            TestPontuacaoJogo0a0Aposta2a2();


            TestPontuacaoJogo1a0Aposta0a0();
            TestPontuacaoJogo1a0Aposta1a0();
            TestPontuacaoJogo1a0Aposta0a1();
            TestPontuacaoJogo1a0Aposta1a1();
            TestPontuacaoJogo1a0Aposta2a0();
            TestPontuacaoJogo1a0Aposta2a1();
            TestPontuacaoJogo1a0Aposta0a2();
            TestPontuacaoJogo1a0Aposta1a2();
            TestPontuacaoJogo1a0Aposta2a2();


            TestPontuacaoJogo0a1Aposta0a0();
            TestPontuacaoJogo0a1Aposta1a0();
            TestPontuacaoJogo0a1Aposta0a1();
            TestPontuacaoJogo0a1Aposta1a1();
            TestPontuacaoJogo0a1Aposta2a0();
            TestPontuacaoJogo0a1Aposta2a1();
            TestPontuacaoJogo0a1Aposta0a2();
            TestPontuacaoJogo0a1Aposta1a2();
            TestPontuacaoJogo0a1Aposta2a2();


            TestCampeonatoPontosJogo0a0Aposta0a0();
            TestCampeonatoPontosJogo0a0Aposta1a0();
            TestCampeonatoPontosJogo0a0Aposta0a1();
            TestCampeonatoPontosJogo0a0Aposta1a1();
            TestCampeonatoPontosJogo0a0Aposta2a0();
            TestCampeonatoPontosJogo0a0Aposta2a1();
            TestCampeonatoPontosJogo0a0Aposta0a2();
            TestCampeonatoPontosJogo0a0Aposta1a2();
            TestCampeonatoPontosJogo0a0Aposta2a2();


            TestCampeonatoPontosJogo1a0Aposta0a0();
            TestCampeonatoPontosJogo1a0Aposta1a0();
            TestCampeonatoPontosJogo1a0Aposta0a1();
            TestCampeonatoPontosJogo1a0Aposta1a1();
            TestCampeonatoPontosJogo1a0Aposta2a0();
            TestCampeonatoPontosJogo1a0Aposta2a1();
            TestCampeonatoPontosJogo1a0Aposta0a2();
            TestCampeonatoPontosJogo1a0Aposta1a2();
            TestCampeonatoPontosJogo1a0Aposta2a2();


            TestCampeonatoPontosJogo0a1Aposta0a0();
            TestCampeonatoPontosJogo0a1Aposta1a0();
            TestCampeonatoPontosJogo0a1Aposta0a1();
            TestCampeonatoPontosJogo0a1Aposta1a1();
            TestCampeonatoPontosJogo0a1Aposta2a0();
            TestCampeonatoPontosJogo0a1Aposta2a1();
            TestCampeonatoPontosJogo0a1Aposta0a2();
            TestCampeonatoPontosJogo0a1Aposta1a2();
            TestCampeonatoPontosJogo0a1Aposta2a2();




            TestCampeonatoPontosJogo0a0Aposta0a0Brasil();
            TestCampeonatoPontosJogo0a0Aposta1a0Brasil();
            TestCampeonatoPontosJogo0a0Aposta0a1Brasil();
            TestCampeonatoPontosJogo0a0Aposta1a1Brasil();
            TestCampeonatoPontosJogo0a0Aposta2a0Brasil();
            TestCampeonatoPontosJogo0a0Aposta2a1Brasil();
            TestCampeonatoPontosJogo0a0Aposta0a2Brasil();
            TestCampeonatoPontosJogo0a0Aposta1a2Brasil();
            TestCampeonatoPontosJogo0a0Aposta2a2Brasil();


            TestCampeonatoPontosJogo1a0Aposta0a0Brasil();
            TestCampeonatoPontosJogo1a0Aposta1a0Brasil();
            TestCampeonatoPontosJogo1a0Aposta0a1Brasil();
            TestCampeonatoPontosJogo1a0Aposta1a1Brasil();
            TestCampeonatoPontosJogo1a0Aposta2a0Brasil();
            TestCampeonatoPontosJogo1a0Aposta2a1Brasil();
            TestCampeonatoPontosJogo1a0Aposta0a2Brasil();
            TestCampeonatoPontosJogo1a0Aposta1a2Brasil();
            TestCampeonatoPontosJogo1a0Aposta2a2Brasil();


            TestCampeonatoPontosJogo0a1Aposta0a0Brasil();
            TestCampeonatoPontosJogo0a1Aposta1a0Brasil();
            TestCampeonatoPontosJogo0a1Aposta0a1Brasil();
            TestCampeonatoPontosJogo0a1Aposta1a1Brasil();
            TestCampeonatoPontosJogo0a1Aposta2a0Brasil();
            TestCampeonatoPontosJogo0a1Aposta2a1Brasil();
            TestCampeonatoPontosJogo0a1Aposta0a2Brasil();
            TestCampeonatoPontosJogo0a1Aposta1a2Brasil();
            TestCampeonatoPontosJogo0a1Aposta2a2Brasil();
        }

        private void ClearInput()
        {
            pontosEmpate = 0;
            pontosVitoria = 0;
            pontosDerrota = 0;
            pontosGanhador = 0;
            pontosPerdedor = 0;
            pontosTime1 = 0;
            pontosTime2 = 0;
            pontosVDE = 0;
            pontosErro = 0;
            pontosGanhadorFora = 0;
            pontosGanhadorDentro = 0;
            pontosPerdedorFora = 0;
            pontosPerdedorDentro = 0;
            pontosEmpateGols = 0;
            pontosGolsTime1 = 0;
            pontosGolsTime2 = 0;
            pontosCheio = 0;


            isMultiploTime = false;
            multiploTime = 0;

            pontosTime1Total = 0;
            pontosTime2Total = 0;
            pontosTotal =0 ;

            countEmpate = false;
            countVitoria = false;
            countDerrota = false;
            countGanhador = false;
            countPerdedor = false;
            countTime1 = false;
            countTime2 = false;
            countVDE = false;
            countErro = false;
            countGanhadorFora = false;
            countGanhadorDentro = false;
            countPerdedorFora = false;
            countPerdedorDentro = false;
            countEmpateGols = false;
            countGolsTime1 = false;
            countGolsTime2 = false;
            countCheio = false;


            errorNumber = 0;
            errorDescription = null;

            pontosResultados = 0;

            currentUserName = "";
            currentDateTime = DateTime.Now;
        }

        private void TestCalcularPontos(int gols1, int gols2, int aposta1, int aposta2)
        {
            pontosResultados = _dao.CalcularPontos(currentUserName, currentDateTime, gols1, gols2, aposta1, aposta2,
                pontosEmpate, pontosVitoria, pontosDerrota, pontosGanhador, pontosPerdedor, pontosTime1,
                pontosTime2, pontosVDE, pontosErro, pontosGanhadorFora, pontosGanhadorDentro,
                pontosPerdedorFora, pontosPerdedorDentro, pontosEmpateGols, pontosGolsTime1, pontosGolsTime2,
                pontosCheio, isMultiploTime, multiploTime, out pontosTime1Total, out pontosTime2Total,
                out pontosTotal, out countEmpate, out countVitoria, out countDerrota, out countGanhador,
                out countPerdedor, out countTime1, out countTime2, out countVDE, out countErro,
                out countGanhadorFora, out countGanhadorDentro, out countPerdedorFora, out countPerdedorDentro,
                out countEmpateGols, out countGolsTime1, out countGolsTime2, out countCheio,
                out errorNumber, out errorDescription);
        }

        private void SetPontosCampeonato(bool isMultiplo)
        {
            pontosEmpate = 2;
            pontosVitoria = 0;
            pontosDerrota = 0;
            pontosGanhador = 0;
            pontosPerdedor = 0;
            pontosTime1 = 0;
            pontosTime2 = 0;
            pontosVDE = 3;
            pontosErro = 0;
            pontosGanhadorFora = 0;
            pontosGanhadorDentro = 0;
            pontosPerdedorFora = 0;
            pontosPerdedorDentro = 0;
            pontosEmpateGols =  -2;
            pontosGolsTime1 = 1;
            pontosGolsTime2 = 1;
            pontosCheio = 5;


            isMultiploTime = isMultiplo;
            multiploTime = 2;
        }

        #endregion

        #region Tests

        #region Jogo 0 x 0
        
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta0a0()
        {

            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, true);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, true);
            Assert.AreEqual(countPerdedor, true);
            Assert.AreEqual(countTime1, true);
            Assert.AreEqual(countTime2, true);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, true);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, true);

        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta1a0()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta0a1()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta1a1()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, true);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta2a0()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta2a1()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta0a2()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta1a2()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a0Aposta2a2()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, true);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        
        #endregion

        #region Jogo 1 x 0

        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta0a0()
        {

            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, false);

        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta1a0()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, true);
            Assert.AreEqual(countDerrota, true);
            Assert.AreEqual(countGanhador, true);
            Assert.AreEqual(countPerdedor, true);
            Assert.AreEqual(countTime1, true);
            Assert.AreEqual(countTime2, true);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, true);
            Assert.AreEqual(countPerdedorFora, true);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, true);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta0a1()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta1a1()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta2a0()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, true);
            Assert.AreEqual(countDerrota, true);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, true);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, true);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta2a1()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, true);
            Assert.AreEqual(countDerrota, true);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta0a2()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta1a2()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo1a0Aposta2a2()
        {
            ClearInput();

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }

        #endregion

        #region Jogo 0 x 1

        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta0a0()
        {

            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);

        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta1a0()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta0a1()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, true);
            Assert.AreEqual(countDerrota, true);
            Assert.AreEqual(countGanhador, true);
            Assert.AreEqual(countPerdedor, true);
            Assert.AreEqual(countTime1, true);
            Assert.AreEqual(countTime2, true);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, true);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, true);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, true);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta1a1()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta2a0()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta2a1()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, true);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta0a2()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, true);
            Assert.AreEqual(countDerrota, true);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, true);
            Assert.AreEqual(countTime1, true);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, true);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta1a2()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, true);
            Assert.AreEqual(countDerrota, true);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, true);
            Assert.AreEqual(countErro, false);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }
        [TestMethod]
        public void TestPontuacaoJogo0a1Aposta2a2()
        {
            ClearInput();

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);


            Assert.AreEqual(countEmpate, false);
            Assert.AreEqual(countVitoria, false);
            Assert.AreEqual(countDerrota, false);
            Assert.AreEqual(countGanhador, false);
            Assert.AreEqual(countPerdedor, false);
            Assert.AreEqual(countTime1, false);
            Assert.AreEqual(countTime2, false);
            Assert.AreEqual(countVDE, false);
            Assert.AreEqual(countErro, true);
            Assert.AreEqual(countGanhadorFora, false);
            Assert.AreEqual(countGanhadorDentro, false);
            Assert.AreEqual(countPerdedorFora, false);
            Assert.AreEqual(countPerdedorDentro, false);
            Assert.AreEqual(countEmpateGols, false);
            Assert.AreEqual(countGolsTime1, false);
            Assert.AreEqual(countGolsTime2, false);
            Assert.AreEqual(countCheio, false);
        }

        #endregion

        #region Copa 0 x 0

        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta0a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(10, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta1a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta0a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta1a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(5, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta2a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta2a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta0a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta1a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta2a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(5, pontosResultados);
        }
        
        #endregion

        #region Copa 1 x 0

        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta0a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta1a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(10, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta0a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta1a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta2a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(4, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta2a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(3, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta0a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta1a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta2a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }

        #endregion

        #region Copa 0 x 1

        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta0a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta1a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta0a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(10, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta1a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta2a0()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta2a1()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(1, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta0a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(4, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta1a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(3, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta2a2()
        {
            ClearInput();
            SetPontosCampeonato(false);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }

        #endregion


        #region Copa 0 x 0 - Brasil

        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta0a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(20, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta1a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta0a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta1a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(10, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta2a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta2a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta0a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta1a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a0Aposta2a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(10, pontosResultados);
        }

        #endregion

        #region Copa 1 x 0 - Brasil

        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta0a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta1a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(20, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta0a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta1a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta2a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(8, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta2a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(6, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta0a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta1a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo1a0Aposta2a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 1;
            int gols2 = 0;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }

        #endregion

        #region Copa 0 x 1 - Brasil

        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta0a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta1a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta0a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(20, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta1a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta2a0Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 0;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta2a1Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 1;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(2, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta0a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 0;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(8, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta1a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 1;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(6, pontosResultados);
        }
        [TestMethod]
        public void TestCampeonatoPontosJogo0a1Aposta2a2Brasil()
        {
            ClearInput();
            SetPontosCampeonato(true);

            int gols1 = 0;
            int gols2 = 1;

            int aposta1 = 2;
            int aposta2 = 2;

            TestCalcularPontos(gols1, gols2, aposta1, aposta2);

            Assert.AreEqual(0, pontosResultados);
        }

        #endregion

        #endregion
    }
}
