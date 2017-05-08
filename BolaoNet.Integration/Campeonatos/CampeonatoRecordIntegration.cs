using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class CampeonatoRecordIntegration :
        Base.GenericIntegration<Entities.Campeonatos.CampeonatoRecord>,
        Business.Interfaces.Campeonatos.ICampeonatoRecordBO
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
