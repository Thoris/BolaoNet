using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoHistoricoConfiguration
        : Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoHistorico>
    {
        #region Constructors/Destructors

        public BolaoHistoricoConfiguration()
        {
            ToTable("BoloesHistorico");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);
             


        }

        #endregion
    }
}
