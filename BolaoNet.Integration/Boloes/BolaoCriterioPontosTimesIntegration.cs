using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoCriterioPontosTimesIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoCriterioPontosTimes>,
        Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoCriterioPontosTimes";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosTimesIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoCriterioPontosTimesIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion 
    }
}
