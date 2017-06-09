using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoRequestStatusIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoRequestStatus>,
        Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService
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
