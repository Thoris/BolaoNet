using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities
{
    public class RecordTime : Base.AuditModel
    {

        #region Properties

        public int Posicao { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int Vitorias { get; set; }

        public virtual DadosBasicos.Time Time { get; set; }

        #endregion

        #region Constructors/Destructors

        public RecordTime()
        {
        }

        #endregion
    }
}
