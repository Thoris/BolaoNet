using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.DadosBasicos
{
    public class PagamentoTipoIntegration :
        Base.GenericIntegration<Domain.Entities.DadosBasicos.PagamentoTipo>, 
        Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "PagamentoTipo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PagamentoTipoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public PagamentoTipoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
