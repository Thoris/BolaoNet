using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoMembroClassificacaoIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoMembroClassificacao>,
        Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembroClassificacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroClassificacaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroClassificacaoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
