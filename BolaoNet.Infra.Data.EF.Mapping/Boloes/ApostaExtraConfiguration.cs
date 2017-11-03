using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class ApostaExtraConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.ApostaExtra>        
    {

        #region Constructors/Destructors

        public ApostaExtraConfiguration()
        {
            ToTable("ApostasExtras");

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.NomeTimeValidado)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.Titulo)
                .HasMaxLength(150);

            Property(c => c.ValidadoBy)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

        }

        #endregion
        
    }
}
