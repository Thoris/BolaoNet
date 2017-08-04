using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Campeonatos
{
    public class CampeonatoRecordsListViewModel
    {
        #region Properties

        public string Title { get; set; }
        public IList<IList<CampeonatoRecordsViewModel>> List { get; set; } 

        #endregion
    }
}
