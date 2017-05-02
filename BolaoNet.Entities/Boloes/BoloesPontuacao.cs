using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BoloesPontuacao : DadosBasicos.HighLightItem
    {
        #region Properties

        public virtual Entities.Boloes.Bolao Bolao {get;set;}

        #endregion
        
        #region Constructors/Destructors

        public BoloesPontuacao()
        {

        }

        #endregion
    }
}
