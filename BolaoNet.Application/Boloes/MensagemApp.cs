using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class MensagemApp :
        Base.GenericApp<Domain.Entities.Boloes.Mensagem>,
        Domain.Interfaces.Services.Boloes.IMensagemService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Mensagem";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="MensagemApp" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public MensagemApp(string url)
            : base (url, ModuleName)
        {

        }

        #endregion
    }
}
