using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoClassificacao : Pontuacao
    {
        #region Properties

        [Key, Column(Order=0)]
        public string NomeCampeonato { get; set; }
        //[ForeignKey("NomeCampeonato")]
        //public virtual Entities.Campeonatos.Campeonato Campeonato { get; set; }

        [Key, Column(Order = 1)]
        public string NomeFase { get; set; }
        [ForeignKey("NomeCampeonato, NomeFase")]
        public virtual Entities.Campeonatos.CampeonatoFase Fase { get; set; }

        //[Key, Column(Order = 2)]
        //public string NomeGrupo { get; set; }
        //[ForeignKey("NomeGrupo")]
        //public virtual Entities.Campeonatos.Grupo Grupo { get; set; }


        [Key, Column(Order = 2)]
        public string NomeGrupo { get; set; }
        [ForeignKey("NomeCampeonato, NomeGrupo, NomeTime")]
        public virtual Campeonatos.CampeonatoGrupoTime Grupo { get; set; }



        [Key, Column(Order = 3)]
        public string NomeTime { get; set; }
        [ForeignKey("NomeTime")]
        public virtual Entities.DadosBasicos.Time Time { get; set; }

        [Key, Column(Order=4)]
        public int Rodada { get; set; }

        public int? Posicao { get; set; }
        public int? LastPosicao { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoClassificacao()
        {

        }

        #endregion
    }
}
