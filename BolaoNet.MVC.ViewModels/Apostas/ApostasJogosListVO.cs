using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Apostas
{
    public class ApostasJogosListVO
    {
        #region Properties

        public IList<ApostaJogoEntryVO> Apostas { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostasJogosListVO()
        {
            this.Apostas = new List<ApostaJogoEntryVO>();
        }

        #endregion
    }
}
