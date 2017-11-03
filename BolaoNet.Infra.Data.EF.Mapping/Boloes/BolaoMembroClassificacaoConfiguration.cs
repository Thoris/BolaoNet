using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoMembroClassificacaoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoMembroClassificacao>
    {
        
        #region Constructors/Destructors

        public BolaoMembroClassificacaoConfiguration()
        {
            ToTable("BoloesMembrosClassificacao");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);
             

        }

        #endregion
    }
}
