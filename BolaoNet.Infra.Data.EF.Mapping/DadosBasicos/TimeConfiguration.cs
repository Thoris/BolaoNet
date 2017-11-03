using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.DadosBasicos
{
    public class TimeConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.DadosBasicos.Time>
    {
        #region Constants

        public const int NomeLen = 150;

        #endregion

        #region Constructors/Destructors

        public TimeConfiguration()
        {
            ToTable("Times");

            //HasKey(c => c.Nome);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(NomeLen);

            Property(c => c.Cidade)
                .HasMaxLength(150);

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.Estado)
                .HasMaxLength(30);

            Property(c => c.NomeMascote)
                .HasMaxLength(30);

            Property(c => c.Pais)
                .HasMaxLength(30);

            Property(c => c.Site)
                .HasMaxLength(100);

        }

        #endregion
    }
}
