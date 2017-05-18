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
        public string UserNameSelecionado { get; set; }
        [ForeignKey("UserNameSelecionado")]
        public Users.User UserSelecionado { get; set; }

        [Key, Column(Order = 2)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        #endregion
    }
}
