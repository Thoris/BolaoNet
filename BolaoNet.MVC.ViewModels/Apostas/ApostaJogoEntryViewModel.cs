using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Apostas
{
    public class ApostaJogoEntryViewModel : Domain.Entities.ValueObjects.JogoUsuarioVO
    {
        #region Variables

        //public int JogoId { get; set; }
        //public DateTime DataJogo { get; set; }
        //public int Rodada { get; set; }
        //public string Fase { get; set; }
        //public string Grupo { get; set; }
        //public string Estadio { get; set; }

        //public string Time1 { get; set; }
        //public int? GolsTime1 { get; set; }

        //public string Time2 { get; set; }
        //public int? GolsTime2 { get; set; }

        //public int? Ganhador { get; set; }

        //public DateTime? DataAposta { get; set; }
        //public bool? Automatico { get; set; }


        public string ImageTime1 { get; set; }
        public string ImageTime2 { get; set; }
        public bool IsLocked { get; set; }
        public bool IsPending
        {
            get { return base.DataAposta == null; }
        }

        #endregion
    }
}
