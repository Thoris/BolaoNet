using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public abstract class Pontuacao : Base.AuditModel
    {
        #region Properties

        public int ? TotalApostaExtra { get; set; }
        public int ? TotalPontos { get; set; }
        public int ? TotalEmpate { get; set; }
        public int ? TotalVitoria { get; set; }
        public int ? TotalDerrota { get; set; }
        public int ? TotalGolsGanhador { get; set; }
        public int ? TotalGolsPerdedor { get; set; }
        public int ? TotalResultTime1 { get; set; }
        public int ? TotalResultTime2 { get; set; }
        public int ? TotalVDE { get; set; }
        public int ? TotalErro { get; set; }
        public int ? TotalGolsGanhadorFora { get; set; }
        public int ? TotalGolsGanhadorDentro { get; set; }
        public int ? TotalPerdedorFora { get; set; }
        public int ? TotalPerdedorDentro { get; set; }
        public int ? TotalGolsEmpate { get; set; }
        public int ? TotalGolsTime1 { get; set; }
        public int ? TotalGolsTime2 { get; set; }
        public int ? TotalPlacarCheio { get; set; }

        #endregion

        #region Constructors/Destructors

        public Pontuacao()
        {

        }

        #endregion
    }
}
