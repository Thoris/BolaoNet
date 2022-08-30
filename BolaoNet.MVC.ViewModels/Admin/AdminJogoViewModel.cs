using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class AdminJogoViewModel
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public string ImageTime1
        {
            get
            {
                if (string.IsNullOrEmpty(this.NomeTime1))
                    return "";

                return string.Format(FormatIcon, this.NomeTime1);
            }
        }
        public string ImageTime2
        {
            get
            {
                if (string.IsNullOrEmpty(this.NomeTime2))
                    return "";

                return string.Format(FormatIcon, this.NomeTime2);
            }
        }
        public int JogoId { get; set; }
        public string NomeTime1 { get; set; }
        public string NomeTime2 { get; set; }
        public int ? GolsTime1 { get; set; }
        public int ? GolsTime2 { get; set; }
        public string NomeEstadio { get; set; }
        public DateTime DataJogo { get; set; } 
        public DateTime OnlyDataJogo
        {
            get { return new DateTime(DataJogo.Year, DataJogo.Month, DataJogo.Day); }
        } 
        public TimeSpan HoraJogo
        {
            get { return new TimeSpan(DataJogo.Hour, DataJogo.Minute, DataJogo.Second); }
        }
        public int ? Rodada { get; set; }
        public string NomeFase { get; set; }
        public bool IsValido { get; set; }

        #endregion
    }
}
