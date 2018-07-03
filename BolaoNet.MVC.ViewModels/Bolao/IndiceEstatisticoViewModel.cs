using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class IndiceEstatisticoViewModel
    {
        public IList<IndiceEstatisticoSelecionadoViewModel> Selecionado { get; set; }
        public IList<ClassificacaoViewModel> Classificacao { get; set; }

        public Chart.SerieValueModelView[] Series { get; set; }
    }
}
