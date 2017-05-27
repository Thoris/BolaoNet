using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class JogoUsuarioIntegration :
        Base.GenericIntegration<Entities.Boloes.JogoUsuario>,
        Business.Interfaces.Boloes.IJogoUsuarioBO
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

        #region IJogoUsuarioBO members

        public bool ProcessAposta(Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Boloes.JogoUsuario> GetJogosByUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("nomebolao", bolao.Nome);
            parameters.Add("userName", user.UserName);

            return base.HttpGetApi<ICollection<Entities.Boloes.JogoUsuario>>(
                parameters, "GetJogosByUser").ToList();
        }

        #endregion


    }
}
