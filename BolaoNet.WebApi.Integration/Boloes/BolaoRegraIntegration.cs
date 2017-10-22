using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoRegraIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoRegra>,
        Domain.Interfaces.Services.Boloes.IBolaoRegraService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoRegra";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoRegraIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoRegraIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IBolaoRegraService members

        public IList<Domain.Entities.Boloes.BolaoRegra> GetRegrasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.Boloes.BolaoRegra>>(
                new Dictionary<string, string>(), bolao, "GetRegrasBolao");
        }

        #endregion
    }
}
