using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Campeonatos
{
    public class CampeonatoClassificacaoEntryViewModel : Domain.Entities.Campeonatos.CampeonatoClassificacao
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public string ImageTime
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime);
            }
        }

        public System.Drawing.Color? BackColor { get; set; }
        public System.Drawing.Color? ForeColor { get; set; }

        #endregion
    }
}
