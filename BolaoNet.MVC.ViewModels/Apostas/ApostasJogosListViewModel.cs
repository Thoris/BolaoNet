using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Apostas
{
    public class ApostasJogosListViewModel
    {
        #region Properties

        public FilterJogosViewModel Filtros { get; set; }
        public IList<ApostaJogoEntryViewModel> Apostas { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostasJogosListViewModel()
        {
            this.Filtros = new FilterJogosViewModel();
            this.Apostas = new List<ApostaJogoEntryViewModel>();
        }

        #endregion
    }
}
