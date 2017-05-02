using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class ApostaExtraUsuario : ApostaExtra
    {
        #region Properties
        
        public string UserName { get; set; }
        public DateTime DataAposta { get; set; }
        public int Pontos { get; set; }
        public string NomeTime { get; set; }
        public bool IsApostaValida { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraUsuario()
        {

        }

        #endregion
    }
}
