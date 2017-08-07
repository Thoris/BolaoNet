using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Pontuacao
{
    public class BolaoCriterioPontosSimulacaoListViewModel
    {
        #region Properties

        public int GolsTime1 { get; set; }
        public int GolsTime2 { get; set; }
        public IList<BolaoCriterioPontosSimulacaoViewModel> Simulacao { get; set; }

        #endregion
    }
}
