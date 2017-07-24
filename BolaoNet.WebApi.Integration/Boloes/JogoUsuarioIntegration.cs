﻿using System;
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

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            //parameters.Add("nomebolao", bolao);
            //parameters.Add("userName", user);

            return HttpPostApi<ICollection<Domain.Entities.ValueObjects.JogoUsuarioVO>>(
                parameters, "GetJogosUser").ToList<Domain.Entities.ValueObjects.JogoUsuarioVO>();
        }

        public void InsertApostasAutomaticas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(Domain.Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadSemAcertos(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(Domain.Entities.Users.User user, int totalRetorno)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(Domain.Entities.Users.User user, int totalRetorno)
        {
            throw new NotImplementedException();
        }

        public int CalcularPontoSimulation(int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            	int PontosTime1Total		= 0;
                int PontosTime2Total = 0;
                int PontosTotal = 0;

                int CountEmpate = 0;	// Se o usuário apostou empate e o jogo deu empate
                int CountVitoria = 0;	// Se o usuário apostou vitória para o time e deu vitória para o time selecionado
                int CountDerrota = 0;	// Se o usuário apostou derrota para o time e deu derrota para o time selecionado
                int CountGanhador = 0;	// Se acertou o time ganhador, idependente se está jogando em casa ou fora
                int CountPerdedor = 0;	// Se acertou o time perdedor, idependente se está jogando em casa ou fora
                int CountTime1 = 0;	// Se acertou a quantidade de gols do time 1 
                int CountTime2 = 0;	// Se acertou a quantidade de gols do time 2
                int CountVDE = 0;	// Se acertou se deu empate/derrota ou vitória no jogo
                int CountErro = 0;	// Se errou o jogo
                int CountGanhadorFora = 0;	// Se acertou que o time foi ganhador jogando fora de casa
                int CountGanhadorDentro = 0;	// Se acertou que o time foi ganhador dentro de casa
    int CountPerdedorFora = 0;	// Se acertou que o time foi perdedor fora de casa
    int CountPerdedorDentro = 0;	// Se acertou que o time foi perdedor dentro de casa
    int CountEmpateGols = 0;	// Se acertou a quantidade de gols quando ocorrer empate
    int CountGolsTime1 = 0;	// Se acertou a quantidade de gols do time 1
    int CountGolsTime2 = 0;	// Se acertou a quantidade de gols do time 2
    int CountCheio = 0;	// Se acertou em cheio o resultado



            throw new NotImplementedException();
        }


        #endregion
    }
}
