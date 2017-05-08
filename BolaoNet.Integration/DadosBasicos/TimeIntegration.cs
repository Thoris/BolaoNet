using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.DadosBasicos
{
    public class TimeIntegration :
        Base.GenericIntegration<Entities.DadosBasicos.Time>,
        Business.Interfaces.DadosBasicos.ITimeBO
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
        public TimeIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
