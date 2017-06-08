using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Facade
{
    public class CampeonatoFacadeService 
        : Interfaces.Services.Facade.ICampeonatoFacadeService
    {
        #region Variables

        private string _userName;
        private Interfaces.Services.Campeonatos.IJogoService _jogoBO;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuarioBO;
        private Interfaces.Services.Boloes.IBolaoCriterioPontosService _bolaoCriterioPontosBO;
        private Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService _bolaoCriterioPontosTimesBO;
        

        #endregion

        #region Constructors/Destructors

        public CampeonatoFacadeService(string userName, Interfaces.Services.IFactoryService factory)
        {
            _userName = userName;
            _jogoBO = factory.CreateJogoService();
            _jogoUsuarioBO = factory.CreateJogoUsuarioService();
            _bolaoCriterioPontosBO = factory.CreateBolaoCriterioPontosService();
            _bolaoCriterioPontosTimesBO = factory.CreateBolaoCriterioPontosTimesService();

        }

        #endregion

        #region Methods

        private int GetPosNomeBolao(string nomeBolao, IList<string> list)
        {
            for (int c = 0;  c < list.Count; c++)
            {
                if (string.Compare (nomeBolao, list[c], true) == 0)
                {
                    return c;
                }
            }

            return - 1;
        }

        #endregion

        #region ICampeonatoFacadeBO members

        //public IList<Entities.Campeonatos.Jogo> InsertJogo(Entities.Campeonatos.Jogo jogo)
        //{
        //    if (jogo == null)
        //        throw new ArgumentException("jogo");
            

        //    IList<string> nomeBoloes = new List<string>();
        //    IList<int[]> pontuacao = new List<int[]>();
        //    IList<IList<Entities.Boloes.BolaoCriterioPontosTimes>> criterios = new List<IList<Entities.Boloes.BolaoCriterioPontosTimes>>();

        //    //Buscando todos os jogos dos usuários
        //    IList<Entities.Boloes.JogoUsuario> jogos = _jogoUsuarioBO.SearchJogosFromId(jogo);

        //    if (jogos != null)
        //    {
        //        //Verificando todos os jogos dos usuários
        //        for (int c = 0; c < jogos.Count; c++)
        //        {
        //            //Verificando se a pontuação já foi carregada
        //            string nomeBolao = jogos[c].NomeBolao;
        //            int pos = GetPosNomeBolao(nomeBolao, nomeBoloes);
        //            if (pos == -1)
        //            {
        //                Entities.Boloes.Bolao bolao = new Entities.Boloes.Bolao(nomeBolao);
        //                int[] values = _bolaoCriterioPontosBO.GetCriteriosPontos(bolao);
        //                pontuacao.Add(values);
        //                IList<Entities.Boloes.BolaoCriterioPontosTimes> criterioBolao = _bolaoCriterioPontosTimesBO.GetCriterioPontosBolao(bolao);
        //                criterios.Add(criterioBolao);
        //                nomeBoloes.Add(nomeBolao);
        //                pos = nomeBoloes.Count - 1;

        //            }//endif pos == -1

        //            int total = _jogoUsuarioBO.CalculatePontosJogo(pontuacao[pos], criterios[pos], jogos[c],
        //                jogo.NomeTime1, jogo.NomeTime2, jogo.GolsTime1, jogo.GolsTime2, jogo.PenaltisTime1, jogo.PenaltisTime2,
        //                jogos[c].ApostaTime1, jogos[c].ApostaTime2, jogos[c].ApostaPenaltis1, jogos[c].ApostaPenaltis2);

        //            jogos[c].Pontos = total;
        //            jogos[c].Valido = true;
                    
        //            //Atualizando pontuação do usuário
        //            _jogoUsuarioBO.UpdatePontuacao(jogos[c]);



        //        }//end for c

        //    }//endif jogos != null



        //    return null;
            
        //}

        #endregion
    }
}
