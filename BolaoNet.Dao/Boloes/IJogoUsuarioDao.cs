using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IJogoUsuarioDao
    {
        
        bool ProcessAposta(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, 
            Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, 
            int? penaltis1, int? penaltis2, int? ganhador);

        bool AddAposta(string currentUserName, Entities.Boloes.JogoUsuario jogoUsuario);

        bool UpdateAposta(string currentUserName, Entities.Boloes.JogoUsuario jogoUsuario);

        bool CalculeTime(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, 
            Entities.DadosBasicos.Time time, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);

        bool CalculeDependencia(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, 
            Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, 
            int apostaTime1, int apostaTime2, int ? penaltis1, int ? penaltis2);

        bool CalculeFinal(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, 
            Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, 
            int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2);

        bool CalculeGrupo(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, 
            Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);

        bool Validacao(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Jogo jogo,
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, int rodada,
            Entities.DadosBasicos.Time time1, Entities.DadosBasicos.Time time2, int gols1, int gols2, int? penaltis1, int? penaltis2,
            Entities.Users.User validadoBy);

        Entities.Interfaces.IPontosJogosUsuarioEntity CalculePontos(string currentUserName, DateTime currentDateTime, int gols1, int gols2, int aposta1, int aposta2,
            int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2,
            int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro,
            int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime,
            Entities.Interfaces.IPontosJogosUsuarioEntity pontosEntity);

    }
}
