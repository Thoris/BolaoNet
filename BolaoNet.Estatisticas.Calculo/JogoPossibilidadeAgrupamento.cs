using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class JogoPossibilidadeAgrupamento : JogoPossibilidade
    {
        #region Properties

        public int JogoId { get; set; }
        public IList<JogoIdAgrupamento> Jogos { get; set; }

        #endregion

        #region Constructors/Destructors

        public JogoPossibilidadeAgrupamento()
        {
            this.Jogos = new List<JogoIdAgrupamento>();
            this.Pontuacao = new List<ApostaPontos>();
        }
        public JogoPossibilidadeAgrupamento(JogoPossibilidade entry)
            : this()
        {
            this.GolsTime1 = entry.GolsTime1;
            this.GolsTime2 = entry.GolsTime2;
            this.TotalApostas = entry.TotalApostas;
            this.Pontuacao = entry.Pontuacao.ToList();
        }

        #endregion
    }
}
