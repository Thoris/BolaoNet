using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class ApostaPontos : Base.AuditModel
    {
        #region Properties

        public int Pontos { get; set; }
        public bool IsEmpate { get; set; }
        public bool IsVitoria { get; set; }
        public bool IsDerrota { get; set; }
        public bool IsGolsGanhador { get; set; }
        public bool IsGolsPerdedor { get; set; }
        public bool IsResultTime1 { get; set; }
        public bool IsResultTime2 { get; set; }
        public bool IsVDE { get; set; }
        public bool IsErro { get; set; }
        public bool IsGolsGanhadorFora { get; set; }
        public bool IsGolsGanhadorDentro { get; set; }
        public bool IsGolsPerdedorFora { get; set; }
        public bool IsGolsPerdedorDentro { get; set; }
        public bool IsGolsEmpate { get; set; }
        public bool IsGolsTime1 { get; set; }
        public bool IsGolsTime2 { get; set; }
        public bool IsPlacarCheio { get; set; }
        public bool IsMultiploTime { get; set; }
        public int MultiploTime { get; set; }

        #endregion
    }
}
