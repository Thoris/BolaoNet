using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class MensagemIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.Mensagem>,
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
        /// Inicializa nova instância da classe <see cref="MensagemIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public MensagemIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region IMensagemService members

        public IList<Domain.Entities.Boloes.Mensagem> GetMensagensUsuario(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
