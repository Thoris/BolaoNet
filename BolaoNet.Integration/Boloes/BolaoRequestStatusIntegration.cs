using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoRequestStatusIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoRequestStatus>,
        Business.Interfaces.Boloes.IBolaoRequestStatusBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRequestStatus";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRequestStatusIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRequestStatusIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
