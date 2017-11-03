using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.DadosBasicos
{
    public class CriterioFixoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.DadosBasicos.CriterioFixo>
    {
        
        #region Constructors/Destructors

        public CriterioFixoConfiguration()
        {
            ToTable("CriteriosFixos");

            Property(c => c.Descricao)
                .HasMaxLength(255);

        }

        #endregion
    }
}
