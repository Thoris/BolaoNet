using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class ApostaExtraIntegration :
        Base.GenericIntegration<Entities.Boloes.ApostaExtra>, 
        Business.Interfaces.Boloes.IApostaExtraBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostaExtra";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostaExtraIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
