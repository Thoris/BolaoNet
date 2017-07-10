using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class JogoUsuarioVO
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

        public bool? IsEmpate { get; set; }
        public bool? IsDerrota { get; set; }
        public bool? IsVitoria { get; set; }
        public bool? IsGolsGanhador { get; set; }
        public bool? IsGolsPerdedor { get; set; }
        public bool? IsResultTime1 { get; set; }
        public bool? IsResultTime2 { get; set; }
        public bool? IsVDE { get; set; }
        public bool? IsErro { get; set; }
        public bool? IsGolsGanhadorFora { get; set; }
        public bool? IsGolsGanhadorDentro { get; set; }
        public bool? IsGolsPerdedorFora { get; set; }
        public bool? IsGolsPerdedorDentro { get; set; }
        public bool? IsGolsEmpate { get; set; }
        public bool? IsGolsTime1 { get; set; }
        public bool? IsGolsTime2 { get; set; }
        public bool? IsPlacarCheio { get; set; }
        public bool? IsMultiploTime { get; set; }
        public int? MultiploTime { get; set; }

        public int? Ganhador { get; set; }

        //
        public string DescricaoTime1 { get; set; }
        public string DescricaoTime2 { get; set; }

        #endregion
    }
}
