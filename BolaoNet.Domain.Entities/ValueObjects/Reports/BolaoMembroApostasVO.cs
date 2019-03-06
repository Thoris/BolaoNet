using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects.Reports
{
    public class BolaoMembroApostasVO
    {
        #region Properties

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public IList<JogoUsuarioVO> JogosUsuarios { get; set; }
        public IList<ApostaExtraUsuarioVO> ApostasExtras { get; set; }
        public IList<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>> ClassificacaoTimes { get; set; }
        public Domain.Entities.Campeonatos.Campeonato.Tipos TipoCampeonato { get; set; }
        //public IList<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>> ClassificacaoTimes { get; set; }

        #endregion
    }
}
