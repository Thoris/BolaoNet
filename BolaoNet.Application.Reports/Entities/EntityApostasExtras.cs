using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.Entities
{
    public class EntityApostasExtras
    {
        #region Properties

        public Domain.Entities.Boloes.ApostaExtra ApostaExtra { get; internal set; }
        public Domain.Entities.Boloes.ApostaExtraUsuario ApostaExtraUsuario { get; internal set; }

        #endregion

        #region Constructors/Destructors

        public EntityApostasExtras(Domain.Entities.Boloes.ApostaExtra apostaExtra, Domain.Entities.Boloes.ApostaExtraUsuario apostaExtraUsuario)
        {
            this.ApostaExtra = apostaExtra;
            this.ApostaExtraUsuario = apostaExtraUsuario;
        }

        #endregion
    }
}
