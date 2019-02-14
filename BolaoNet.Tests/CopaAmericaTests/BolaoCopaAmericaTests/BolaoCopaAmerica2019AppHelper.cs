using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.CopaAmericaTests.BolaoCopaAmericaTests
{
    public class BolaoCopaAmerica2019AppHelper
    {
        #region Constants

        public const string NomeBolao = "Copa América 2019";

        #endregion

        #region Variables

        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoPremioApp _bolaoPremioApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosApp _bolaoCriterioPontosApp;
        private Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp _bolaoCriterioPontosTimesApp;
        private Application.Interfaces.Boloes.IBolaoRegraApp _bolaoRegraApp;
        private Application.Interfaces.Boloes.IBolaoPontuacaoApp _bolaoPontuacaoApp;
        private Application.Interfaces.Boloes.IBolaoHistoricoApp _bolaoHistoricoApp;
        private Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;

        #endregion

        #region Constructors/Destructors

        public BolaoCopaAmerica2019AppHelper(
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoPremioApp bolaoPremioApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosApp bolaoCriterioPontosApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp,
            Application.Interfaces.Boloes.IBolaoRegraApp bolaoRegraApp,
            Application.Interfaces.Boloes.IBolaoPontuacaoApp bolaoPontuacaoApp,
            Application.Interfaces.Boloes.IBolaoHistoricoApp bolaoHistoricoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp
        )
        {
            _apostaExtraApp = apostaExtraApp;
            _bolaoApp = bolaoApp;
            _bolaoPremioApp = bolaoPremioApp;
            _bolaoCriterioPontosApp = bolaoCriterioPontosApp;
            _bolaoCriterioPontosTimesApp = bolaoCriterioPontosTimesApp;
            _bolaoRegraApp = bolaoRegraApp;
            _bolaoPontuacaoApp = bolaoPontuacaoApp;
            _bolaoHistoricoApp = bolaoHistoricoApp;
            _bolaoMembroApp = bolaoMembroApp;
        }

        #endregion

        #region Methods

        public Domain.Entities.Boloes.Bolao CreateBolao(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            #region Bolao

            Domain.Entities.Boloes.Bolao bolao = new Domain.Entities.Boloes.Bolao(NomeBolao)
            {
                NomeCampeonato = campeonato.Nome,
                ApostasApenasAntes = true,
                Cidade = "São José dos Campos",
                DataInicio = new DateTime(2019, 6, 1),
                Descricao = "Bolão da Copa América",
                Estado = "São Paulo",
                ForumAtivado = true,
                Pais = "Brasil",
                Publico = true,
                TaxaParticipacao = 10,
                IsIniciado = false,
            };

            StoreData<Domain.Entities.Boloes.Bolao>(_bolaoApp, bolao);

            #endregion

            #region Bolao Premios

            Domain.Entities.Boloes.BolaoPremio premio1 = new Domain.Entities.Boloes.BolaoPremio(bolao.Nome, 1)
            {
                Titulo = "Campeão",
                BackColorName = "Green",
                ForeColorName = "White",
            };
            StoreData<Domain.Entities.Boloes.BolaoPremio>(_bolaoPremioApp, premio1);

            Domain.Entities.Boloes.BolaoPremio premio2 = new Domain.Entities.Boloes.BolaoPremio(bolao.Nome, 2)
            {
                Titulo = "Vice-Campeão",
                BackColorName = "Yellow",
                ForeColorName = "White",
            };
            StoreData<Domain.Entities.Boloes.BolaoPremio>(_bolaoPremioApp, premio2);

            Domain.Entities.Boloes.BolaoPremio premio3 = new Domain.Entities.Boloes.BolaoPremio(bolao.Nome, 3)
            {
                Titulo = "Terceiro",
                BackColorName = "Blue",
                ForeColorName = "Black",
            };
            StoreData<Domain.Entities.Boloes.BolaoPremio>(_bolaoPremioApp, premio3);

            Domain.Entities.Boloes.BolaoPremio premio4 = new Domain.Entities.Boloes.BolaoPremio(bolao.Nome, 100)
            {
                Titulo = "Último",
                BackColorName = "Black",
                ForeColorName = "White",
            };
            StoreData<Domain.Entities.Boloes.BolaoPremio>(_bolaoPremioApp, premio4);

            #endregion

            #region Apostas Extras

            Domain.Entities.Boloes.ApostaExtra extra1 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 1)
            {
                Titulo = "Campeão",
                TotalPontos = 10,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra1);

            Domain.Entities.Boloes.ApostaExtra extra2 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 2)
            {
                Titulo = "Vice-Campeão",
                TotalPontos = 10,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra2);

            Domain.Entities.Boloes.ApostaExtra extra3 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 3)
            {
                Titulo = "Terceiro Lugar",
                TotalPontos = 10,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra3);

            Domain.Entities.Boloes.ApostaExtra extra4 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 4)
            {
                Titulo = "Quarto Lugar",
                TotalPontos = 10,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra4);

            #endregion

            #region Boloes Criterios Pontos

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)1) { Pontos = 2, Descricao = "Pontos por empate" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)2) { Pontos = 0, Descricao = "Pontos por vitória do time" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)3) { Pontos = 0, Descricao = "Pontos por derrota do time" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)4) { Pontos = 0, Descricao = "Acerto do time ganhador" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)5) { Pontos = 0, Descricao = "Acerto do time perdedor" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)6) { Pontos = 0, Descricao = "Acerto de gols do time 1" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)7) { Pontos = 0, Descricao = "Acerto de gols do time 2" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)8) { Pontos = 3, Descricao = "Acerto de Vitória / Empate / Derrota" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)9) { Pontos = 0, Descricao = "Pontos de erro do jogo" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)10) { Pontos = 0, Descricao = "Acerto dos gols do ganhador fora" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)11) { Pontos = 0, Descricao = "Acerto dos gols do ganhador dentro" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)12) { Pontos = 0, Descricao = "Acerto dos gols do perdedor fora" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)13) { Pontos = 0, Descricao = "Acerto dos gols do perdedor dentro" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)14) { Pontos = -2, Descricao = "Pontos de Acerto de gols de empate" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)15) { Pontos = 1, Descricao = "Acerto dos gols do time 1" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)16) { Pontos = 1, Descricao = "Acerto dos gols do time 2" });

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontos>(_bolaoCriterioPontosApp,
                new Domain.Entities.Boloes.BolaoCriterioPontos(bolao.Nome, (int)(Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)17) { Pontos = 5, Descricao = "Acerto em cheio" });

            #endregion

            #region Bolao criterio pontos times

            StoreData<Domain.Entities.Boloes.BolaoCriterioPontosTimes>(_bolaoCriterioPontosTimesApp,
                new Domain.Entities.Boloes.BolaoCriterioPontosTimes(bolao.Nome, "Brasil") { MultiploTime = 2, });

            #endregion

            #region Bolao Regras

            int c = 1;
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Premiação:" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * Premiação para o primeiro lugar: 70% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * Premiação para o segundo lugar: 20% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * Premiação para o terceiro lugar: 9% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * Premiação para o último lugar: 1% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   Obs.: Havendo dois primeiros lugares, 45% para cada e o próximo leva 9%; havendo empate no segundo lugar, divide-se entre eles os 29% (se dois empatarem, 14,5% para cada)" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Se caso a aposta não foi realizada, será considerado o placar de 0x0" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "A taxa de participação do bolão será de 50,00 reais" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Pontuação:" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * 10 PONTOS - Acertar o resultado em cheio: Ex.: Aposta 2 x 1; Resultado 2 x 1;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * 5  PONTOS - Acertar o empate errando o número de gols: Ex.: Aposta 1 x 1; Resultado 2 x 2;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * 4  PONTOS - Acertar vencedor e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 3 x 1;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * 3  PONTOS - Acertar apenas o vencedor e errar os placares: Ex.: Aposta 2 x 1; Resultado 1 x 0;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * 1  PONTO  - Errar o resultado jogo e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 0 x 1 ou 1 x 1;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "   * 0  PONTO  - Para as outras situações." });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Jogos do Brasil valem o dobro, seguindo a pontuação de 20, 10, 8, 6 e 2 pontos, respectivamente. Se acertar em cheio o resultado, ao invés de obter 10 pontos, será aplicado 20 pontos." });            
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Com relação ao resultado dos 4 primeiros: Valerá apenas 10 pontos cada acerto." });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Obs.: Na medida que você vai apostando o software vai fazendo uma previsão de quem serão os classificados." });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Porém, ainda que na sua aposta esteja aparecendo Brasil 2 x 1 Chile, o no jogo real seja Portugal x Chile, vale o resultado. " });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Na fase eliminatória, vale o dobro de pontos apenas para o jogo real e não pelo cruzamento da aposta. " });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Ou seja, você estará apostando no primeiro classificado do grupo A x Segundo classificado do grupo B, independente do time que classificar." });
            

            #endregion

            #region Boloes Pontuação

            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 0) { Titulo = "Erro", ForeColorName = "White", BackColorName = "Red" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 1) { Titulo = "Gols", ForeColorName = "Black", BackColorName = "Cyan" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 2) { Titulo = "Gols - Brasil", ForeColorName = "Black", BackColorName = "Cyan" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 3) { Titulo = "Vencedor", ForeColorName = "Gray", BackColorName = "Cyan" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 4) { Titulo = "Vencedor + Gols", ForeColorName = "Blue", BackColorName = "Blue" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 5) { Titulo = "Empate", ForeColorName = "Black", BackColorName = "Yellow" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 6) { Titulo = "Vencedor - Brasil", ForeColorName = "Black", BackColorName = "Gray" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 8) { Titulo = "Venc+Gols+Br", ForeColorName = "Black", BackColorName = "Blue" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 10) { Titulo = "Cheio", ForeColorName = "Green", BackColorName = "Green" });
            StoreData<Domain.Entities.Boloes.BolaoPontuacao>(_bolaoPontuacaoApp, new Domain.Entities.Boloes.BolaoPontuacao(bolao.Nome, 20) { Titulo = "Cheio - Brasil", ForeColorName = "White", BackColorName = "Green" });

            #endregion

            #region Boloes Histórico

             

            #endregion

            #region Usuários do Bolão

            StoreData<Domain.Entities.Boloes.BolaoMembro>(_bolaoMembroApp, new Domain.Entities.Boloes.BolaoMembro("admin", NomeBolao));
            

            #endregion

            return bolao;
        }
        private void StoreBolaoHistorico(string nomeBolao, int ano, int posicao, string userName, int totalPontos, int totalEmpates, int totalVDE, int totalGols1, int totalGols2, int totalCheio, int totalExtra )
        {
            StoreData<Domain.Entities.Boloes.BolaoHistorico>(_bolaoHistoricoApp, new Domain.Entities.Boloes.BolaoHistorico(nomeBolao, ano, posicao)
            {
                UserName = userName,
                Pontos = totalPontos,
                TotalEmpates = totalEmpates,
                TotalVDE = totalVDE,
                TotalGolsTime1 = totalGols1,
                TotalGolsTime2 = totalGols2,
                TotalCheio = totalCheio,
                TotalExtras = totalExtra
            });
        }
        public bool InsertFinalResult()
        {
            Domain.Entities.Boloes.Bolao bolao = new Domain.Entities.Boloes.Bolao("Copa do Mundo 2018");

            //_apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Alemanha"), 1, new Domain.Entities.Users.User("thoris"));
            //_apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Argentina"), 2, new Domain.Entities.Users.User("thoris"));
            //_apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Holanda"), 3, new Domain.Entities.Users.User("thoris"));
            //_apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Brasil"), 4, new Domain.Entities.Users.User("thoris"));
             
            

            return true;
             
        }
        public bool StartBolao(Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            return _bolaoApp.Iniciar(iniciadoBy, bolao);

        }
        public bool StoreData<T>(Domain.Interfaces.Services.Base.IGenericService<T> app, T data)
        {
            T loaded = app.Load(data);

            if (loaded == null)
            {
                long total = app.Insert(data);

                if (total > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool ClearApostasMembros()
        {
            return true;
        }

        #endregion
    }
}
