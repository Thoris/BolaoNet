using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports
{
    public class EntityApostasExtras
    {
        #region Properties

        public Entities.Boloes.ApostaExtra ApostaExtra { get; internal set; }
        public Entities.Boloes.ApostaExtraUsuario ApostaExtraUsuario { get; internal set; }

        #endregion

        #region Constructors/Destructors

        public EntityApostasExtras(Entities.Boloes.ApostaExtra apostaExtra, Entities.Boloes.ApostaExtraUsuario apostaExtraUsuario)
        {
            this.ApostaExtra = apostaExtra;
            this.ApostaExtraUsuario = apostaExtraUsuario;
        }

        #endregion
    }
}
