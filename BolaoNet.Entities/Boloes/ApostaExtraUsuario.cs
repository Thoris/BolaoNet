using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class ApostaExtraUsuario : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public int Posicao { get; set; }

        [Key, Column(Order = 2)]
        public string NomeBolao { get; set; }
        [ForeignKey("Posicao, NomeBolao")]
        public virtual ApostaExtra ApostaExtra { get; set; }

        [Key, Column(Order = 3)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }
 
        public DateTime DataAposta { get; set; }
        public int ? Pontos { get; set; }

        public string NomeTime { get; set; }
        [ForeignKey("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }
        
        public bool ? IsApostaValida { get; set; }
        public bool ? Automatico { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraUsuario()
        {

        }

        #endregion
    }
}
