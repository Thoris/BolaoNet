using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class ApostasRestantesIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.ApostasRestantesUser>,
        Domain.Interfaces.Services.Boloes.IApostasRestantesService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostasRestantes";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostasRestantesIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostasRestantesIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
