using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class GrupoIntegration :
        Base.GenericIntegration<Entities.Campeonatos.Grupo>,
        Business.Interfaces.Campeonatos.IGrupoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Grupo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="GrupoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public GrupoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
