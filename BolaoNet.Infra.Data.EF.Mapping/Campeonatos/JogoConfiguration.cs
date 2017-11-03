using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class JogoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.Jogo>
    {
        
        #region Constructors/Destructors

        public JogoConfiguration()
        {
            ToTable("Jogos");

            Property(c => c.DescricaoTime1)
                .HasMaxLength(100);

            Property(c => c.DescricaoTime2)
                .HasMaxLength(100);


            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeEstadio)
                .HasMaxLength(EstadioConfiguration.NomeLen);

            Property(c => c.NomeFase)
                .HasMaxLength(CampeonatoFaseConfiguration.NomeLen);

            Property(c => c.NomeGrupo)
                .HasMaxLength(CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.NomeTime1)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.NomeTime2)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.PendenteTime1NomeGrupo)
                .HasMaxLength(CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.PendenteTime2NomeGrupo)
                .HasMaxLength(CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.Titulo)
                .HasMaxLength(100);

        


        }

        #endregion
    }
}
