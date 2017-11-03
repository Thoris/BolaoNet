using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoClassificacaoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoClassificacao>
    {        
        #region Constructors/Destructors

        public CampeonatoClassificacaoConfiguration()
        {
            ToTable("CampeonatosClassificacao");

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeFase)
                .HasMaxLength(CampeonatoFaseConfiguration.NomeLen);

            Property(c => c.NomeGrupo)
                .HasMaxLength(CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.NomeTime)
                .HasMaxLength(TimeConfiguration.NomeLen);

        }

        #endregion

    }
}
