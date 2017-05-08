using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoPontuacaoIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoPontuacao>,
        Business.Interfaces.Boloes.IBolaoPontuacaoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoPontuacao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPontuacaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoPontuacaoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
