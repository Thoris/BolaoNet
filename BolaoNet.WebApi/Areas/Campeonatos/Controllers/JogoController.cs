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

        public bool InsertResult(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Jogo jogo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Jogo>(data[0].ToString());
            int gols1 = JsonConvert.DeserializeObject<int>(data[1].ToString());
            int ? penaltis1 = JsonConvert.DeserializeObject<int ?>(data[2].ToString());
            int gols2 = JsonConvert.DeserializeObject<int>(data[3].ToString());
            int ? penaltis2 = JsonConvert.DeserializeObject<int?>(data[4].ToString());
            bool setCurrentData = JsonConvert.DeserializeObject<bool>(data[5].ToString());
            Domain.Entities.Users.User validadoBy = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[6].ToString());
            

            return this.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }
        public bool InsertResult(Domain.Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Domain.Entities.Users.User validadoBy)
        {
            return Service.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }
        
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetJogosByCampeonato(campeonato);
        }
        
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
        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            return Service.LoadJogos(rodada, dataInicial, dataFinal, fase, campeonato, grupo, condition);
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            int totalJogos = JsonConvert.DeserializeObject<int>(data[1].ToString());

            return this.LoadFinishedJogos(campeonato, totalJogos);
        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            return Service.LoadFinishedJogos(campeonato, totalJogos);
        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(int id, ArrayList data)
        {
            Domain.Entities.Campeonatos.Campeonato campeonato = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Campeonato>(data[0].ToString());
            int totalJogos = JsonConvert.DeserializeObject<int>(data[1].ToString());

            return this.LoadNextJogos(campeonato, totalJogos);
        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            return Service.LoadNextJogos(campeonato, totalJogos);
        }

        #endregion
    }
}