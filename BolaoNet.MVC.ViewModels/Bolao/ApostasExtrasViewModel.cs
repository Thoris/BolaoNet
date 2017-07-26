using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class ApostasExtrasViewModel 
    {
        #region Properties
        
        public IList<ApostasExtrasEntryViewModel> ApostasExtras { get; set; }
        public IList<ApostasExtrasUsuarioEntryViewModel> ApostasUsuarios { get; set; }
        public IList<ApostasExtrasEntryViewModel> Simulacao { get; set; }

        #endregion
    }
}
