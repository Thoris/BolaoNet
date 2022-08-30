using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects.Notification
{
    public class JogoObject
    {
        #region Properties
        public Image ImageEmbeededTime1 { get; set; }
        public Image ImageEmbeededTime2 { get; set; }         
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
