using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class Fase : Base.AuditModel
    {
        #region Properties

        [Key]
        public string Nome { get; set; }
         
        [ForeignKey("NomeCampeonato"), Column(Order = 0)]
        public virtual Campeonatos.Campeonato Campeonato { get; set; }
        public string NomeCampeonato { get; set; }

        public string Descricao { get; set; }

        #endregion

        #region Constructors/Destructors

        public Fase()
        {

        }

        #endregion
    }
}
