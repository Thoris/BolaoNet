using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class ApostaPontosIntegration :
        Base.GenericIntegration<Entities.Boloes.ApostaPontos>,
        Business.Interfaces.Boloes.IApostaPontosBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostaPontos";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaPontosIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostaPontosIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    }
}
