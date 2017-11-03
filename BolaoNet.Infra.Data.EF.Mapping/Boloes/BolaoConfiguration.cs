using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.Bolao>
    {

        #region Constants

        public const int NomeLen = 100;

        #endregion

        #region Constructors/Destructors

        public BolaoConfiguration()
        {
            ToTable("Boloes");

            Property(c => c.Cidade)
                .HasMaxLength(150);

            Property(c => c.Estado)
                .HasMaxLength(50);

            Property(c => c.Nome)
                .HasMaxLength(NomeLen);

            Property(c => c.NomeCampeonato)
                .HasMaxLength(Campeonatos.CampeonatoConfiguration.NomeLen);

            Property(c => c.Pais)
                .HasMaxLength(30);


        }

        #endregion

    }
}
