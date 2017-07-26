using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoClassificacaoViewModel
    {
        #region Properties

        public IList<ClassificacaoViewModel> Classificacao { get; set; }
        public IList<PremioViewModel> Premios { get; set; }

        #endregion
    }
}
