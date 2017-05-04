using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Users
{
    public class Role : Base.AuditModel
    {
        #region Properties

        [Key]
        public string RoleName { get; set; }
        public string Descricao { get; set; }

        #endregion
    }
}
