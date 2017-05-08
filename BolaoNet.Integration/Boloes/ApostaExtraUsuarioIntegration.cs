using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class ApostaExtraUsuarioIntegration :
        Base.GenericIntegration<Entities.Boloes.ApostaExtraUsuario>,
        Business.Interfaces.Boloes.IApostaExtraUsuarioBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostaExtraUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostaExtraUsuarioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
