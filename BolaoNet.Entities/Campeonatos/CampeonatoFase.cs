using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoFase : Base.AuditModel
    {
        #region Properties
   
        [Key, Column(Order = 0)]
        public string Nome { get; set; }

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }

        public string Descricao { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoFase()
        {

        }
        public CampeonatoFase(string nomeFase, string nomeCampeonato)
        {
            this.Nome = nomeFase;
            this.NomeCampeonato = nomeCampeonato;
        }

        #endregion
    }
}
