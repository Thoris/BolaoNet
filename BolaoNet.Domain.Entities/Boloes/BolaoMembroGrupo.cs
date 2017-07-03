using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoMembroGrupo : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        //[ForeignKey("NomeBolao")]
        //public virtual Bolao Bolao { get; set; }

        [Key, Column(Order = 2)]
        public string UserName { get; set; }
        //[ForeignKey("UserName")]
        //public Users.User User { get; set; }
        
        [ForeignKey("NomeBolao, UserName")]
        public virtual BolaoMembro BolaoMembro { get; set; }

        public string UserNameSelecionado { get; set; }
        [ForeignKey("UserNameSelecionado")]
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
