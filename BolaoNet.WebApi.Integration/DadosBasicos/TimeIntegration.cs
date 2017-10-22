using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.DadosBasicos
{
    public class TimeIntegration :
        Base.GenericIntegration<Domain.Entities.DadosBasicos.Time>,
        Domain.Interfaces.Services.DadosBasicos.ITimeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Time";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="TimeIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public TimeIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion
    }
}
