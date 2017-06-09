using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoHistoricoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoHistorico>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoHistorico";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoHistoricoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoHistoricoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
