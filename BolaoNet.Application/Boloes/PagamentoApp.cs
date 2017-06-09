using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class PagamentoApp :
        Base.GenericApp<Domain.Entities.Boloes.Pagamento>,
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
        /// Inicializa nova instância da classe <see cref="PagamentoApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public PagamentoApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
