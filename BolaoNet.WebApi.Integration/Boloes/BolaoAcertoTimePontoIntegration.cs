using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoAcertoTimePontoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoAcertoTimePonto>,
        Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoAcertoTimePonto";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoAcertoTimePontoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoAcertoTimePontoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion    
    
        #region IBolaoAcertoTimePontoService members

        public Domain.Entities.Boloes.BolaoAcertoTimePonto GetByJogoId(Domain.Entities.Boloes.Bolao bolao, int jogoId)
        {
            return null;
        }

        #endregion
    }
}
