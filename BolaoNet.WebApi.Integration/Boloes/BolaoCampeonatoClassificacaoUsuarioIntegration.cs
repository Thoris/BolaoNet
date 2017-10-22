using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoCampeonatoClassificacaoUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCampeonatoClassificacaoUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoCampeonatoClassificacaoUsuarioIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion    
    
        #region IBolaoCampeonatoClassificacaoUsuarioService members

        public IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("fase", fase);
            parameters.Add("grupo", grupo);
            parameters.Add("user", user);

            return base.HttpPostApi<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>>(parameters, "LoadClassificacao");
        }

        #endregion
    }
}
