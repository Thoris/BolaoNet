using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalBolaoPosicoesViewModel
    {
        #region Properties

        [DisplayName("Bolão")]
        public string NomeBolao { get; set; }

        [DisplayName("Cobertura")]
        public string NomeCampeonato { get; set; }

        [DisplayName("Membros")]
        public int Membros { get; set; }

        [DisplayName("Posição")]
        public int Position { get; set; }

        [DisplayName("Restantes")]
        public int ApostasRestantes { get; set; }

        #endregion
    }
}
