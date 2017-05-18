using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoPontoRodada : Base.AuditModel
    {
        #region Properties

        

        [Key, Column(Order=0)]
        public int Posicao { get; set; }

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        
        [Key, Column(Order = 2)]
        public string NomeGrupo { get; set; }
        
        [Key, Column(Order = 3)]
        public string NomeFase { get; set; }

        [Key, Column(Order = 4)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [ForeignKey("NomeCampeonato, NomeFase")]
        public virtual Campeonatos.CampeonatoFase CampeonatoFase { get; set; }

        [ForeignKey("NomeCampeonato, NomeGrupo")]
        public virtual Campeonatos.CampeonatoGrupo CampeonatoGrupo { get; set; }



        public string Titulo { get; set; }
        public int Pontos { get; set; }
        public DateTime DataValidacao { get; set; }


        #endregion
    }
}
