using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class ApostaExtraUsuario : ApostaExtra
    {
        #region Properties

        [Key, Column(Order = 3)]        
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }

        public DateTime DataAposta { get; set; }
        public int ? Pontos { get; set; }
        public string NomeTime { get; set; }
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
