using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IJogoUsuarioService
        : Base.IGenericService<Entities.Boloes.JogoUsuario>
    {
        //bool InsertAposta(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, 
        //    int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2);

        //IList<Entities.Boloes.JogoUsuario> SearchJogoByDependenciaId(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo);

        //bool IsGrupoAlreadyApostasDone(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.CampeonatoGrupo grupo);

        //int CalculatePontos(Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, int time1, int time2, int? penaltis1, int? penaltis2, 
        //    int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2);

        //int CalculatePontosJogo(int[] values, IList<Entities.Boloes.BolaoCriterioPontosTimes> criteriosTimes, 
        //    Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, string nomeTime1, string nomeTime2, 
        //    int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2);

        //int CalculatePontos(Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, int[] values);

        //IList<Entities.Boloes.JogoUsuario> SearchJogosFromId(Entities.Campeonatos.Jogo jogo);

        //bool UpdatePontuacao(Entities.Boloes.JogoUsuario jogoUsuario);


        bool ProcessAposta(Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, 
            int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador);

        IList<Entities.Boloes.JogoUsuario> GetJogosByUser(Entities.Boloes.Bolao bolao, Entities.Users.User user);

        IList<Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Entities.Boloes.Bolao bolao, Entities.Users.User user, 
            DateTime ? dataInicial, DateTime ? dataFim, int ? rodada, string nomeTime, string nomeGrupo, string nomeFase);
    
    }
}
