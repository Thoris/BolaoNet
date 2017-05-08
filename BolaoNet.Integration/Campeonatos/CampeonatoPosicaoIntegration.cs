using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class CampeonatoPosicaoIntegration :
        Base.GenericIntegration<Entities.Campeonatos.CampeonatoPosicao>,
        Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CampeonatoPosicao";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoPosicaoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public CampeonatoPosicaoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
