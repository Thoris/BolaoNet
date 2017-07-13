using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class PaginaPrincipalModelView
    {
        #region Properties

        public decimal SaldoDevedor { get; set; }
        public IList<PaginaPrincipal.PaginaPrincipalBolaoPosicoesViewModel> Posicoes { get; set; }
        public IList<PaginaPrincipal.PaginaPrincipalBolaoSaldoDevedorViewModel> Saldo { get; set; }
        public IList<PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView> ComparacaoMembros { get; set; }
        public IList<PaginaPrincipal.PaginaPrincipalPontosObtidosViewModel> PontosObtidos { get; set; }
        public IList<PaginaPrincipal.PaginaPrincipalProximaApostaViewModel> ProximasApostas { get; set; }
        public IList<PaginaPrincipal.PaginaPrincipalMensagemViewModel> Mensagens { get; set; }

        #endregion
    }
}
