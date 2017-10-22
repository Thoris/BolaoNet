using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class PagamentoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.Pagamento>,
        Domain.Interfaces.Services.Boloes.IPagamentoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Pagamento";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PagamentoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public PagamentoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IPagamentoService members

        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.Boloes.Pagamento>>(
                 new Dictionary<string, string>(), bolao, "GetPagamentosBolao");
        }

        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolaoSoma(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.Boloes.Pagamento>>(
                 new Dictionary<string, string>(), bolao, "GetPagamentosBolaoSoma");
        }
        #endregion
    }
}
