using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoCriterioPontosIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoCriterioPontos>,
        Business.Interfaces.Boloes.IBolaoCriterioPontosBO
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
    
        #region IBolaoCriterioPontosBO members

        public int[] GetCriteriosPontos(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
