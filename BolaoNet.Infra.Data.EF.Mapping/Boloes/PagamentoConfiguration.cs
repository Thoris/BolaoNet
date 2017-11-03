using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class PagamentoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.Pagamento>
    {
        
        #region Constructors/Destructors

        public PagamentoConfiguration()
        {
            ToTable("Pagamentos");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            
        }

        #endregion
    }
}
