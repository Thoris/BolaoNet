using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalPontosObtidosViewModel
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
                    return string.Format(FormatIcon, this.NomeTimeResult1);
                else
                    return string.Format(FormatIcon, this.NomeTime1);
            }
        }
        public string ImageTime2
        {
            get
            {
                if (string.IsNullOrEmpty(this.NomeTime2))
                    return string.Format(FormatIcon, this.NomeTimeResult2);
                else
                    return string.Format(FormatIcon, this.NomeTime2);
            }
        }

        [DisplayName("Campeonato")]
        public string NomeCampeonato { get; set; }

        [DisplayName("ID")]
        public int JogoId { get; set; }

        [DisplayName("Time")]
        public string NomeTime1 { get; set; }

        [DisplayName("G.")]
        public int GolsTime1 { get; set; }
        
        public int? PenaltisTime1 { get; set; }

        [DisplayName("Time")]
        public string NomeTime2 { get; set; }
        
        [DisplayName("G.")]
        public int GolsTime2 { get; set; }
        
        public int? PenaltisTime2 { get; set; }

        [DisplayName("Estádio")]
        public string NomeEstadio { get; set; }

        [DisplayName("Data")]
        public DateTime DataJogo { get; set; }
        
        [DisplayName("Rodada")]
        public int Rodada { get; set; }
        public bool PartidaValida { get; set; }
        public DateTime? DataValidacao { get; set; }
        public string NomeFase { get; set; }
        public string NomeGrupo { get; set; }
        public bool IsValido { get; set; }
        public string ValidadoBy { get; set; }

        public string UserName { get; set; }

        public DateTime? DataAposta { get; set; }

        public int? Automatico { get; set; }

        [DisplayName("Ap.")]
        public int? ApostaTime1 { get; set; }

        [DisplayName("Ap.")]        
        public int? ApostaTime2 { get; set; }
        
        public int? ApostaPenaltis1 { get; set; }
        public int? ApostaPenaltis2 { get; set; }

        public bool? Valido { get; set; }

        public string NomeTimeResult1 { get; set; }
        public string NomeTimeResult2 { get; set; }
        
        [DisplayName("PT")]        
        public int? Pontos { get; set; }

        #endregion
    }
}
