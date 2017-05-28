using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.TestsVS.Business.Facade
{
    public class BolaoCopaMundo2014FacadeBO 
    {
        #region Variables

        private BolaoNet.Business.Interfaces.Boloes.IApostaExtraBO _apostaExtraBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoBO _bolaoBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoPremioBO _bolaoPremioBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoCriterioPontosBO _bolaoCriterioPontosBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO _bolaoCriterioPontosTimesBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoRegraBO _bolaoRegraBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoPontuacaoBO _bolaoPontuacaoBO;

        #endregion

        #region Constructors/Destructors

        public BolaoCopaMundo2014FacadeBO(BolaoNet.Business.Interfaces.IFactoryBO factory)
        {
            _apostaExtraBO = factory.CreateApostaExtraBO();
            _bolaoBO = factory.CreateBolaoBO();
            _bolaoPremioBO = factory.CreateBolaoPremioBO();
            _bolaoCriterioPontosBO = factory.CreateBolaoCriterioPontosBO();
            _bolaoRegraBO = factory.CreateBolaoRegraBO ();
            _bolaoPontuacaoBO = factory.CreateBolaoPontuacaoBO();
            _bolaoCriterioPontosTimesBO = factory.CreateBolaoCriterioPontosTimesBO();
        }

        #endregion

        #region Methods

        public Entities.Boloes.Bolao CreateBolao(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            #region Bolao

            Entities.Boloes.Bolao bolao = new Entities.Boloes.Bolao("Copa do Mundo 2014")
            {
                NomeCampeonato = campeonato.Nome,
                ApostasApenasAntes = true,
                Cidade = "São José dos Campos",
                DataInicio = new DateTime(2014, 6, 1),
                Descricao = "Bolão da Copa do Mundo",
                Estado = "São Paulo",
                ForumAtivado = true,
                Pais = "Brasil",
                Publico = true,
                TaxaParticipacao = 20
            };

            StoreData<Entities.Boloes.Bolao>(_bolaoBO, bolao);

            #endregion

            #region Bolao Premios

            Entities.Boloes.BolaoPremio premio1 = new Entities.Boloes.BolaoPremio(bolao.Nome, 1)
            {
                Titulo = "Campeão",
                BackColorName = "Green",
                ForeColorName = "White",                 
            };
            StoreData<Entities.Boloes.BolaoPremio>(_bolaoPremioBO, premio1);

            Entities.Boloes.BolaoPremio premio2 = new Entities.Boloes.BolaoPremio(bolao.Nome, 2)
            {
                Titulo = "Vice-Campeão",
                BackColorName = "Yellow",
                ForeColorName = "White",
            };
            StoreData<Entities.Boloes.BolaoPremio>(_bolaoPremioBO, premio2);

            Entities.Boloes.BolaoPremio premio3 = new Entities.Boloes.BolaoPremio(bolao.Nome, 3)
            {
                Titulo = "Terceiro",
                BackColorName = "Blue",
                ForeColorName = "Black",
            };
            StoreData<Entities.Boloes.BolaoPremio>(_bolaoPremioBO, premio3);

            #endregion

            #region Apostas Extras

            Entities.Boloes.ApostaExtra extra1 = new Entities.Boloes.ApostaExtra(bolao.Nome, 1)
            {
                Titulo = "Campeão",
                TotalPontos = 15,
            };
            StoreData<Entities.Boloes.ApostaExtra>(_apostaExtraBO, extra1);

            Entities.Boloes.ApostaExtra extra2 = new Entities.Boloes.ApostaExtra(bolao.Nome, 2)
            {
                Titulo = "Vice-Campeão",
                TotalPontos = 15,
            };
            StoreData<Entities.Boloes.ApostaExtra>(_apostaExtraBO, extra2);

            Entities.Boloes.ApostaExtra extra3 = new Entities.Boloes.ApostaExtra(bolao.Nome, 3)
            {
                Titulo = "Terceiro Lugar",
                TotalPontos = 15,
            };
            StoreData<Entities.Boloes.ApostaExtra>(_apostaExtraBO, extra3);

            Entities.Boloes.ApostaExtra extra4 = new Entities.Boloes.ApostaExtra(bolao.Nome, 4)
            {
                Titulo = "Quarto Lugar",
                TotalPontos = 15,
            };
            StoreData<Entities.Boloes.ApostaExtra>(_apostaExtraBO, extra4);

            #endregion

            #region Boloes Criterios Pontos

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)1) { Pontos = 2 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)2) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)3) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)4) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)5) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)6) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)7) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)8) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)9) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)10) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)11) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)12) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)13) { Pontos = 0 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)14) { Pontos = -2 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)15) { Pontos = 1 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)16) { Pontos = 1 });

            StoreData<Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosBO,
                new Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Entities.Boloes.BolaoCriterioPontos.CriteriosID)17) { Pontos = 5 });

            #endregion

            #region Bolao criterio pontos times

            StoreData<Entities.Boloes.BolaoCriterioPontosTimes>(_bolaoCriterioPontosTimesBO,
                new Entities.Boloes.BolaoCriterioPontosTimes(bolao.Nome, "Brasil") { MultiploTime = 2, });

            #endregion

            #region Bolao Regras

            int c = 1;
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Premiação para o primeiro lugar: 70% do dinheiro arrecadado"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Premiação para o segundo lugar: 20% do dinheiro arrecadado"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Premiação para o terceiro lugar: 10% do dinheiro arrecadado"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "havendo dois primeiros lugares, 45% para cada e o próximo leva 10%; havendo empate no segundo lugar, divide-se entre eles os 30% (se dois empatarem 15% para cada)"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Se caso a aposta não foi realizado, será considerado o placar de 0x0"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "A taxa de participação do bolão será de 20 reais"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Pontuação:"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "10 PONTOS - Acertar o resultado em cheio: Ex.: Aposta 2 x 1; Resultado 2 x 1;"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "5  PONTOS - Acertar o empate errando o número de gols: Ex.: Aposta 1 x 1; Resultado 2 x 2;"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "4  PONTOS - Acertar vencedor e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 3 x 1;"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "3  PONTOS - Acertar apenas o vencedor e errar os placares: Ex.: Aposta 2 x 1; Resultado 1 x 0;"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "1  PONTO  - Errar o resultado jogo e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 0 x 1 ou 1 x 1;"});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "0  PONTO  - Para as outras situações."});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Com relação ao resultado dos 4 primeiros: Valerá apenas 15 pontos cada acerto."});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Obs.: Na medida que você vai apostando o software vai fazendo uma previsão de quem serão os classificados."});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++)
                {Descricao = "Porém, ainda que na sua aposta esteja aparecendo Brasil 2 x 1 Chile, o no jogo real seja Portugal x Chile, vale o resultado."});
            StoreData<Entities.Boloes.BolaoRegra>(_bolaoRegraBO, new Entities.Boloes.BolaoRegra(bolao.Nome, c++) 
                { Descricao = "Ou seja, você estará apostando no primeiro classificado do grupo A x Segundo classificado do grupo B, independente do time que classificar." });


            #endregion
            
            #region Boloes Pontuação

            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 0) 
                { Titulo = "Erro", ForeColorName = "White", BackColorName = "Red" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 1) 
                { Titulo = "Gols", ForeColorName = "Black", BackColorName = "Cyan" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 2) 
                { Titulo = "Gols - Brasil", ForeColorName = "Black", BackColorName = "Cyan" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 3) 
                { Titulo = "Vencedor", ForeColorName = "Gray", BackColorName = "Cyan" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 4)
                { Titulo = "Vencedor + Gols", ForeColorName = "Blue", BackColorName = "Blue" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 5) 
                { Titulo = "Empate", ForeColorName = "Black", BackColorName = "Yellow" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 6)
                { Titulo = "Vencedor - Brasil", ForeColorName = "Black", BackColorName = "Gray" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 8) 
                { Titulo = "Venc+Gols+Br", ForeColorName = "Black", BackColorName = "Blue" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 10) 
                { Titulo = "Cheio", ForeColorName = "Green", BackColorName = "Green" });
            StoreData<Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoBO, new Entities.Boloes.BolaoPontuacao(bolao.Nome, 20) 
                { Titulo = "Cheio - Brasil", ForeColorName = "White", BackColorName = "Green" });
            
            #endregion

            return bolao;
        }
        public bool InsertFinalResult()
        {
            Entities.Boloes.Bolao bolao = new Entities.Boloes.Bolao("Copa do Mundo 2014");

            _apostaExtraBO.InsertResult(bolao, new Entities.DadosBasicos.Time("Alemanha"), 1, new Entities.Users.User("thoris"));
            _apostaExtraBO.InsertResult(bolao, new Entities.DadosBasicos.Time("Argentina"), 2, new Entities.Users.User("thoris"));
            _apostaExtraBO.InsertResult(bolao, new Entities.DadosBasicos.Time("Holanda"), 3, new Entities.Users.User("thoris"));
            _apostaExtraBO.InsertResult(bolao, new Entities.DadosBasicos.Time("Brasil"), 4, new Entities.Users.User("thoris"));


            return true;
        }
        public bool StartBolao(Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao)
        {
            return _bolaoBO.Iniciar(iniciadoBy, bolao);
            
        }

        public bool StoreData<T>(BolaoNet.Business.Base.IGenericBusiness<T> bo, T data)
        {
            T loaded = bo.Load(data);

            if (loaded == null)
            {
                long total = bo.Insert(data);

                if (total > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }


        #endregion
    }
}
