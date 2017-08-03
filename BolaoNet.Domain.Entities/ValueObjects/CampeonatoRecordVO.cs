using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class CampeonatoRecordVO
    {
        #region Properties

        public int Posicao { get; set; }
        public string NomeTime { get; set; }
        public int Vitoria { get; set; }
        public int Empate { get; set; }
        public int Derrota { get; set; }

        #endregion
    }
}
