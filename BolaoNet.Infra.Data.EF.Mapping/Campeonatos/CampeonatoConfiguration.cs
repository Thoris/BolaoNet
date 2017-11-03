using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.Campeonato>
    {
        #region Constants

        public const int NomeLen = 150;

        #endregion

        #region Constructors/Destructors

        public CampeonatoConfiguration()
        {
            ToTable("Campeonatos");

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.FaseAtual)
                .HasMaxLength(CampeonatoFaseConfiguration.NomeLen);

            Property(c => c.Nome)
                .HasMaxLength(NomeLen);
        }

        #endregion
    }
}
