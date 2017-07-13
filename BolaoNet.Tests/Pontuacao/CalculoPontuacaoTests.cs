using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Pontuacao
{
    public class CalculoPontuacaoTests
    {
        #region Methods

        public void TestPontuacaoJogo()
        {
            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();


            Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao dao =
                kernel.Get<Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao>();



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
	
	
            int errorNumber;
            string errorDescription;

            string currentUserName = "";
            DateTime currentDateTime = DateTime.Now;

            int gols1 = 0;
            int gols2 = 0;
            int aposta1 = 0;
            int aposta2 = 0;

            dao.CalcularPontos(currentUserName, currentDateTime, gols1, gols2, aposta1, aposta2,
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

        #endregion
    }
}
