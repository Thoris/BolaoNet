using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class Jogo : Base.AuditModel
    {
        #region Properties

        public long IDJogo { get; set; }
        public virtual Campeonato Campeonato { get; set; }
        public virtual DadosBasicos.Time Time1 { get; set; }
        public string DescricaoTime1 { get; set; }
        public int GolsTime1 { get; set; }
        public int PenaltisTime1 { get; set; }
        public virtual DadosBasicos.Time Time2 { get; set; }
        public string DescricaoTime2 { get; set; }
        public int GolsTime2 { get; set; }
        public int PenaltisTime2 { get; set; }
        public virtual DadosBasicos.Estadio Estadio { get; set; }
        public DateTime DataJogo { get; set; }
        public DateTime OnlyDataJogo
        {
            get { return new DateTime(DataJogo.Year, DataJogo.Month, DataJogo.Day); }
        }
        public TimeSpan HoraJogo
        {
            get { return new TimeSpan(DataJogo.Hour, DataJogo.Minute, DataJogo.Second); }
        }
        public int Rodada { get; set; }
        public bool PartidaValida { get; set; }
        public DateTime DataValidacao { get; set; }
        public virtual Campeonatos.Fase Fase { get; set; }
        public virtual Campeonatos.Grupo Grupo { get; set; }
        public string ValidadoBy { get; set; }
        public string Titulo { get; set; }
        public string JogoLabel { get; set; }
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

        #endregion
    }
}
