using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoMembroGrupoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoMembroGrupo>
    {
        
        #region Constructors/Destructors

        public BolaoMembroGrupoConfiguration()
        {
            ToTable("BoloesMembrosGrupos");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            Property(c => c.UserNameSelecionado)
                .HasMaxLength(Users.UserConfiguration.NomeLen);
             

        }

        #endregion
    }
}
