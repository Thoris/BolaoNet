using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoMembroConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoMembro>
    {
        
        #region Constructors/Destructors

        public BolaoMembroConfiguration()
        {
            ToTable("BoloesMembros");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            Property(c => c.FullName)
                .HasMaxLength(300);




        }

        #endregion

    }
}
