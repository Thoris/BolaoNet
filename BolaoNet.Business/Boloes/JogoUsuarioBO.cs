using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class JogoUsuarioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.JogoUsuario>,
        Interfaces.Boloes.IJogoUsuarioBO
    {
        #region Constructors/Destructors

        public JogoUsuarioBO(string userName, Dao.Boloes.IJogoUsuarioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.JogoUsuario>)dao)
        {

        }

        #endregion

        #region IJogoUsuarioBO members
        
        public bool InsertAposta(Entities.Campeonatos.Jogo jogo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        {
            throw new NotImplementedException();
        }
        public bool InsertAposta(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        {
            throw new NotImplementedException();
        }
        public IList<Entities.Boloes.JogoUsuario> SearchJogoByDependenciaId(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo)
        {
            throw new NotImplementedException();
        }
        public bool IsGrupoAlreadyApostasDone(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            throw new NotImplementedException();
        }
        public int CalculatePontos(Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, int [] values)
        {

            if (pontosJogo != null)
                throw new ArgumentException("pontosJogo");
            if (values != null)
                throw new ArgumentException("values");

            int total = 0;

            if (pontosJogo.IsEmpate)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Empate];
            if (pontosJogo.IsVitoria)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Vitoria];
            if (pontosJogo.IsDerrota)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Derrota];
            if (pontosJogo.IsGolsGanhador)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Ganhador];
            if (pontosJogo.IsGolsPerdedor)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Perdedor];
            if (pontosJogo.IsResultTime1)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time1];
            if (pontosJogo.IsResultTime2)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time2];
            if (pontosJogo.IsVDE)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.VitoriaDerrotaEmpate];
            if (pontosJogo.IsErro)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Erro];
            if (pontosJogo.IsGolsGanhadorFora)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorFora];
            if (pontosJogo.IsGolsGanhadorDentro)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorDentro];
            if (pontosJogo.IsGolsPerdedorFora)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorFora];
            if (pontosJogo.IsGolsPerdedorDentro)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorDentro];
            if (pontosJogo.IsGolsEmpate)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.EmpateGols];
            if (pontosJogo.IsGolsTime1)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime1];
            if (pontosJogo.IsGolsTime2)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime2];
            if (pontosJogo.IsPlacarCheio)
                total += values[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio];

            return total;
        }
        public int CalculatePontos(Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2)
        {
            int total = 0;

            #region Empate
            //Empate
            if (time1 == time2)
            {
                //Se acertou o empate
                if (apostaTime1 == apostaTime2)
                {
                    pontosJogo.IsEmpate = true;
                    pontosJogo.IsVDE = true;

                    if (time1 == apostaTime1)
                    {
                        pontosJogo.IsPlacarCheio = true;
                        pontosJogo.IsGolsEmpate = true;                        
                    }
                }
                else
                {
                    pontosJogo.IsErro = true;
                }

            }
            #endregion

            #region Time 1

            //Time 1 Ganhou
            else if (time1 > time2)
            {
                //Se acertou a vitória
                if (apostaTime1 > apostaTime2)
                {
                    pontosJogo.IsVitoria = true;
                    pontosJogo.IsDerrota = true;
                    pontosJogo.IsVDE = true;

                    //Se acertou em cheio
                    if (apostaTime1 == time1 && apostaTime2 == time2)
                    {
                        pontosJogo.IsPlacarCheio = true;
                    }
                    else
                    {
                        //Se acertou os gols do ganhador
                        if (time1 == apostaTime1)
                        {
                            pontosJogo.IsGolsGanhador = true;
                            pontosJogo.IsGolsGanhadorDentro = true;                            
                        }
                        //Se acertou os gols do perdedor
                        if (time2 == apostaTime2)
                        {
                            pontosJogo.IsGolsPerdedor = true;
                            pontosJogo.IsGolsPerdedorFora = true;                            
                        }                       
                    }//endif acertou em cheio
                }
                else
                {
                    pontosJogo.IsErro = true;
                }
            }
            #endregion

            #region Time 2

            //Time 2 Ganhou
            else
            {
                //Se acertou a vitória
                if (apostaTime2 > apostaTime1)
                {
                    pontosJogo.IsVitoria = true;
                    pontosJogo.IsDerrota = true;
                    pontosJogo.IsVDE = true;

                    //Se acertou em cheio
                    if (apostaTime1 == time1 && apostaTime2 == time2)
                    {
                        pontosJogo.IsPlacarCheio = true;
                    }
                    else
                    {
                        //Se acertou os gols do ganhador
                        if (time2 == apostaTime2)
                        {
                            pontosJogo.IsGolsGanhador = true;
                            pontosJogo.IsGolsGanhadorDentro = true;                           
                        }
                        //Se acertou os gols do perdedor
                        if (time1 == apostaTime1)
                        {
                            pontosJogo.IsGolsPerdedor = true;
                            pontosJogo.IsGolsPerdedorFora = true;                            
                        }
                    }//endif acertou em cheio
                }
                else
                {
                    pontosJogo.IsErro = true;
                }
            }
            #endregion

            #region Gols
            
            if (time1 == apostaTime1)
            {
                pontosJogo.IsGolsTime1 = true;
            }
            if (time2 == apostaTime2)
            {
                pontosJogo.IsGolsTime2 = true;
            }

            #endregion

            return total;
        }
        public int CalculatePontosJogo(int[] values, IList<Entities.Boloes.BolaoCriterioPontosTimes> criteriosTimes, Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, string nomeTime1, string nomeTime2, int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2)
        {
            if (values == null)
                throw new ArgumentException("criterios");
            if (criteriosTimes == null)
                throw new ArgumentException("criteriosTimes");
            if (pontosJogo == null)
                throw new ArgumentException("pontosJogo");
            if (string.IsNullOrEmpty (nomeTime1) == null)
                throw new ArgumentException("nomeTime1");
            if (string.IsNullOrEmpty(nomeTime2) == null)
                throw new ArgumentException("nomeTime2");
            
            int total = 0;

            CalculatePontos(pontosJogo, time1, time2, penaltis1, penaltis2, apostaTime1, apostaTime2, apostaPenaltis1, apostaPenaltis2);

            int doubleTime1 = 1;
            int doubleTime2 = 1;

            for (int c = 0; c < criteriosTimes.Count; c++ )
            {
                if (string.Compare (nomeTime1, criteriosTimes[c].NomeTime, true) == 0)
                {                    
                    doubleTime1 = criteriosTimes[c].MultiploTime;
                }
                if (string.Compare(nomeTime2, criteriosTimes[c].NomeTime, true) == 0)
                {
                    doubleTime2 = criteriosTimes[c].MultiploTime;
                }
            }

            int valueCalculated = CalculatePontos(pontosJogo, values);

            total = valueCalculated * doubleTime1 * doubleTime2;

            pontosJogo.MultiploTime = doubleTime1 * doubleTime2;

            return total;

        }

        public IList<Entities.Boloes.JogoUsuario> SearchJogosFromId(Entities.Campeonatos.Jogo jogo)
        {
            if (jogo == null)
                throw new ArgumentException("jogo");
            if (jogo.JogoId == 0)
                throw new ArgumentException("jogo.JogoId");
            if (string.IsNullOrEmpty(jogo.NomeCampeonato))
                throw new ArgumentException("jogo.NomeCampeonato");


            IList<Entities.Boloes.JogoUsuario> list = base.GetList(x =>
                x.JogoId == jogo.JogoId &&
                string.Compare(x.NomeCampeonato, jogo.NomeCampeonato, true) == 0).ToList<Entities.Boloes.JogoUsuario>();

            return list;

        }

        public bool UpdatePontuacao(Entities.Boloes.JogoUsuario jogoUsuario)
        {
            throw new NotImplementedException();
        }

        #endregion









    }
}
