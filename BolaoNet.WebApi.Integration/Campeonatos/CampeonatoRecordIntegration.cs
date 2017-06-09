using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class CampeonatoRecordIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.CampeonatoRecord>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoRecord";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoRecordIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoRecordIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
