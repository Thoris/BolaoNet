using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Pontuacao
{
    public class BolaoCriterioViewModel
    {
        #region Properties

        public string Mensagem { get; set; }
        public IList<BolaoCriterioPontosViewModel> CriterioPontos { get; set; }
        public IList<BolaoCriterioTimeViewModel> CriterioTimes { get; set; }

        #endregion
    }
}
