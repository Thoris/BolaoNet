using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class ApostaExtraIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.ApostaExtra>, 
        Domain.Interfaces.Services.Boloes.IApostaExtraService 
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "ApostaExtra";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public ApostaExtraIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public bool InsertResult(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            throw new NotImplementedException();
        }
    }
}
