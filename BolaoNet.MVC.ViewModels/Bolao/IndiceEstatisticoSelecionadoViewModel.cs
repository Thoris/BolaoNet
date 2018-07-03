using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class IndiceEstatisticoSelecionadoViewModel
    {
        #region Properties
         
        [DisplayName("Bolão")]
        public string NomeBolao { get; set; }

        [DisplayName("Usuário")]
        public string UserName { get; set; }

        [DisplayName("Nome")]
        public string FullName { get; set; }

        [DisplayName("Geral")]
        public int? Posicao { get; set; }

        [DisplayName("Pos.")]
        public int? PosicaoIndividual { get; set; }

        [DisplayName("Últ.Pos.")]
        public int? LastPosicao { get; set; }

        [DisplayName("PT")]
        public int? TotalPontos { get; set; }

        public int[] Posicoes { get; set; }

        #endregion
    }
}
