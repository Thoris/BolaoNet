using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoHistoricoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoHistorico>,
        Domain.Interfaces.Services.Boloes.IBolaoHistoricoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoHistorico";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoHistoricoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoHistoricoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    
        #region IBolaoHistoricoService members

       

        #endregion
    }
}
