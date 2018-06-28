using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoPremiacaoViewModelInfo
    {
        #region Properties

        public double ValorTotal {get;set;}
        public IList<BolaoPremiacaoViewModel> Premiacoes {get;set;}


        #endregion

        #region Constructors/Destructors

        public BolaoPremiacaoViewModelInfo()
        {
            this.Premiacoes = new List<BolaoPremiacaoViewModel>();
        }

        #endregion
    }
}
