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

            Property(c => c.Identity)
                .HasMaxLength(255);

            Property(c => c.Thread)
                .HasMaxLength(255);

            Property(c => c.Level)
                .HasMaxLength(50);

            Property(c => c.Logger)
                .HasMaxLength(255);

            Property(c => c.Message)
                .HasMaxLength(4000);

            Property(c => c.Exception)
                .HasMaxLength(2000);

        }

        #endregion
    }
}
