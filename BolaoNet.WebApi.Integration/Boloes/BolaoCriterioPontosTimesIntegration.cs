using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoCriterioPontosTimesIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoCriterioPontosTimes>,
        Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService
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
    
        public IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }
    }
}
