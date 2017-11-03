using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.DadosBasicos
{
    public class EstadioConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.DadosBasicos.Estadio>
    {
        #region Constants

        public const int NomeLen = 50;

        #endregion

        #region Constructors/Destructors

        public EstadioConfiguration()
        {
            ToTable("Estadios");

            Property(c => c.Cidade)
                .HasMaxLength(50);

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.Estado)
                .HasMaxLength(30);

            Property(c => c.Nome)
                .HasMaxLength(NomeLen);

            Property(c => c.NomeTime)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.Pais)
                .HasMaxLength(60);

        }

        #endregion
    }
}
