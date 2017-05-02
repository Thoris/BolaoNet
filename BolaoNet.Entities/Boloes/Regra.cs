using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class Regra : Base.AuditModel
    {
        #region Properties

        public string Description { get; set; }
        public int RegraID { get; set; }
        public virtual Bolao Bolao { get; set; }

        #endregion

        #region Constructors/Destructors

        public Regra()
        {

        }

        #endregion
    }
}
