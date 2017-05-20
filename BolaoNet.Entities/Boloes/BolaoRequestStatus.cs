using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoRequestStatus : Base.AuditModel
    {
        #region Properties

        [Key]
        public int StatusRequestID { get; set; }
        public string Descricao { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoRequestStatus()
        {

        }
        public BolaoRequestStatus(int statusRequestID)
        {
            this.StatusRequestID = statusRequestID;
        }

        #endregion
    }
}
