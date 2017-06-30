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

        #endregion



    }
}
