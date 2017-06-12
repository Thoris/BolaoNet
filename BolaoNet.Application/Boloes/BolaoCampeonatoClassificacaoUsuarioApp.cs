using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Application.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCampeonatoClassificacaoUsuarioApp" />.
        /// </summary>
        public BolaoCampeonatoClassificacaoUsuarioApp(Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService service)
            : base (service)
        {

        }

        #endregion    
    }
}
