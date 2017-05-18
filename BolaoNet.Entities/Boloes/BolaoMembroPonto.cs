using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoMembroPonto : Entities.Boloes.Pontuacao
    {
        #region Properties

        [Key, Column(Order = 0)]
        public string UserName { get; set; }
        
        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        
        [Key, Column (Order = 2)]
        public string NomeCampeonato { get; set; }

        [Key, Column(Order = 3)]
        public string NomeFase { get; set; }

        [Key, Column(Order = 4)]
        public string NomeGrupo { get; set; }

        [Key, Column(Order = 5)]
        public int Rodada { get; set; }


        [ForeignKey("UserName, NomeBolao")]
        public virtual BolaoMembro BolaoMembro { get; set; }

        [ForeignKey("NomeCampeonato, NomeGrupo")]
        public virtual Campeonatos.CampeonatoGrupo CampeonatoGrupo {get; set;}

        [ForeignKey("NomeCampeonato, NomeFase")]
        public virtual Campeonatos.CampeonatoFase CampeonatoFase { get; set; }

        #endregion
    }
}
