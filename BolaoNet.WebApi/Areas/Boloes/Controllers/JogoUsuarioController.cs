using BolaoNet.Services.Controllers;
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
            int? penaltis1 = null;
            if (data[6] != null)
                penaltis1 = JsonConvert.DeserializeObject<int>(data[6].ToString());
            int? penaltis2 = null;
            if (data[7] != null)
                penaltis2 = JsonConvert.DeserializeObject<int>(data[7].ToString());

            int? ganhador = null;
            if (data[8] != null)
                ganhador = JsonConvert.DeserializeObject<int>(data[8].ToString());

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
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            Domain.Entities.Users.User user;
            Domain.Entities.ValueObjects.FilterJogosVO filter;

            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());
            filter = JsonConvert.DeserializeObject<Domain.Entities.ValueObjects.FilterJogosVO>(data[2].ToString());


            return Service.GetJogosUser(bolao, user, filter);
        }        
        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            return Service.GetJogosUser(bolao, user, filter);
        }

        [HttpPost]
        public void InsertApostasAutomaticas(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            Domain.Entities.Users.User user;
            Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter;

            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());
            filter = JsonConvert.DeserializeObject<Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO>(data[2].ToString());

            Service.InsertApostasAutomaticas(bolao, user, filter);
        }
        
        [HttpPost]
        public void InsertApostasAutomaticas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {
            Service.InsertApostasAutomaticas(bolao, user, filter);
        }

        [HttpPost]
        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            Domain.Entities.Campeonatos.Jogo jogo;

            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            jogo = JsonConvert.DeserializeObject<Domain.Entities.Campeonatos.Jogo>(data[1].ToString());
            

            return Service.GetApostasJogo(bolao, jogo);
        }        
        [HttpPost]
        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Jogo jogo)
        {
            return Service.GetApostasJogo(bolao, jogo);
        }

        [HttpPost]
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            int totalMaximoAcertos;

            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            totalMaximoAcertos = JsonConvert.DeserializeObject<int>(data[1].ToString());
            

            return Service.LoadAcertosDificeis(bolao, totalMaximoAcertos);
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
        public int CalcularPontoSimulation(int id, ArrayList data)
        {
            int gols1 = JsonConvert.DeserializeObject<int>(data[0].ToString()); ;
            int gols2 = JsonConvert.DeserializeObject<int>(data[1].ToString());
            int aposta1 = JsonConvert.DeserializeObject<int>(data[2].ToString());
            int aposta2 = JsonConvert.DeserializeObject<int>(data[3].ToString());
            int pontosEmpate = JsonConvert.DeserializeObject<int>(data[4].ToString());
            int pontosVitoria = JsonConvert.DeserializeObject<int>(data[5].ToString());
            int pontosDerrota = JsonConvert.DeserializeObject<int>(data[6].ToString());
            int pontosGanhador = JsonConvert.DeserializeObject<int>(data[7].ToString());
            int pontosPerdedor = JsonConvert.DeserializeObject<int>(data[8].ToString());
            int pontosTime1 = JsonConvert.DeserializeObject<int>(data[9].ToString());
            int pontosTime2 = JsonConvert.DeserializeObject<int>(data[10].ToString());
            int pontosVDE = JsonConvert.DeserializeObject<int>(data[11].ToString());
            int pontosErro = JsonConvert.DeserializeObject<int>(data[12].ToString());
            int pontosGanhadorFora = JsonConvert.DeserializeObject<int>(data[13].ToString());
            int pontosGanhadorDentro = JsonConvert.DeserializeObject<int>(data[14].ToString());
            int pontosPerdedorFora = JsonConvert.DeserializeObject<int>(data[15].ToString());
            int pontosPerdedorDentro = JsonConvert.DeserializeObject<int>(data[16].ToString());
            int pontosEmpateGols = JsonConvert.DeserializeObject<int>(data[17].ToString());
            int pontosGolsTime1 = JsonConvert.DeserializeObject<int>(data[18].ToString());
            int pontosGolsTime2 = JsonConvert.DeserializeObject<int>(data[19].ToString());
            int pontosCheio = JsonConvert.DeserializeObject<int>(data[20].ToString());
            bool isMultiploTime = bool.Parse(data[21].ToString());
            int multiploTime = JsonConvert.DeserializeObject<int>(data[22].ToString());


            return Service.CalcularPontoSimulation(gols1, gols2, aposta1, aposta2, pontosEmpate, pontosVitoria,
               pontosDerrota, pontosGanhador, pontosPerdedor, pontosTime1, pontosTime2, pontosVDE,
               pontosErro, pontosGanhadorFora, pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro,
               pontosEmpateGols, pontosGolsTime1, pontosGolsTime2, pontosCheio, isMultiploTime, multiploTime);

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
        public IList<Domain.Entities.Boloes.JogoUsuario> Simulate(int id, ArrayList data )
        {
            IList<Domain.Entities.Boloes.JogoUsuario> apostas = JsonConvert.DeserializeObject<IList<Domain.Entities.Boloes.JogoUsuario>>(data[0].ToString()); ;
            int gols1 = JsonConvert.DeserializeObject<int>(data[1].ToString()); ;
            int gols2 = JsonConvert.DeserializeObject<int>(data[2].ToString());
            
            int pontosEmpate = JsonConvert.DeserializeObject<int>(data[3].ToString());
            int pontosVitoria = JsonConvert.DeserializeObject<int>(data[4].ToString());
            int pontosDerrota = JsonConvert.DeserializeObject<int>(data[5].ToString());
            int pontosGanhador = JsonConvert.DeserializeObject<int>(data[6].ToString());
            int pontosPerdedor = JsonConvert.DeserializeObject<int>(data[7].ToString());
            int pontosTime1 = JsonConvert.DeserializeObject<int>(data[8].ToString());
            int pontosTime2 = JsonConvert.DeserializeObject<int>(data[9].ToString());
            int pontosVDE = JsonConvert.DeserializeObject<int>(data[10].ToString());
            int pontosErro = JsonConvert.DeserializeObject<int>(data[11].ToString());
            int pontosGanhadorFora = JsonConvert.DeserializeObject<int>(data[12].ToString());
            int pontosGanhadorDentro = JsonConvert.DeserializeObject<int>(data[13].ToString());
            int pontosPerdedorFora = JsonConvert.DeserializeObject<int>(data[14].ToString());
            int pontosPerdedorDentro = JsonConvert.DeserializeObject<int>(data[15].ToString());
            int pontosEmpateGols = JsonConvert.DeserializeObject<int>(data[16].ToString());
            int pontosGolsTime1 = JsonConvert.DeserializeObject<int>(data[17].ToString());
            int pontosGolsTime2 = JsonConvert.DeserializeObject<int>(data[18].ToString());
            int pontosCheio = JsonConvert.DeserializeObject<int>(data[19].ToString());
            bool isMultiploTime = bool.Parse(data[20].ToString());
            int multiploTime = JsonConvert.DeserializeObject<int>(data[21].ToString());



            return Service.Simulate(apostas, gols1, gols2, pontosEmpate, pontosVitoria,
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