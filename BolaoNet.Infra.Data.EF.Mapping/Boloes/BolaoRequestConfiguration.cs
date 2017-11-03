using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoRequestConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoRequest>
    {
        
        #region Constructors/Destructors

        public BolaoRequestConfiguration()
        {
            ToTable("BoloesRequests");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.AnsweredBy)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.Owner)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            Property(c => c.RequestedBy)
                .HasMaxLength(Users.UserConfiguration.NomeLen);







        }

        #endregion
    }
}
