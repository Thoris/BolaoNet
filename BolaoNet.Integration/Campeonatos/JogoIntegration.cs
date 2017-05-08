using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Campeonatos
{
    public class JogoIntegration :
        Base.GenericIntegration<Entities.Campeonatos.Jogo>,
        Business.Interfaces.Campeonatos.IJogoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Jogo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public JogoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
