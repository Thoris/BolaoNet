using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoPremiacaoViewModel
    {
        #region Properties

        public string NomeBolao { get; set; }
          
        public int Posicao { get; set; }

        public double Percentual { get; set; }

        public double Valor { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoPremiacaoViewModel()
        {

        }

        #endregion
    }
}
