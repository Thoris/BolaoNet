using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class JogoUsuarioConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.JogoUsuario>
    {
        
        #region Constructors/Destructors

        public JogoUsuarioConfiguration()
        {
            ToTable("JogosUsuarios");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

            Property(c => c.NomeCampeonato)
                .HasMaxLength(Campeonatos.CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeTimeResult1)
                .HasMaxLength(DadosBasicos.TimeConfiguration.NomeLen);

            Property(c => c.NomeTimeResult2)
                .HasMaxLength(DadosBasicos.TimeConfiguration.NomeLen);

            






        }

        #endregion
    }
}
