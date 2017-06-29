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
        public BolaoCampeonatoClassificacaoUsuarioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion    
    
        #region IBolaoCampeonatoClassificacaoUsuarioService members

        public IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, Domain.Entities.Users.User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
