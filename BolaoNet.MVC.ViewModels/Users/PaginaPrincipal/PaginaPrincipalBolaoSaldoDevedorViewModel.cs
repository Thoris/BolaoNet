using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalBolaoSaldoDevedorViewModel
    {
        #region Properties
        
        [DisplayName("Bolão")]        
        public string NomeBolao { get; set; }

        [DisplayName("Usuário")]        
        public string UserName { get; set; }

        [DisplayName("Início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  
        public DateTime? DataInicio { get; set; }

        [DisplayName("Devedor")]        
        public double Valor { get; set; }

        #endregion
    }
}

