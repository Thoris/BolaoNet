using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos
{
    public class Jogo : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }


        [Key, Column(Order = 2)]
        public int JogoId { get; set; }
        


        public string NomeTime1 { get; set; }
        [ForeignKey("NomeTime1")]
        public virtual DadosBasicos.Time Time1 { get; set; }

        public string DescricaoTime1 { get; set; }
        public int GolsTime1 { get; set; }
        public int ? PenaltisTime1 { get; set; }

        public string NomeTime2 { get; set; }
        [ForeignKey("NomeTime2")]
        public virtual DadosBasicos.Time Time2 { get; set; }

        public string DescricaoTime2 { get; set; }
        public int GolsTime2 { get; set; }
        public int ? PenaltisTime2 { get; set; }

        public string NomeEstadio { get; set; }
        [ForeignKey("NomeEstadio")]
        public virtual DadosBasicos.Estadio Estadio { get; set; }

        public DateTime DataJogo { get; set; }
        [NotMapped]
        public DateTime OnlyDataJogo
        {
            get { return new DateTime(DataJogo.Year, DataJogo.Month, DataJogo.Day); }
        }
        [NotMapped]
        public TimeSpan HoraJogo
        {
            get { return new TimeSpan(DataJogo.Hour, DataJogo.Minute, DataJogo.Second); }
        }
        public int Rodada { get; set; }
        public bool PartidaValida { get; set; }
        public DateTime ? DataValidacao { get; set; }


        public string NomeFase { get; set; }
        [ForeignKey("NomeCampeonato, NomeFase")]
        public virtual Campeonatos.CampeonatoFase Fase { get; set; }

        public string NomeGrupo { get; set; }
        [ForeignKey("NomeCampeonato, NomeGrupo")]
        public virtual Campeonatos.CampeonatoGrupo Grupo { get; set; }

        public bool IsValido { get; set; }
        public string ValidadoBy { get; set; }
        public string Titulo { get; set; }
        
        public int PendenteIdTime1 { get; set; }
        public int PendenteIdTime2 { get; set; }
        public bool PendenteTime1Ganhador { get; set; }
        public bool PendenteTime2Ganhador { get; set; }
        public string PendenteTime1NomeGrupo { get; set; }
        public string PendenteTime2NomeGrupo { get; set; }
        public int PendenteTime1PosGrupo { get; set; }
        public int PendenteTime2PosGrupo { get; set; }


        #endregion

        #region Constructors/Destructors

        public Jogo()
        {

        }
        public Jogo(string nomeCampeonato, int jogoId)
        {
            this.JogoId = jogoId;
            this.NomeCampeonato = nomeCampeonato;
            
        }

        #endregion
    }
}
