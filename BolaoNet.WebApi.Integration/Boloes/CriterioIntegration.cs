using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class CriterioIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.Criterio>,
        Domain.Interfaces.Services.Boloes.ICriterioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Criterio";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CriterioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CriterioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
