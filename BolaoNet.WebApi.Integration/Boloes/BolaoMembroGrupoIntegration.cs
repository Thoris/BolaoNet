using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoMembroGrupoIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoMembroGrupo>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService
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

        #region IBolaoMembroGrupoService members

        public IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("user", user);

            return base.HttpPostApi<IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>>(parameters, "LoadClassificacao");   
        
        }

        #endregion
    }
}
