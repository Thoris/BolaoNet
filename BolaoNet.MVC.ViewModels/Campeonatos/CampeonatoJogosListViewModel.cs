using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Campeonatos
{
    public class CampeonatoJogosListViewModel
    {
        
        #region Properties

        public FilterJogosViewModel Filtros { get; set; }
        public IList<CampeonatoJogoEntryViewModel> Jogos { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoJogosListViewModel()
        {
            this.Filtros = new FilterJogosViewModel();
            this.Jogos = new List<CampeonatoJogoEntryViewModel>();
        }

        #endregion
    }
}
