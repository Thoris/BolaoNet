using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class JogoUsuarioIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.JogoUsuario>,
        Domain.Interfaces.Services.Boloes.IJogoUsuarioService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "JogoUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public JogoUsuarioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region IJogoUsuarioService members

        public bool ProcessAposta(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add ("bolao", bolao);
            parameters.Add ("user", user);
            parameters.Add ("jogo", jogo);
            parameters.Add ("automatico", automatico);
            parameters.Add ("apostaTime1", apostaTime1);
            parameters.Add ("apostaTime2", apostaTime2);
            parameters.Add ("penaltis1", penaltis1);
            parameters.Add ("penaltis2", penaltis2);
            parameters.Add ("ganhador", ganhador);

            return base.HttpPostApi<bool>(parameters, "ProcessAposta");
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("nomebolao", bolao);
            parameters.Add("userName", user);

            return HttpPostApi<ICollection<Domain.Entities.Boloes.JogoUsuario>>(
                parameters, "GetJogosByUser").ToList<Domain.Entities.Boloes.JogoUsuario>();

        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("nomebolao", bolao);
            parameters.Add("userName", user);

            return HttpPostApi<ICollection<Domain.Entities.ValueObjects.JogoUsuarioVO>>(
                parameters, "GetJogosUser").ToList<Domain.Entities.ValueObjects.JogoUsuarioVO>();
        }

        #endregion





    }
}
