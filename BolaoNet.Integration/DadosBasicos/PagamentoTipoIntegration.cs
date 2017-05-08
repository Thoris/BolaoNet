using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.DadosBasicos
{
    public class PagamentoTipoIntegration :
        Base.GenericIntegration<Entities.DadosBasicos.PagamentoTipo>, 
        Business.Interfaces.DadosBasicos.IPagamentoTipoBO
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
