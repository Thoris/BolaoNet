using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalGrupoComparacaoModelView
    {
        #region Properties

        public int PosicaoComparacao { get; set; }
        public int GeralGeral { get; set; }
        public string Membro { get; set; }
        public int TotalPontos { get; set; }

        #endregion
    }
}
