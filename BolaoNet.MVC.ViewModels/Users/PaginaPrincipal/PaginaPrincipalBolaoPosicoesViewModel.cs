using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalBolaoPosicoesViewModel
    {
        #region Properties

        public string NomeBolao { get; set; }
        public string Cobertura { get; set; }
        public int Posicao { get; set; }
        public int TotalApostasRestantes { get; set; }
        public int TotalMembros { get; set; }

        #endregion
    }
}
