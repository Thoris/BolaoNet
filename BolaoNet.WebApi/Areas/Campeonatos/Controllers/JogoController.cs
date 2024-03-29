﻿using BolaoNet.Domain.Entities.Campeonatos;
using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class JogoController:
        GenericApiController<Domain.Entities.Campeonatos.Jogo>,
        Domain.Interfaces.Services.Campeonatos.IJogoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.IJogoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.IJogoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public JogoController()
        //    : base(new Domain.Services.FactoryService(null).CreateJogoService())
        //{

        //}
        public JogoController(Domain.Interfaces.Services.Campeonatos.IJogoService service)
            : base(service)
        {

        }

        #endregion

        #region IJogoBO members

        [HttpPost]
        public bool InsertResult(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Jogo jogo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Jogo>(data[0].ToString());
            int gols1 = JsonConvert.DeserializeObject<int>(data[1].ToString());

            int ? penaltis1 = null;
            if (data[2] != null)
                penaltis1 = JsonConvert.DeserializeObject<int ?>(data[2].ToString());
            int gols2 = JsonConvert.DeserializeObject<int>(data[3].ToString());
            
            int ? penaltis2 = null;
            if (data[4] != null)
                penaltis2 = JsonConvert.DeserializeObject<int?>(data[4].ToString());

            bool setCurrentData = false;

            if (data[5] != null)
                setCurrentData = bool.Parse(data[5].ToString());
            
            Domain.Entities.Users.User validadoBy = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[6].ToString());
            

            return this.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }
        [HttpPost]
        public bool InsertResult(Domain.Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Domain.Entities.Users.User validadoBy)
        {
            return Service.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetJogosByCampeonato(campeonato);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int id, ArrayList data)
        {
            int rodada = JsonConvert.DeserializeObject<int>(data[0].ToString());
            DateTime dataInicial = JsonConvert.DeserializeObject<DateTime>(data[1].ToString());
            DateTime dataFinal = JsonConvert.DeserializeObject<DateTime>(data[2].ToString());
            Domain.Entities.Campeonatos.CampeonatoFase fase = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoFase>(data[3].ToString());
            Domain.Entities.Campeonatos.Campeonato campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[4].ToString());
            Domain.Entities.Campeonatos.CampeonatoGrupo grupo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.CampeonatoGrupo>(data[5].ToString());
            string condition = JsonConvert.DeserializeObject<string>(data[6].ToString());


            return this.LoadJogos(rodada, dataInicial, dataFinal, fase, campeonato, grupo, condition);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            return Service.LoadJogos(rodada, dataInicial, dataFinal, fase, campeonato, grupo, condition);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            int totalJogos = JsonConvert.DeserializeObject<int>(data[1].ToString());

            return this.LoadFinishedJogos(campeonato, totalJogos);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            return Service.LoadFinishedJogos(campeonato, totalJogos);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            int totalJogos = JsonConvert.DeserializeObject<int>(data[1].ToString());

            return this.LoadNextJogos(campeonato, totalJogos);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            return Service.LoadNextJogos(campeonato, totalJogos);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogos(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato;
            Domain.Entities.ValueObjects.FilterJogosVO filter;


             campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
             filter = JsonConvert.DeserializeObject<Domain.Entities.ValueObjects.FilterJogosVO>(data[1].ToString());


            return Service.GetJogos(campeonato, filter);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogos(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            return Service.GetJogos(campeonato, filter);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> SelectGoleadas(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato;
            int maxGols;

            campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            maxGols = JsonConvert.DeserializeObject<int>(data[1].ToString());


            return Service.SelectGoleadas(campeonato, maxGols);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> SelectGoleadas(Domain.Entities.Campeonatos.Campeonato campeonato, int maxGols)
        {
            return Service.SelectGoleadas(campeonato, maxGols);
        }
        [HttpPost]
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosTimesPossibilidades(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetJogosTimesPossibilidades(campeonato);
        }
        [HttpGet]
        public Jogo GetLastValidJogo(Campeonato campeonato)
        {
            return Service.GetLastValidJogo(campeonato);
        }

        #endregion
    }
}