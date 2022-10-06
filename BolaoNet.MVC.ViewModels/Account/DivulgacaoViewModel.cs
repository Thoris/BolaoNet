using BolaoNet.MVC.ViewModels.Bolao;
using BolaoNet.MVC.ViewModels.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Account
{
    public class DivulgacaoViewModel
    {
        #region Properties

        public IList<BolaoRegrasViewModel> Regras { get; set; }
        public IList<BolaoHistoricoViewModel> Classificacao { get; set; }

        #endregion

        #region Constructors/Destructors

        public DivulgacaoViewModel()
        {

        }

        #endregion
    }
}
