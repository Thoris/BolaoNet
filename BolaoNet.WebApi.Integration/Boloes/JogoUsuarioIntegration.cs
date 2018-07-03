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
        public JogoUsuarioIntegration(string url, string token)
            : base(url, ModuleName, token)
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

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("user", user);
            parameters.Add("filter", filter);

            return HttpPostApi<ICollection<Domain.Entities.ValueObjects.JogoUsuarioVO>>(
                parameters, "GetJogosUser").ToList<Domain.Entities.ValueObjects.JogoUsuarioVO>();
        }

        public void InsertApostasAutomaticas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("user", user);
            parameters.Add("filter", filter);

            HttpPostApi<bool>(
                parameters, "InsertApostasAutomaticas");
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Jogo jogo)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("jogo", jogo);

            return HttpPostApi<ICollection<Domain.Entities.Boloes.JogoUsuario>>(
                parameters, "GetApostasJogo").ToList<Domain.Entities.Boloes.JogoUsuario>();
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(Domain.Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("totalMaximoAcertos", totalMaximoAcertos);

            return HttpPostApi<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>>(
                parameters, "LoadAcertosDificeis") ;
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadSemAcertos(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.Campeonatos.Jogo>>(
                 new Dictionary<string, string>(), bolao, "LoadSemAcertos");
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(Domain.Entities.Users.User user, int totalRetorno)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("user", user);
            parameters.Add("totalRetorno", totalRetorno);

            return HttpPostApi<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>>(
                parameters, "LoadPontosObtidos");
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(Domain.Entities.Users.User user, int totalRetorno)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("user", user);
            parameters.Add("totalRetorno", totalRetorno);

            return HttpPostApi<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>>(
                parameters, "LoadProximosJogosUsuario");
        }

        public int CalcularPontoSimulation(int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("gols1", gols1);
            parameters.Add("gols2", gols2);
            parameters.Add("aposta1", aposta1);
            parameters.Add("aposta2", aposta2);
            parameters.Add("pontosEmpate", pontosEmpate);
            parameters.Add("pontosVitoria", pontosVitoria);
            parameters.Add("pontosDerrota", pontosDerrota);
            parameters.Add("pontosGanhador", pontosGanhador);
            parameters.Add("pontosPerdedor", pontosPerdedor);
            parameters.Add("pontosTime1", pontosTime1);
            parameters.Add("pontosTime2", pontosTime2);
            parameters.Add("pontosVDE", pontosVDE);
            parameters.Add("pontosErro", pontosErro);
            parameters.Add("pontosGanhadorFora", pontosGanhadorFora);
            parameters.Add("pontosGanhadorDentro", pontosGanhadorDentro);
            parameters.Add("pontosPerdedorFora",pontosPerdedorFora);
            parameters.Add("pontosPerdedorDentro", pontosPerdedorDentro);
            parameters.Add("pontosEmpateGols",pontosEmpateGols);
            parameters.Add("pontosGolsTime1", pontosGolsTime1);
            parameters.Add("pontosGolsTime2",pontosGolsTime2);
            parameters.Add("pontosCheio", pontosCheio);
            parameters.Add("isMultiploTime", isMultiploTime);
            parameters.Add("multiploTime", multiploTime);
             

            return HttpPostApi<int>(
                parameters, "CalcularPontoSimulation");
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> Simulate(IList<Domain.Entities.Boloes.JogoUsuario> apostas, int gols1, int gols2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("apostas", apostas);
            
            parameters.Add("gols1", gols1);
            parameters.Add("gols2", gols2); 
            parameters.Add("pontosEmpate", pontosEmpate);
            parameters.Add("pontosVitoria", pontosVitoria);
            parameters.Add("pontosDerrota", pontosDerrota);
            parameters.Add("pontosGanhador", pontosGanhador);
            parameters.Add("pontosPerdedor", pontosPerdedor);
            parameters.Add("pontosTime1", pontosTime1);
            parameters.Add("pontosTime2", pontosTime2);
            parameters.Add("pontosVDE", pontosVDE);
            parameters.Add("pontosErro", pontosErro);
            parameters.Add("pontosGanhadorFora", pontosGanhadorFora);
            parameters.Add("pontosGanhadorDentro", pontosGanhadorDentro);
            parameters.Add("pontosPerdedorFora", pontosPerdedorFora);
            parameters.Add("pontosPerdedorDentro", pontosPerdedorDentro);
            parameters.Add("pontosEmpateGols", pontosEmpateGols);
            parameters.Add("pontosGolsTime1", pontosGolsTime1);
            parameters.Add("pontosGolsTime2", pontosGolsTime2);
            parameters.Add("pontosCheio", pontosCheio);
            parameters.Add("isMultiploTime", isMultiploTime);
            parameters.Add("multiploTime", multiploTime);

            return HttpPostApi<IList<Domain.Entities.Boloes.JogoUsuario>>(
                parameters, "Simulate");

        }
        
        public bool CorrecaoEliminatorias(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("bolao", bolao);
            parameters.Add("user", user);

            return base.HttpPostApi<bool>(parameters, "CorrecaoEliminatorias");
        }

        public IList<Domain.Entities.ValueObjects.StatClassificacaoVO> LoadEstatistica(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.ValueObjects.StatClassificacaoVO>>(
                new Dictionary<string, string>(), bolao, "LoadEstatistica");
        }

        public IList<List<Domain.Entities.ValueObjects.StatClassificacaoVO>> LoadIndiceEstatistica(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<List<Domain.Entities.ValueObjects.StatClassificacaoVO>>>(
                new Dictionary<string, string>(), bolao, "LoadIndiceEstatistica");
        }
        #endregion

    }
}
