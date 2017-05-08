using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoMembroGrupoIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoMembroGrupo>,
        Business.Interfaces.Boloes.IBolaoMembroGrupoBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembroGrupo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroGrupoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroGrupoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
