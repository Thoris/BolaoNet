using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.DadosBasicos
{
    public class PagamentoTipoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.DadosBasicos.PagamentoTipo>
    {
        
        #region Constructors/Destructors

        public PagamentoTipoConfiguration()
        {
            ToTable("PagamentosTipo");

            Property(c => c.Descricao)
                .HasMaxLength(255);

        }

        #endregion
    }
}
