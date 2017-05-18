using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoGrupo : Base.AuditModel
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

        public CampeonatoGrupo()
        {

        }
        public CampeonatoGrupo(string nomeGrupo, string nomeCampeonato)
        {
            this.Nome = nomeGrupo;
            this.NomeCampeonato = nomeCampeonato;
        }

        #endregion
    }
}
