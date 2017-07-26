using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class ApostasExtrasUsuarioEntryViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public string FullName { get; set; }
        public int Posicao { get; set; }
        public int LastPosicao { get; set; }
        public int TotalPontosClassificacao { get; set; }
        public int Pontos { get; set; }
        public IList<ApostasExtrasUsuariosPontosViewModel> Apostas { get; set; }

        #endregion
    }
}
