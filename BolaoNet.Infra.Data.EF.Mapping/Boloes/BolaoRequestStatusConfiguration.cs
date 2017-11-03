using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoRequestStatusConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoRequestStatus>
    {
        
        #region Constructors/Destructors

        public BolaoRequestStatusConfiguration()
        {
            ToTable("BoloesRequestsStatus");

            Property(c => c.Descricao)
                .HasMaxLength(255);

        }

        #endregion
    }
}
