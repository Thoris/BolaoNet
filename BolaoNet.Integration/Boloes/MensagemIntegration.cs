using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class MensagemIntegration :
        Base.GenericIntegration<Entities.Boloes.Mensagem>,
        Business.Interfaces.Boloes.IMensagemBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Mensagem";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="MensagemIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public MensagemIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
