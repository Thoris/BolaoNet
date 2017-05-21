using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoPosicao : DadosBasicos.HighLightItem
    {       
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        //[ForeignKey("NomeCampeonato")]
        //public virtual Campeonatos.Campeonato Campeonato {get;set;}

        [Key, Column(Order = 2)]
        public string NomeFase { get; set; }
        [ForeignKey("NomeCampeonato, NomeFase")]
        public virtual Campeonatos.CampeonatoFase Fase { get; set; }

        [Key, Column(Order = 3)]
        public string NomeGrupo { get; set; }
        [ForeignKey("NomeCampeonato, NomeGrupo")]
        public virtual Campeonatos.CampeonatoGrupo Grupo { get; set; }

        [Key, Column(Order = 4)]
        public string NomeTime { get; set; }

        [Key, Column(Order = 5)]
        public int Posicao { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public CampeonatoPosicao()
        {

        }

        #endregion
    }
}
