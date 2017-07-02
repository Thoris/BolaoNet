using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class BolaoIniciarStatusMembroViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public string FullName { get; set; }
        public int TotalApostasRestantes { get; set; }
        public string Email { get; set; }
        public bool BolaoPago { get; set; }

        #endregion
    }
}
