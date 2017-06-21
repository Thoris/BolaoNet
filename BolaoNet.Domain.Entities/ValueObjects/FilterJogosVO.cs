using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class FilterJogosVO
    {
        #region Properties

        public string NomeGrupo { get; set; }
        public string NomeFase { get; set; }
        public string NomeTime { get; set; }
        public int? Rodada { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        #endregion
    }
}
