using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoComparacaoApostasViewModel
    {
        #region Properties

        public string UserNameBase { get; set; }
        public string UserNameComparacao { get; set; }
        public FilterJogosViewModel Filtros { get; set; }
        public IList<BolaoComparacaoApostaJogoViewModel> Apostas;

        #endregion

        #region Constructors/Destructors

        public BolaoComparacaoApostasViewModel()
        {

            this.Filtros = new FilterJogosViewModel();
            this.Apostas = new List<BolaoComparacaoApostaJogoViewModel>();
        }

        #endregion
    }
}
