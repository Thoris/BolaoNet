using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoCampeonatoClassificacaoUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCampeonatoClassificacaoUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoCampeonatoClassificacaoUsuarioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    }
}
