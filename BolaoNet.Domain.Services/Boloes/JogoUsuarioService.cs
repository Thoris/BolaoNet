using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class JogoUsuarioService :
        Base.BaseGenericService<Entities.Boloes.JogoUsuario>,
        Interfaces.Services.Boloes.IJogoUsuarioService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IJogoUsuarioDao Dao 
        {
            get { return (Interfaces.Repositories.Boloes.IJogoUsuarioDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoUsuarioService(string userName, Interfaces.Repositories.Boloes.IJogoUsuarioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.JogoUsuario>)dao, logging)
        {

        }

        #endregion

        #region IJogoUsuarioBO members

        #region Comments
        //public bool InsertAposta(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        //{
        //    Entities.Boloes.JogoUsuario entrySearch = new Entities.Boloes.JogoUsuario(
        //        user.UserName, bolao.Nome, jogo.NomeCampeonato, jogo.JogoId)
        //        {
        //            ApostaTime1 = apostaTime1,
        //            ApostaTime2 = apostaTime2,
        //            ApostaPenaltis1 = penaltis1, 
        //            ApostaPenaltis2 = penaltis2,
        //        };

        //    return true;
        //}
        //public int CalculatePontos(Entities.Interfaces.Services.IPontosJogosUsuarioEntity pontosJogo, int [] values)
        //{

        //    if (pontosJogo != null)
        //        throw new ArgumentException("pontosJogo");
        //    if (values != null)
        //        throw new ArgumentException("values");

        //    int total = 0;

        //    if (pontosJogo.IsEmpate)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Empate];
        //    if (pontosJogo.IsVitoria)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Vitoria];
        //    if (pontosJogo.IsDerrota)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Derrota];
        //    if (pontosJogo.IsGolsGanhador)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Ganhador];
        //    if (pontosJogo.IsGolsPerdedor)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Perdedor];
        //    if (pontosJogo.IsResultTime1)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time1];
        //    if (pontosJogo.IsResultTime2)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time2];
        //    if (pontosJogo.IsVDE)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.VitoriaDerrotaEmpate];
        //    if (pontosJogo.IsErro)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Erro];
        //    if (pontosJogo.IsGolsGanhadorFora)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorFora];
        //    if (pontosJogo.IsGolsGanhadorDentro)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorDentro];
        //    if (pontosJogo.IsGolsPerdedorFora)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorFora];
        //    if (pontosJogo.IsGolsPerdedorDentro)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorDentro];
        //    if (pontosJogo.IsGolsEmpate)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.EmpateGols];
        //    if (pontosJogo.IsGolsTime1)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime1];
        //    if (pontosJogo.IsGolsTime2)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime2];
        //    if (pontosJogo.IsPlacarCheio)
        //        total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio];

        //    return total;
        //}
        //public int CalculatePontos(Entities.Interfaces.Services.IPontosJogosUsuarioEntity pontosJogo, int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2)
        //{
        //    int total = 0;

        //    #region Empate
        //    //Empate
        //    if (time1 == time2)
        //    {
        //        //Se acertou o empate
        //        if (apostaTime1 == apostaTime2)
        //        {
        //            pontosJogo.IsEmpate = true;
        //            pontosJogo.IsVDE = true;

        //            if (time1 == apostaTime1)
        //            {
        //                pontosJogo.IsPlacarCheio = true;
        //                pontosJogo.IsGolsEmpate = true;                        
        //            }
        //        }
        //        else
        //        {
        //            pontosJogo.IsErro = true;
        //        }

        //    }
        //    #endregion

        //    #region Time 1

        //    //Time 1 Ganhou
        //    else if (time1 > time2)
        //    {
        //        //Se acertou a vitória
        //        if (apostaTime1 > apostaTime2)
        //        {
        //            pontosJogo.IsVitoria = true;
        //            pontosJogo.IsDerrota = true;
        //            pontosJogo.IsVDE = true;

        //            //Se acertou em cheio
        //            if (apostaTime1 == time1 && apostaTime2 == time2)
        //            {
        //                pontosJogo.IsPlacarCheio = true;
        //            }
        //            else
        //            {
        //                //Se acertou os gols do ganhador
        //                if (time1 == apostaTime1)
        //                {
        //                    pontosJogo.IsGolsGanhador = true;
        //                    pontosJogo.IsGolsGanhadorDentro = true;                            
        //                }
        //                //Se acertou os gols do perdedor
        //                if (time2 == apostaTime2)
        //                {
        //                    pontosJogo.IsGolsPerdedor = true;
        //                    pontosJogo.IsGolsPerdedorFora = true;                            
        //                }                       
        //            }//endif acertou em cheio
        //        }
        //        else
        //        {
        //            pontosJogo.IsErro = true;
        //        }
        //    }
        //    #endregion

        //    #region Time 2

        //    //Time 2 Ganhou
        //    else
        //    {
        //        //Se acertou a vitória
        //        if (apostaTime2 > apostaTime1)
        //        {
        //            pontosJogo.IsVitoria = true;
        //            pontosJogo.IsDerrota = true;
        //            pontosJogo.IsVDE = true;

        //            //Se acertou em cheio
        //            if (apostaTime1 == time1 && apostaTime2 == time2)
        //            {
        //                pontosJogo.IsPlacarCheio = true;
        //            }
        //            else
        //            {
        //                //Se acertou os gols do ganhador
        //                if (time2 == apostaTime2)
        //                {
        //                    pontosJogo.IsGolsGanhador = true;
        //                    pontosJogo.IsGolsGanhadorDentro = true;                           
        //                }
        //                //Se acertou os gols do perdedor
        //                if (time1 == apostaTime1)
        //                {
        //                    pontosJogo.IsGolsPerdedor = true;
        //                    pontosJogo.IsGolsPerdedorFora = true;                            
        //                }
        //            }//endif acertou em cheio
        //        }
        //        else
        //        {
        //            pontosJogo.IsErro = true;
        //        }
        //    }
        //    #endregion

        //    #region Gols
            
        //    if (time1 == apostaTime1)
        //    {
        //        pontosJogo.IsGolsTime1 = true;
        //    }
        //    if (time2 == apostaTime2)
        //    {
        //        pontosJogo.IsGolsTime2 = true;
        //    }

        //    #endregion

        //    return total;
        //}
        //public int CalculatePontosJogo(int[] values, IList<Entities.Boloes.BolaoCriterioPontosTimes> criteriosTimes, Entities.Interfaces.Services.IPontosJogosUsuarioEntity pontosJogo, string nomeTime1, string nomeTime2, int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2)
        //{
        //    if (values == null)
        //        throw new ArgumentException("criterios");
        //    if (criteriosTimes == null)
        //        throw new ArgumentException("criteriosTimes");
        //    if (pontosJogo == null)
        //        throw new ArgumentException("pontosJogo");
        //    if (string.IsNullOrEmpty (nomeTime1) == null)
        //        throw new ArgumentException("nomeTime1");
        //    if (string.IsNullOrEmpty(nomeTime2) == null)
        //        throw new ArgumentException("nomeTime2");
            
        //    int total = 0;

        //    CalculatePontos(pontosJogo, time1, time2, penaltis1, penaltis2, apostaTime1, apostaTime2, apostaPenaltis1, apostaPenaltis2);

        //    int doubleTime1 = 1;
        //    int doubleTime2 = 1;

        //    for (int c = 0; c < criteriosTimes.Count; c++ )
        //    {
        //        if (string.Compare (nomeTime1, criteriosTimes[c].NomeTime, true) == 0)
        //        {                    
        //            doubleTime1 = criteriosTimes[c].MultiploTime;
        //        }
        //        if (string.Compare(nomeTime2, criteriosTimes[c].NomeTime, true) == 0)
        //        {
        //            doubleTime2 = criteriosTimes[c].MultiploTime;
        //        }
        //    }

        //    int valueCalculated = CalculatePontos(pontosJogo, values);

        //    total = valueCalculated * doubleTime1 * doubleTime2;

        //    pontosJogo.MultiploTime = doubleTime1 * doubleTime2;

        //    return total;

        //}

        //public IList<Entities.Boloes.JogoUsuario> SearchJogosFromId(Entities.Campeonatos.Jogo jogo)
        //{
        //    if (jogo == null)
        //        throw new ArgumentException("jogo");
        //    if (jogo.JogoId == 0)
        //        throw new ArgumentException("jogo.JogoId");
        //    if (string.IsNullOrEmpty(jogo.NomeCampeonato))
        //        throw new ArgumentException("jogo.NomeCampeonato");


        //    IList<Entities.Boloes.JogoUsuario> list = base.GetList(x =>
        //        x.JogoId == jogo.JogoId &&
        //        string.Compare(x.NomeCampeonato, jogo.NomeCampeonato, true) == 0).ToList<Entities.Boloes.JogoUsuario>();

        //    return list;

        //}
        #endregion

        public bool ProcessAposta(Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");
            if (jogo == null)
                throw new ArgumentException("jogo");
            if (jogo.JogoId == 0)
                throw new ArgumentException("jogo.JogoId");


            return this.Dao.ProcessAposta(base.CurrentUserName, DateTime.Now, bolao, user, jogo, 
                automatico, apostaTime1, apostaTime2, penaltis1, penaltis2, ganhador);
        }
        public IList<Entities.Boloes.JogoUsuario> GetJogosByUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            return this.Dao.GetJogosByUser(this.CurrentUserName, bolao, user);
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.ValueObjects.FilterJogosVO filter)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");
            if (string.IsNullOrEmpty("bolao.NomeCampeonato"))
                throw new ArgumentException("bolao.NomeCampeonato");


            return this.Dao.GetJogosUser(this.CurrentUserName, bolao, user, filter);
        }
        public void InsertApostasAutomaticas(Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");
            if (filter == null)
                throw new ArgumentException("filter");

            this.Dao.InsertApostasAutomaticas(base.CurrentUserName, DateTime.Now, bolao, user, filter);

        }
        public IList<Entities.Boloes.JogoUsuario> GetApostasJogo(Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (jogo == null)
                throw new ArgumentException("jogo");
            if (jogo.JogoId == 0)
                throw new ArgumentException("jogo.JogoId");

            return Dao.GetApostasJogo(base.CurrentUserName, DateTime.Now, bolao, jogo);
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty (bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.LoadAcertosDificeis(base.CurrentUserName, DateTime.Now, bolao, totalMaximoAcertos);
        }
        public IList<Entities.Campeonatos.Jogo> LoadSemAcertos(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.LoadSemAcertos(base.CurrentUserName, DateTime.Now, bolao);
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(Entities.Users.User user, int totalRetorno)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            return Dao.LoadPontosObtidos(base.CurrentUserName, DateTime.Now, user, totalRetorno);
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(Entities.Users.User user, int totalRetorno)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            return Dao.LoadProximosJogosUsuario(base.CurrentUserName, DateTime.Now, user, totalRetorno);
        }
        public int CalcularPontoSimulation(int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            //int pontosTime1Total = 0;
            //int pontosTime2Total = 0;
            int pontosTotal = 0;

            int countEmpate = 0;	// Se o usuário apostou empate e o jogo deu empate
            int countVitoria = 0;	// Se o usuário apostou vitória para o time e deu vitória para o time selecionado
            int countDerrota = 0;	// Se o usuário apostou derrota para o time e deu derrota para o time selecionado
            int countGanhador = 0;	// Se acertou o time ganhador, idependente se está jogando em casa ou fora
            int countPerdedor = 0;	// Se acertou o time perdedor, idependente se está jogando em casa ou fora
            int countTime1 = 0;	// Se acertou a quantidade de gols do time 1 
            int countTime2 = 0;	// Se acertou a quantidade de gols do time 2
            int countVDE = 0;	// Se acertou se deu empate/derrota ou vitória no jogo
            int countErro = 0;	// Se errou o jogo
            int countGanhadorFora = 0;	// Se acertou que o time foi ganhador jogando fora de casa
            int countGanhadorDentro = 0;	// Se acertou que o time foi ganhador dentro de casa
            int countPerdedorFora = 0;	// Se acertou que o time foi perdedor fora de casa
            int countPerdedorDentro = 0;	// Se acertou que o time foi perdedor dentro de casa
            int countEmpateGols = 0;	// Se acertou a quantidade de gols quando ocorrer empate
            int countGolsTime1 = 0;	// Se acertou a quantidade de gols do time 1
            int countGolsTime2 = 0;	// Se acertou a quantidade de gols do time 2
            int countCheio = 0;	// Se acertou em cheio o resultado


            //-----------------------------------------
            //Parte 1: Verificando o resultado do jogo
            //-----------------------------------------


            //-----------
            //Empate
            //-----------
            if (gols1 == gols2)
            {
                if (aposta1 == aposta2)
                {
                    countEmpate = 1;
                    countVDE = 1;

                    //Se acertou o resultado do ganhador
                    if (aposta1 == gols1)
                    {
                        countGanhador = 1;
                        countTime1 = 1;
                        countEmpateGols = 1;

                        countPerdedor = 1;
                        countTime2 = 1;
                        countCheio = 1;
                    }     
                }
                else
                {
                    countErro = 1;

                }//endif aposta1 == aposta2

            }    
            //---------------
            //Time 1 Ganhador
            //---------------            
            else if (gols1 > gols2)
            {
                if (aposta1 > aposta2)
                {
                    countVitoria = 1;
                    countDerrota = 1;
                    countVDE = 1;


                    if (aposta1 == gols1 && aposta2 == gols2)
                    {
                        countCheio = 1;
                        countGanhadorDentro = 1;
                        countPerdedorFora = 1;
                    }

                    if (aposta1 == gols1)
                    {
                        countGanhador = 1;
                        countTime1 = 1;
                    }

                    if (aposta2 == gols2)
                    {
                        countPerdedor = 1;
                        countTime2 = 1;
                    }
                }
                else
                {
                    countErro = 1;
                }
            }
            //---------------
            //Time 2 Ganhador
            //--------------- 
            else if (gols1 < gols2)
            {
                if (aposta1 < aposta2)
                {
                    countVitoria = 1;
                    countDerrota = 1;
                    countVDE = 1;

                    if (aposta1 == gols1 && aposta2 == gols2)
                    {
                        countCheio = 1;
                        countGanhadorFora = 1;
                        countPerdedorDentro = 1;
                    }

                    if (aposta1 == gols1)
                    {
                        countPerdedor = 1;
                        countTime1 = 1;
                    }
                }
                else
                {
                    countErro = 1;
                }                      
            }//endif gols1 == gols2

            //--------------------------------------------------------------
            // PARTE 2 : Verificando a quantidade de gols do time casa/fora
            //--------------------------------------------------------------
            if (gols1 == aposta1)
            {
                countGolsTime1 = 1;
            }
            if (gols2 == aposta2)
            {
                countGolsTime2 = 1;
            }

            pontosTotal = countEmpate * pontosEmpate +
                countVitoria * pontosVitoria +
                countDerrota * pontosDerrota +
                countGanhador * pontosGanhador +
                countPerdedor * pontosPerdedor +
                countTime1 * pontosTime1 +
                countTime2 * pontosTime2 +
                countVDE * pontosVDE +
                countErro * pontosErro +
                countGanhadorFora * pontosGanhadorFora +
                countGanhadorDentro * pontosGanhadorDentro +
                countPerdedorFora * pontosPerdedorFora +
                countPerdedorDentro * pontosPerdedorDentro +
                countEmpateGols * pontosEmpateGols +
                countGolsTime1 * pontosGolsTime1 +
                countGolsTime2 * pontosGolsTime2 +
                countCheio * pontosCheio;

            if (isMultiploTime)
            {
                pontosTotal *= multiploTime;
            }


            return pontosTotal;
        }
        public IList<Entities.Boloes.JogoUsuario> Simulate(IList<Entities.Boloes.JogoUsuario> apostas, int gols1, int gols2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime)
        {
            if (apostas == null)
                throw new ArgumentException("apostas");

            for (int c= 0; c < apostas.Count; c++)
            {
                int pontos = CalcularPontoSimulation(gols1, gols2, (int)apostas[c].ApostaTime1, (int)apostas[c].ApostaTime2,
                    pontosEmpate, pontosVitoria, pontosDerrota, pontosGanhador, pontosPerdedor,
                    pontosTime1, pontosTime2, pontosVDE, pontosErro, pontosGanhadorFora,
                    pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro, pontosEmpateGols,
                    pontosGolsTime1, pontosGolsTime2, pontosCheio, isMultiploTime, multiploTime);

                apostas[c].Pontos = pontos;
            }

            return apostas;
        }
    
        #endregion    
    }
}
