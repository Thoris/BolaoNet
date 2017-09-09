using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoHistoricoListViewModel
    {
        public int SelectedYear { get; set; }
        public IList<int> ListYears { get; set; }

        public IList<BolaoHistoricoViewModel> Classificacao { get; set; }
    }
}
