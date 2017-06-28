using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Campeonatos
{
    public class CampeonatoJogoEntryViewModel : Domain.Entities.Campeonatos.Jogo
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
                //if (!string.IsNullOrEmpty (this.NomeTimeResult1))
                //    return string.Format (FormatIcon, this.NomeTimeResult1);
                //else if (!string.IsNullOrEmpty(base.NomeTime1))
                //    return string.Format (FormatIcon, base.NomeTime1);
                //else
                //    return null;
            }
        }
        public string ImageTime2
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime2);
                //if (!string.IsNullOrEmpty (this.NomeTimeResult2))
                //    return string.Format (FormatIcon, this.NomeTimeResult2);
                //else if (!string.IsNullOrEmpty(this.NomeTime2))
                //    return string.Format (FormatIcon, this.NomeTime2);
                //else
                //    return null;
            }
        }

        public bool IsLocked { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoJogoEntryViewModel()
        {

        }

        #endregion
    }
}
