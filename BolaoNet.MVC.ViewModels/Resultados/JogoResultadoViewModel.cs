using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Resultados
{
    public class JogoResultadoViewModel : Domain.Entities.Campeonatos.Jogo
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public string ImageTime1
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime1);
            }
        }
        public string ImageTime2
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime2);

            }
        }
        public string Mensagem { get; set; }
        public bool ConfigurarJogoCorrente { get; set; }

        #endregion
    }
}
