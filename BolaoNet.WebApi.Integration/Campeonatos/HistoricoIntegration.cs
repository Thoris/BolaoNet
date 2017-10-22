using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class HistoricoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.Historico>,
        Domain.Interfaces.Services.Campeonatos.IHistoricoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Historico";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="HistoricoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public HistoricoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion
    }
}
