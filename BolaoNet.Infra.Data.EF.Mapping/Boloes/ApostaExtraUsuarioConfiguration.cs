using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class ApostaExtraUsuarioConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.ApostaExtraUsuario>
    {
        
        #region Constructors/Destructors

        public ApostaExtraUsuarioConfiguration()
        {
            ToTable("ApostasExtrasUsuarios");


            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.NomeTime)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);


        }

        #endregion

    }
}
