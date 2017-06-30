using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class ApostaJogoUsuarioPontosViewModel : Domain.Entities.Boloes.JogoUsuario
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public int Posicao { get; set; }
        public int AlteracaoPosicao { get; set; }
        public int TotalPontosClassificacao { get; set; }
        public int TotalApostasResultado { get; set; }
        public double PercentualResultado { get; set; }
        public string Nome { get; set; }

        #endregion
    }
}
