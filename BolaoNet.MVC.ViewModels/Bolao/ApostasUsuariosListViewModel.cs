using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class ApostasUsuariosListViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public FilterJogosViewModel Filtros { get; set; }
        public IList<ApostaJogoUsuarioEntryViewModel> Apostas { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostasUsuariosListViewModel()
        {
            this.Filtros = new FilterJogosViewModel();
            this.Apostas = new List<ApostaJogoUsuarioEntryViewModel>();
        }

        #endregion
    }
}
