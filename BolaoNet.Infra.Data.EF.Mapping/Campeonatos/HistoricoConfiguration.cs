using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class HistoricoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.Historico>
    {
        
        #region Constructors/Destructors

        public HistoricoConfiguration()
        {

            Property(c => c.Nome)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

        }

        #endregion
    }
}
