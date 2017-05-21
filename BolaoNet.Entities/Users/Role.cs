using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Users
{
    public class Role : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order=0)]
        public string RoleName { get; set; }
        public string Descricao { get; set; }

        #endregion

        #region Constructors/Destructors

        public Role()
        {

        }
        public Role(string name)
        {
            this.RoleName = name;
        }

        #endregion
    }
}
