using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Users
{
    public class UserInRole : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order=0)]
        public string RoleName { get; set; }
        [ForeignKey ("RoleName")]
        public virtual Role Role { get; set; }

        [Key, Column(Order = 1)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual User User { get; set; }

        #endregion
    }
}
