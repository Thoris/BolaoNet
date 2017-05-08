using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoMembroGrupoPontoIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoMembroGrupoPonto>,
        Business.Interfaces.Boloes.IBolaoMembroGrupoPontoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembroGrupoPonto";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroGrupoPontoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroGrupoPontoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
