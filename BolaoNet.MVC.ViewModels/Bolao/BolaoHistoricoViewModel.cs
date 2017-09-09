using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoHistoricoViewModel
    {
        #region Properties

        public string NomeBolao { get; set; } 
        public int Ano { get; set; } 
        public int Posicao { get; set; }
        public string UserName { get; set; }
        public int Pontos { get; set; }
        public int TotalEmpates { get; set; }
        public int TotalVDE { get; set; }
        public int TotalGolsTime1 { get; set; }
        public int TotalGolsTime2 { get; set; }
        public int TotalCheio { get; set; }
        public int TotalExtras { get; set; }


        #endregion
    }
}
