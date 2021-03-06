﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IJogoUsuarioDao
    {
        IList<Entities.Boloes.JogoUsuario> GetJogosByUser(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user);

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

        //Entities.Interfaces.IPontosJogosUsuarioEntity CalculePontos(string currentUserName, DateTime currentDateTime, int gols1, int gols2, int aposta1, int aposta2,
        //    int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2,
        //    int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro,
        //    int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime,
        //    Entities.Interfaces.IPontosJogosUsuarioEntity pontosEntity);

        int CalcularPontos(string currentUserName, DateTime currentDatetime, int gols1, int gols2, int aposta1, int aposta2,
            string nomeTime1, string nomeTime2, string nomeTime1Aposta, string nomeTime2Aposta,
	        int pontosEmpate,
	        int pontosVitoria,
	        int pontosDerrota,
	        int pontosGanhador,
	        int pontosPerdedor,
	        int pontosTime1,
	        int pontosTime2,
	        int pontosVDE,
	        int pontosErro,
	        int pontosGanhadorFora,
	        int pontosGanhadorDentro,
	        int pontosPerdedorFora,
	        int pontosPerdedorDentro,
	        int pontosEmpateGols,
	        int pontosGolsTime1,
	        int pontosGolsTime2,
	        int pontosCheio,
            int pontosAcertoTime,
	
	
	        bool isMultiploTime,
	        int multiploTime,
	
	        out int pontosTime1Total,
	        out int pontosTime2Total,
	        out int pontosTotal,
		
	        out bool countEmpate,
	        out bool countVitoria,
	        out bool countDerrota,
	        out bool countGanhador,
	        out bool countPerdedor,
	        out bool countTime1,
	        out bool countTime2,
	        out bool countVDE,
	        out bool countErro,
	        out bool countGanhadorFora,
	        out bool countGanhadorDentro,
	        out bool countPerdedorFora,
	        out bool countPerdedorDentro,
	        out bool countEmpateGols,
	        out bool countGolsTime1,
	        out bool countGolsTime2,
	        out bool countCheio,
            out int countPontosAcertoTime,
	
	
            out int errorNumber,
            out string errorDescription
            );


        IList<Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user,
            Entities.ValueObjects.FilterJogosVO filter);


        void InsertApostasAutomaticas(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, 
            Entities.ValueObjects.ApostasAutomaticasFilterVO filter);

        IList<Entities.Boloes.JogoUsuario> GetApostasJogo(string currentUserName, DateTime currentDateTime, 
            Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo);

        IList<Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(string currentUserName, DateTime currentDateTime,
            Entities.Boloes.Bolao bolao, int totalMaximoAcertos);

        IList<Entities.Campeonatos.Jogo> LoadSemAcertos(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);


        IList<Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(string currentUserName, DateTime currentDateTime, Entities.Users.User user, int totalRetorno);

        IList<Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(string currentUserName, DateTime currentDateTime, Entities.Users.User user, int totalRetorno);

        bool CorrecaoEliminatorias(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user);


        IList<Entities.ValueObjects.StatClassificacaoVO> LoadEstatistica(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao);
        
    }
}
