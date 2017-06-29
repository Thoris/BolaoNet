using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class UserCampeonatosViewModel
    {
        #region Properties

        public string PathCampeonatoImages { get; set; }
        public string CampeonatoSelecionado { get; set; }
        public IList<string> CampeonatosList { get; set; }

        #endregion
    }
}
