using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class CampeonatoTimeIntegration :
        Base.GenericIntegration<Entities.Campeonatos.CampeonatoTime>,
        Business.Interfaces.Campeonatos.ICampeonatoTimeBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoTime";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoTimeIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoTimeIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
