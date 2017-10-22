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
        public ApostaExtraIntegration(string url, string token)
            : base (url, ModuleName, token)
        {

        }

        #endregion

        #region IApostaExtraService members

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Boloes.ApostaExtra>>
                (new Dictionary<string, string>(), bolao, "GetApostasBolao").ToList<Domain.Entities.Boloes.ApostaExtra>();
        }

        public bool InsertResult(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("time", time);
            parameters.Add("posicao", posicao);
            parameters.Add("validadoBy", validadoBy);

            return base.HttpPostApi<bool>(parameters, "InsertResult");
        }

        #endregion
    }
}
