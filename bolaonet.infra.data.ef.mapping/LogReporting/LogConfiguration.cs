using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.LogReporting
{
    public class LogConfiguration :
         Base.BaseConfiguration<BolaoNet.Domain.Entities.LogReporting.LogEvent>
    {

        #region Constructors/Destructors

        public LogConfiguration()
        {
            ToTable("Log");

            //Property(c => c.Descricao)
            //    .HasMaxLength(255);

        }

        #endregion
    }
}
