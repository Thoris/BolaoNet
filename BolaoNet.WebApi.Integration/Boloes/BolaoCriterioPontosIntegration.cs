using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoCriterioPontosIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoCriterioPontos>,
        Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoCriterioPontos";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoCriterioPontosIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    
        #region IBolaoCriterioPontosService members

        public int[] GetCriteriosPontos(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
