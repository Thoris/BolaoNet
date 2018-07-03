using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class StatClassificacaoVO
    {
        #region Properties

        public int JogoId { get; set; }
        public string UserName { get; set; }
        public int Pontos { get; set; }
        public int Posicao { get; set; }

        #endregion
    }
}
