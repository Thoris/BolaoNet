using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users.PaginaPrincipal
{
    public class PaginaPrincipalPontosObtidosViewModel
    {
        #region Properties

        public string NomeCampeonato { get; set; }
        public int JogoId { get; set; }

        public string NomeTime1 { get; set; }
        public int GolsTime1 { get; set; }
        public int? PenaltisTime1 { get; set; }

        public string NomeTime2 { get; set; }
        public int GolsTime2 { get; set; }
        public int? PenaltisTime2 { get; set; }

        public string NomeEstadio { get; set; }
        public DateTime DataJogo { get; set; }
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

        public int? ApostaTime1 { get; set; }
        public int? ApostaTime2 { get; set; }
        public int? ApostaPenaltis1 { get; set; }
        public int? ApostaPenaltis2 { get; set; }

        public bool? Valido { get; set; }

        public string NomeTimeResult1 { get; set; }
        public string NomeTimeResult2 { get; set; }

        public int? Pontos { get; set; }

        #endregion
    }
}
