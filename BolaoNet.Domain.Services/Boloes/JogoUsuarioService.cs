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


            if (IsSaveLog)
                CheckStart();

            bool res = this.Dao.ProcessAposta(base.CurrentUserName, DateTime.Now, bolao, user, jogo, 
                automatico, apostaTime1, apostaTime2, penaltis1, penaltis2, ganhador);


            if (IsSaveLog)
            {
                if (res)
                    _logging.Info(this, GetMessageTotalTime("Resultado do bolão: [" + bolao.Nome + "] do usuário [" + user.UserName + "] jogo [" + jogo.JogoId + "] [" +  apostaTime1 + "x" + apostaTime2 + "] : " + res));
                else
                    _logging.Warn(this, GetMessageTotalTime("Resultado do bolão: [" + bolao.Nome + "] do usuário [" + user.UserName + "] jogo [" + jogo.JogoId + "] [" + apostaTime1 + "x" + apostaTime2 + "] : " + res));                       
            }

            return res;
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


            if (IsSaveLog)
                CheckStart();

            IList < Entities.Boloes.JogoUsuario > res = this.Dao.GetJogosByUser(this.CurrentUserName, bolao, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de jogos por usuário do bolão : [" + bolao.Nome + "] do usuário [" + user.UserName + "] total : " + res.Count));
            }

            return res;
        
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


            if (IsSaveLog)
                CheckStart();

            IList < Entities.ValueObjects.JogoUsuarioVO > res = this.Dao.GetJogosUser(this.CurrentUserName, bolao, user, filter);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de jogos por usuário do bolão : [" + bolao.Nome + "] do usuário [" + user.UserName + "] total : " + res.Count));
            }

            return res;
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


            if (IsSaveLog)
                CheckStart();

            this.Dao.InsertApostasAutomaticas(base.CurrentUserName, DateTime.Now, bolao, user, filter);

            if (IsSaveLog)
            {
                _logging.Info(this, GetMessageTotalTime("Inclusão de apostas automáticas do bolão : [" + bolao.Nome + "] do usuário [" + user.UserName + "] " ));
            }

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


            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.JogoUsuario> res =  Dao.GetApostasJogo(base.CurrentUserName, DateTime.Now, bolao, jogo);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de apostas do jogo [" + jogo.JogoId + "] do bolão : [" + bolao.Nome + "] Total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty (bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.JogoUsuarioVO> res = Dao.LoadAcertosDificeis(base.CurrentUserName, DateTime.Now, bolao, totalMaximoAcertos);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de acertos difíceis do bolão [" + bolao.Nome + "] com máximo [" +  totalMaximoAcertos + "] total: " + res.Count));
            }


            return res;
        }
        public IList<Entities.Campeonatos.Jogo> LoadSemAcertos(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res =  Dao.LoadSemAcertos(base.CurrentUserName, DateTime.Now, bolao);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de jogos sem acertos do bolão [" + bolao.Nome + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(Entities.Users.User user, int totalRetorno)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.JogoUsuarioVO> res = Dao.LoadPontosObtidos(base.CurrentUserName, DateTime.Now, user, totalRetorno);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de pontos obtidos do usuário [" + user.UserName + "] com totalRetorno [" + totalRetorno + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(Entities.Users.User user, int totalRetorno)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.JogoUsuarioVO> res = Dao.LoadProximosJogosUsuario(base.CurrentUserName, DateTime.Now, user, totalRetorno);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de próximos jogos do usuário [" + user.UserName + "] com totalRetorno [" + totalRetorno + "] total: " + res.Count));
            }

            return res;
        }
        public int CalcularPontoSimulation(int gols1, int gols2, int aposta1, int aposta2, string nomeTime1, string nomeTime2, string nomeTime1Aposta, string nomeTime2Aposta, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, int pontosAcertoTime, bool isMultiploTime, int multiploTime)
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
            int countPontosAcertoTime = 0;

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

            if (!string.IsNullOrEmpty(nomeTime1Aposta))
            {
                if (string.Compare(nomeTime1.Trim(), nomeTime1Aposta.Trim()) == 0)
                {
                    countPontosAcertoTime++;
                }
            }

            if (!string.IsNullOrEmpty(nomeTime2Aposta))
            {
                if (string.Compare(nomeTime2.Trim(), nomeTime2Aposta.Trim()) == 0)
                {
                    countPontosAcertoTime++;
                }
            }

            int totalPontosAcertoTime = (pontosAcertoTime * countPontosAcertoTime);

            pontosTotal += totalPontosAcertoTime;

            return pontosTotal;
        }
        public IList<Entities.Boloes.JogoUsuario> Simulate(IList<Entities.Boloes.JogoUsuario> apostas, int gols1, int gols2, string nomeTime1, string nomeTime2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, int pontosAcertoTime, bool isMultiploTime, int multiploTime)
        {
            if (apostas == null)
                throw new ArgumentException("apostas");

            for (int c= 0; c < apostas.Count; c++)
            {
                int pontos = CalcularPontoSimulation(gols1, gols2, (int)apostas[c].ApostaTime1, (int)apostas[c].ApostaTime2,
                    nomeTime1, nomeTime2, apostas[c].NomeTimeResult1, apostas[c].NomeTimeResult2,
                    pontosEmpate, pontosVitoria, pontosDerrota, pontosGanhador, pontosPerdedor,
                    pontosTime1, pontosTime2, pontosVDE, pontosErro, pontosGanhadorFora,
                    pontosGanhadorDentro, pontosPerdedorFora, pontosPerdedorDentro, pontosEmpateGols,
                    pontosGolsTime1, pontosGolsTime2, pontosCheio, pontosAcertoTime, isMultiploTime, multiploTime);

                apostas[c].Pontos = pontos;
            }

            return apostas;
        }
        public bool CorrecaoEliminatorias(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            if (IsSaveLog)
                CheckStart();

            bool res = this.Dao.CorrecaoEliminatorias(base.CurrentUserName, DateTime.Now, bolao, user);


            if (IsSaveLog)
            {
                if (res)
                    _logging.Info(this, GetMessageTotalTime("Correção de eliminatórias: [" + bolao.Nome + "] do usuário [" + user.UserName + "] :" + res));
                else
                    _logging.Warn(this, GetMessageTotalTime("Correção de eliminatórias: [" + bolao.Nome + "] do usuário [" + user.UserName + "] :" + res));
            }

            return res;
        }
        public IList<Entities.ValueObjects.StatClassificacaoVO> LoadEstatistica(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.StatClassificacaoVO> res = Dao.LoadEstatistica(base.CurrentUserName, DateTime.Now, bolao);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de pontuação dos jogos para estatística [" + bolao.Nome + "] total: " + res.Count));
            }

            return res;
        }
        public IList<List<Entities.ValueObjects.StatClassificacaoVO>> LoadIndiceEstatistica(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            IList<List<Entities.ValueObjects.StatClassificacaoVO>> res = new List<List<Entities.ValueObjects.StatClassificacaoVO>>();
            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.StatClassificacaoVO> list = Dao.LoadEstatistica(base.CurrentUserName, DateTime.Now, bolao);

            List<Entities.ValueObjects.StatClassificacaoVO> acumulativo = new List<Entities.ValueObjects.StatClassificacaoVO>();

            List<Entities.ValueObjects.StatClassificacaoVO> current = new List<Entities.ValueObjects.StatClassificacaoVO>();

            bool inicio = true;
            int currentJogoId = -1;
            int currentUserName = -1;
            for (int c = 0; c < list.Count; c++)
            {
                if (list[c].JogoId != currentJogoId)
                { 
                    if (current.Count > 0)
                    {
                        OrganizarList(current);
                        res.Add(current);
                        inicio = false;
                    }
                    current = new List<Entities.ValueObjects.StatClassificacaoVO>();
                    currentJogoId = list[c].JogoId;
                    currentUserName = 0;
                }

                Entities.ValueObjects.StatClassificacaoVO entry = new Entities.ValueObjects.StatClassificacaoVO()
                {
                    UserName = list[c].UserName,
                    Pontos = list[c].Pontos
                };

                if (!inicio)
                {
                    entry.Pontos += acumulativo[currentUserName].Pontos;
                    acumulativo[currentUserName].Pontos += list[c].Pontos;
                }
                else
                {
                    acumulativo.Add(new Entities.ValueObjects.StatClassificacaoVO() { UserName = list[c].UserName, Pontos = list[c].Pontos });
                }
                current.Add(entry);

                currentUserName++;

            }

            if (current.Count > 0 )
            {
                OrganizarList(current);
                res.Add(current);
            }

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de índice de estatística [" + bolao.Nome + "] total: " + res.Count));
            }

            return res;
        }
        #endregion    
    
        #region Methods

        private void OrganizarList(List<Entities.ValueObjects.StatClassificacaoVO> list)
        {
            List<Entities.ValueObjects.StatClassificacaoVO> org = list.OrderByDescending(x => x.Pontos).ToList();

            int currentPontos = -1;
            int currentPosicao = 0;
            int countPosicao = 0;
            for (int c=0; c< org.Count; c++)
            {
                countPosicao++;
                if (org[c].Pontos != currentPontos)
                {
                    currentPontos = org[c].Pontos;
                    currentPosicao = countPosicao;
                    org[c].Posicao = currentPosicao;
                }
                else
                {
                    org[c].Posicao = currentPosicao;
                }
            }

            list = org.OrderBy( x => x.UserName).ToList();

        }

        #endregion
    }
}
