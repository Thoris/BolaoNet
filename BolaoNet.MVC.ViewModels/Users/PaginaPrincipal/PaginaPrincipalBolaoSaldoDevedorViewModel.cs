using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalBolaoSaldoDevedorViewModel
    {
        #region Properties

        public string NomeBolao { get; set; }
        public double ValorBolao { get; set; }
        public double SaldoDevedor { get; set; }

        #endregion
    }
}
