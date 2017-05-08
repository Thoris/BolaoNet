using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class CampeonatoFaseIntegration :
        Base.GenericIntegration<Entities.Campeonatos.CampeonatoFase>,
        Business.Interfaces.Campeonatos.ICampeonatoFaseBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoFase";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoFaseIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoFaseIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
