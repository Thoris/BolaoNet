using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.DadosBasicos
{
    public class CriterioFixoIntegration :
        Base.GenericIntegration<Entities.DadosBasicos.CriterioFixo>,
        Business.Interfaces.DadosBasicos.ICriterioFixoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CriterioFixo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CriterioFixoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CriterioFixoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
