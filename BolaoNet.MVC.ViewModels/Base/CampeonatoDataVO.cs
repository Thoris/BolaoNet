using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Base
{
    public class CampeonatoDataVO
    {
        #region Properties

        public string NomeCampeonato { get; set; }
        public IList<int> Rodadas { get; set; }
        public IList<string> NomeTimes { get; set; }
        public IList<string> NomeFases { get; set; }
        public IList<string> NomeGrupos { get; set; }
        public Nullable<int> TipoCampeonato { get; set; }

        #endregion
        
    }
}
