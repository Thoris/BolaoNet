using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoPontoRodadaIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoPontoRodada>,
        Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoPontoRodada";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPontoRodadaIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoPontoRodadaIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
