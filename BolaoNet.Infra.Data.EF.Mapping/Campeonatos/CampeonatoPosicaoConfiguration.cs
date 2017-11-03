using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoPosicaoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoPosicao>
    {
        
        #region Constructors/Destructors

        public CampeonatoPosicaoConfiguration()
        {
            ToTable("CampeonatosPosicoes");

            Property(c => c.BackColorName)
                .HasMaxLength(50);


            Property(c => c.ForeColorName)
                .HasMaxLength(50);

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeFase)
                .HasMaxLength(CampeonatoFaseConfiguration.NomeLen);

            Property(c => c.NomeGrupo)
                .HasMaxLength(CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.Titulo)
                .HasMaxLength(100);

        }

        #endregion
    }
}
