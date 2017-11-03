using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoFaseConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoFase>
    {
        #region Constants

        public const int NomeLen = 50;

        #endregion

        #region Constructors/Destructors

        public CampeonatoFaseConfiguration()
        {
            ToTable("CampeonatosFases");

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.Nome)
                .HasMaxLength(NomeLen);

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

        }

        #endregion
    }
}
