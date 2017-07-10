using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class BolaoIniciarStatusMembroViewModel
    {
        #region Properties

        
        public string NomeBolao { get; set; }
        
        [DisplayName("Membro")]
        public string UserName { get; set; }

        [DisplayName("Nome")]
        public string FullName { get; set; }

        [DisplayName("Email")]        
        public string Email { get; set; }

        [DisplayName("Apostas Restantes")]     
        public int Restantes { get; set; }

        [DisplayName("Saldo Devedor")]    
        public decimal Pago { get; set; }

        public bool FaltaPagamento { get; set; }
        public bool ApostasRestantes { get; set; }

        #endregion
    }
}
