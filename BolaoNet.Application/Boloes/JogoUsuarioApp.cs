using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class JogoUsuarioApp :
        Base.GenericApp<Domain.Entities.Boloes.JogoUsuario>,
        Application.Interfaces.Boloes.IJogoUsuarioApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IJogoUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IJogoUsuarioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoUsuarioApp" />.
        /// </summary>
        public JogoUsuarioApp(Domain.Interfaces.Services.Boloes.IJogoUsuarioService service)
            : base (service)
        {

        }

        #endregion

        #region IJogoUsuarioService members

        public bool ProcessAposta(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            return Service.ProcessAposta(bolao, user, jogo, automatico, apostaTime1, apostaTime2, penaltis1, penaltis2, ganhador);
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetJogosByUser(bolao, user);
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            return Service.GetJogosUser(bolao, user, filter);
       
        }
        public void InsertApostasAutomaticas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {
            Service.InsertApostasAutomaticas(bolao, user, filter);
        }
        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Jogo jogo)
        {
            return Service.GetApostasJogo(bolao, jogo);
        }
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(Domain.Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            return Service.LoadAcertosDificeis(bolao, totalMaximoAcertos);
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadSemAcertos(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.LoadSemAcertos(bolao);
        }
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(Domain.Entities.Users.User user, int totalRetorno)
        {
            return Service.LoadPontosObtidos(user, totalRetorno);
        }

        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(Domain.Entities.Users.User user, int totalRetorno)
        {
            return Service.LoadProximosJogosUsuario(user, totalRetorno);
        }

        public int CalcularPontoSimulation(int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            return Service.CalcularPontoSimulation(gols1, gols2, aposta1, aposta2, pontosEmpate, pontosVitoria,
                pontosDerrota, pontosGanhador, pontosPerdedor, pontosTime1, pontosTime2, pontosVDE,
                pontosErro, pontosGanhadorFora, pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro,
                pontosEmpateGols, pontosGolsTime1, pontosGolsTime2, pontosCheio, isMultiploTime, multiploTime);
        }
        public IList<Domain.Entities.Boloes.JogoUsuario> Simulate(IList<Domain.Entities.Boloes.JogoUsuario> apostas, int gols1, int gols2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            return Service.Simulate(apostas, gols1, gols2, pontosEmpate, pontosVitoria,
                pontosDerrota, pontosGanhador, pontosPerdedor, pontosTime1, pontosTime2, pontosVDE,
                pontosErro, pontosGanhadorFora, pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro,
                pontosEmpateGols, pontosGolsTime1, pontosGolsTime2, pontosCheio, isMultiploTime, multiploTime);
        }

        #endregion


    }
}
