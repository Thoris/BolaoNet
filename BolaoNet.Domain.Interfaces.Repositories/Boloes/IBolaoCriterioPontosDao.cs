using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoCriterioPontosDao
    {
        bool BuscaPontos(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao,
            out int pontosEmpate, out int pontosVitoria, out int pontosDerrota, out int pontosGanhador,
            out int pontosPerdedor, out int pontosTime1, out int pontosTime2, out int pontosVDE,
            out int pontosErro, out int pontosGanhadorFora, out int pontosGanhadorDentro, out int pontosPerdedorFora,
            out int pontosPerdedorDentro, out int pontosEmpateGols, out int pontosGolsTime1, out int pontosGolsTime2,
            out int pontosCheio);


        IList<Entities.Boloes.BolaoCriterioPontos> LoadCriteriosPontos(string currentUserName, DateTime currentDateTime,
            Entities.Boloes.Bolao bolao);
    }
}
