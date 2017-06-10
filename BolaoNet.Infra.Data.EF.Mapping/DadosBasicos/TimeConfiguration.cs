using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.DadosBasicos
{
    public class TimeConfiguration : 
        Base.BaseConfiguration<Domain.Entities.DadosBasicos.Time>
    {
        
        #region Constructors/Destructors

        public TimeConfiguration()
        {
            HasKey(c => c.Nome);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }

        #endregion
    }
}
