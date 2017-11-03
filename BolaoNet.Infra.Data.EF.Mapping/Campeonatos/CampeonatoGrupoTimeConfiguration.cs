using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoGrupoTimeConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoGrupoTime>
    {

        #region Constructors/Destructors

        public CampeonatoGrupoTimeConfiguration()
        {
            ToTable("CampeonatosGruposTimes");

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeGrupo)
                .HasMaxLength(CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.NomeTime)
                .HasMaxLength(TimeConfiguration.NomeLen);

        }

        #endregion
    }
}
