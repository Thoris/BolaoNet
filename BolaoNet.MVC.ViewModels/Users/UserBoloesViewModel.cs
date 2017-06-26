using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class UserBoloesViewModel
    {
        #region Properties

        public string PathBolaoImages { get; set; }
        public string BolaoSelecionado { get; set; }
        public IList<string> BoloesList { get; set; }

        #endregion
    }
}
