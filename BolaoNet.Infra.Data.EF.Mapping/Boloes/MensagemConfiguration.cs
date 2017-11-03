using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class MensagemConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.Mensagem>
    {
        
        #region Constructors/Destructors

        public MensagemConfiguration()
        {
            ToTable("Mensagens");

            Property(c => c.FromUser)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            Property(c => c.Message)
                .HasMaxLength(255);

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.Title)
                .HasMaxLength(150);

            Property(c => c.ToUser)
                .HasMaxLength(Users.UserConfiguration.NomeLen);






        }

        #endregion
    }
}
