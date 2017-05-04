using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class Bolao : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string Nome { get; set; }

        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonatos.Campeonato Campeonato { get; set; }

        public string Descricao { get; set; }
        public decimal ? TaxaParticipacao { get; set; }
        
        [NotMapped]
        public Image Foto { get; set; }

        public bool ? Publico { get; set; }
        public bool ? ForumAtivado { get; set; }
        public bool ? PermitirMsgAnonimos { get; set; }
        public DateTime ? DataInicio { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public bool ? ApostasApenasAntes { get; set; }
        public int HorasLimiteAposta { get; set; }
        public bool ? IsIniciado { get; set; }
        public string IniciadoBy { get; set; }
        public DateTime ? DataIniciado { get; set; }

        #endregion

        #region Constructors/Destructors

        public Bolao()
        {

        }

        #endregion
    }
}
