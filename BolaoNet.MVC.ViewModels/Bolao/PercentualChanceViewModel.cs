using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class PercentualChanceViewModel
    {
        #region Properties

        public int Posicao { get; set; }
        public int Pontos { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<double> Percentual { get; set; }

        public bool IsChance
        {
            get
            {
                for (int c=0; c < this.Percentual.Count; c++)
                {
                    if (this.Percentual[c] > 0)
                        return true;
                }
                return false;
            }
        }

        #endregion
    }
}
