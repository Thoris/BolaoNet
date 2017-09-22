﻿using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class JogoUsuarioController:
        GenericApiController<Domain.Entities.Boloes.JogoUsuario>, 
        Domain.Interfaces.Services.Boloes.IJogoUsuarioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IJogoUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IJogoUsuarioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public JogoUsuarioController()
        //    : base(new Domain.Services.FactoryService(null).CreateJogoUsuarioService())
        //{

        //}
        public JogoUsuarioController(Domain.Interfaces.Services.Boloes.IJogoUsuarioService service)
            : base(service)
        {

        }

        #endregion

        #region IJogoUsuarioBO members

        [HttpPost]
        public bool ProcessAposta(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            Domain.Entities.Users.User user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());
            Domain.Entities.Campeonatos.Jogo jogo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Jogo>(data[2].ToString());
            int automatico = JsonConvert.DeserializeObject<int>(data[3].ToString());
            int apostaTime1 = JsonConvert.DeserializeObject<int>(data[4].ToString());
            int apostaTime2 = JsonConvert.DeserializeObject<int>(data[5].ToString());
            int ? penaltis1 = JsonConvert.DeserializeObject<int>(data[6].ToString());
            int ? penaltis2 = JsonConvert.DeserializeObject<int>(data[7].ToString());
            int ? ganhador = JsonConvert.DeserializeObject<int>(data[8].ToString());

            return this.ProcessAposta(bolao, user, jogo, automatico, apostaTime1, apostaTime2, penaltis1, penaltis2, ganhador);
        
        }
        [HttpPost]
        public bool ProcessAposta(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            return Service.ProcessAposta(bolao, user, jogo, automatico, apostaTime1, apostaTime2, penaltis1, penaltis2, ganhador);
        }

        [HttpPost]
        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogoByUser(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            Domain.Entities.Users.User user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());

            return this.GetJogosByUser(bolao, user);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetJogosByUser(bolao, user);
        }
        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            return Service.GetJogosUser(bolao, user, filter);
        }
        [HttpPost]
        public void InsertApostasAutomaticas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {
            Service.InsertApostasAutomaticas(bolao, user, filter);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Jogo jogo)
        {
            return Service.GetApostasJogo(bolao, jogo);
        }
        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(Domain.Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            return Service.LoadAcertosDificeis(bolao, totalMaximoAcertos);
        }

        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadSemAcertos(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.LoadSemAcertos(bolao);
        }
        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(Domain.Entities.Users.User user, int totalRetorno)
        {
            return Service.LoadPontosObtidos(user, totalRetorno);
        }
        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(int id, ArrayList data)
        {
            Domain.Entities.Users.User user = null;
            int totalRetorno = 0;

            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[0].ToString());
            totalRetorno = JsonConvert.DeserializeObject<int>(data[1].ToString());

            return Service.LoadPontosObtidos(user, totalRetorno);
        }

        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(Domain.Entities.Users.User user, int totalRetorno)
        {
            return Service.LoadProximosJogosUsuario(user, totalRetorno);
        }
        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(int id, ArrayList data)
        {
            Domain.Entities.Users.User user = null;
            int totalRetorno = 0;

            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[0].ToString());
            totalRetorno  = JsonConvert.DeserializeObject<int>(data[1].ToString());


            return Service.LoadProximosJogosUsuario(user, totalRetorno);
        }

        [HttpPost]
        public int CalcularPontoSimulation(int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            return Service.CalcularPontoSimulation(gols1, gols2, aposta1, aposta2, pontosEmpate, pontosVitoria,
               pontosDerrota, pontosGanhador, pontosPerdedor, pontosTime1, pontosTime2, pontosVDE,
               pontosErro, pontosGanhadorFora, pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro,
               pontosEmpateGols, pontosGolsTime1, pontosGolsTime2, pontosCheio, isMultiploTime, multiploTime);
       
        }

        [HttpPost]
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