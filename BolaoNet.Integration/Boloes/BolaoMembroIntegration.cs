using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class BolaoMembroIntegration :
        Base.GenericIntegration<Entities.Boloes.BolaoMembro>,
        Business.Interfaces.Boloes.IBolaoMembroBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembro";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region IBolaoMembroBO members
        
        public IList<Entities.Boloes.BolaoMembro> GetListUsersInBolao(Entities.Boloes.Bolao bolao)
        {
            return null;
        }

        #endregion
    }
}
