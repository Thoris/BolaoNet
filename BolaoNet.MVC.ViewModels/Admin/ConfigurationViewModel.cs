using System.Collections.Generic;
using System.ComponentModel;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class ConfigurationViewModel
    {
        #region Properties

        public IList<string> BoloesExistentes { get; set; }
        public IList<string> BoloesDisponiveis { get; set; } 
        public IList<string> CampeonatosExistentes { get; set; }
        public IList<string> CampeonatosDisponiveis { get; set; } 

        #endregion
    }
}
