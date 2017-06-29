using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Campeonatos
{
    public class CampeonatoHistoricoViewModel : Domain.Entities.Campeonatos.CampeonatoHistorico
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public string ImageTimeCampeao
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTimeCampeao);
            }
        }
        public string ImageTimeVice
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTimeVice);
            }
        }
        public string ImageTimeTerceiro
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTimeTerceiro);
            }
        }

        #endregion
    }
}
