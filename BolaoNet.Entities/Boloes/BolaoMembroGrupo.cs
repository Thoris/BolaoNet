using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoMembroGrupo : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 0)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public Users.User User { get; set; }

        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        public string IncluidoBy { get; set; }
        [ForeignKey("IncluidoBy")]
        public Users.User UserInclusao { get; set; }


        #endregion

        #region Constructors/Destructors

        public BolaoMembroGrupo()
        {

        }
        public BolaoMembroGrupo(string userName, string nomeBolao)
        {
            this.UserName = userName;
            this.NomeBolao = nomeBolao;
        }

        #endregion
    }
}
