using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class BolaoGrupoComparacaoClassificacaoVO
    {
        #region Properties

        public string NomeBolao { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }

        public int? Posicao { get; set; }
        public int? LastPosicao { get; set; }

        public int? TotalPontos { get; set; }
        public int? PosicaoGeral { get; set; }

        #endregion
    }
}
