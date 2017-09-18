using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.CopaDoMundoTests.CopaDoMundo2014Tests
{
    public class BolaoCopaMundo2014AppHelper
    {
        #region Constants

        public const string NomeBolao = "Copa do Mundo 2014";

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

        #endregion

        #region Constructors/Destructors

        public BolaoCopaMundo2014AppHelper(
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoPremioApp bolaoPremioApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosApp bolaoCriterioPontosApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp,
            Application.Interfaces.Boloes.IBolaoRegraApp bolaoRegraApp,
            Application.Interfaces.Boloes.IBolaoPontuacaoApp bolaoPontuacaoApp,
            Application.Interfaces.Boloes.IBolaoHistoricoApp bolaoHistoricoApp
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
                DataInicio = new DateTime(2014, 6, 1),
                Descricao = "Bolão da Copa do Mundo",
                Estado = "São Paulo",
                ForumAtivado = true,
                Pais = "Brasil",
                Publico = true,
                TaxaParticipacao = 20
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

            #endregion

            #region Apostas Extras

            Domain.Entities.Boloes.ApostaExtra extra1 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 1)
            {
                Titulo = "Campeão",
                TotalPontos = 15,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra1);

            Domain.Entities.Boloes.ApostaExtra extra2 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 2)
            {
                Titulo = "Vice-Campeão",
                TotalPontos = 15,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra2);

            Domain.Entities.Boloes.ApostaExtra extra3 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 3)
            {
                Titulo = "Terceiro Lugar",
                TotalPontos = 15,
            };
            StoreData<Domain.Entities.Boloes.ApostaExtra>(_apostaExtraApp, extra3);

            Domain.Entities.Boloes.ApostaExtra extra4 = new Domain.Entities.Boloes.ApostaExtra(bolao.Nome, 4)
            {
                Titulo = "Quarto Lugar",
                TotalPontos = 15,
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
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Premiação para o primeiro lugar: 70% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Premiação para o segundo lugar: 20% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Premiação para o terceiro lugar: 10% do dinheiro arrecadado" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "havendo dois primeiros lugares, 45% para cada e o próximo leva 10%; havendo empate no segundo lugar, divide-se entre eles os 30% (se dois empatarem 15% para cada)" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Se caso a aposta não foi realizado, será considerado o placar de 0x0" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "A taxa de participação do bolão será de 20 reais" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Pontuação:" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "10 PONTOS - Acertar o resultado em cheio: Ex.: Aposta 2 x 1; Resultado 2 x 1;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "5  PONTOS - Acertar o empate errando o número de gols: Ex.: Aposta 1 x 1; Resultado 2 x 2;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "4  PONTOS - Acertar vencedor e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 3 x 1;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "3  PONTOS - Acertar apenas o vencedor e errar os placares: Ex.: Aposta 2 x 1; Resultado 1 x 0;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "1  PONTO  - Errar o resultado jogo e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 0 x 1 ou 1 x 1;" });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "0  PONTO  - Para as outras situações." });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Com relação ao resultado dos 4 primeiros: Valerá apenas 15 pontos cada acerto." });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Obs.: Na medida que você vai apostando o software vai fazendo uma previsão de quem serão os classificados." });
            StoreData<Domain.Entities.Boloes.BolaoRegra>(_bolaoRegraApp, new Domain.Entities.Boloes.BolaoRegra(bolao.Nome, c++) { Descricao = "Porém, ainda que na sua aposta esteja aparecendo Brasil 2 x 1 Chile, o no jogo real seja Portugal x Chile, vale o resultado." });
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





            StoreBolaoHistorico(bolao.Nome, 2010, 1,	"Alberto",	237,	3,	36,	16,	25,	9,	30);
            StoreBolaoHistorico(bolao.Nome, 2010,2,	"Thoris",	210,	7	,36	,16	,28	,8	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,3,	"andermoura",	199	,4	,35,	14	,24	,7	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,4,	"carlinhosbueno",	199,	3	,31,	20,	23,	8,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,5,	"luizen",	199	,4	,34	,16,	26	,3,	15);
            StoreBolaoHistorico(bolao.Nome, 2010,6,	"TAQUARA"	,198	,4	,34	,12	,20,	3,	30);
            StoreBolaoHistorico(bolao.Nome, 2010,7,	"Marcio",	197,	1,	30	,19,	26,	9,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,8,	"lucas_scremin"	,197,	0,	32	,16	,23,	7,	15);
            StoreBolaoHistorico(bolao.Nome, 2010,9,	"afreita2"	,190	,4	,36	,18,	23,	5,	0);
            StoreBolaoHistorico(bolao.Nome, 2010, 10,	"julia",	189	,5	,29	,18,	25,	9,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,11,	"Sara"	,188	,4	,28	,18	,23,	8,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,12,	"lgcarvalho",	187,	4,	32	,12	,32,	5	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,13,	"Alan",	177,	1	,26	,18	,23,	8,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,14,	"Carlos",	172	,2,	28,	15	,22	,6,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,15,	"fabiop",	172	,2,	25	,21,	25,	8	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,16,	"Juninho",	172,	3	,27	,18	,22,	6,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,17,	"TAQUARA2"	,169,	5,	32	,12	,20	,3	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,18,	"AndreBarboza",	169,	4,	30	,12,	23,	4,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,19,	"helton_hls",	166	,2,	28	,20	,23,	6	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,20,	"JulioCesar"	,166,	3,	28	,12	,20	,6,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,21,	"TAQUARA3",	165	,4,	31	,13,	20	,4	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,22,	"Serrano",	162,	2	,24,	16,	27,	7,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,23,	"Betovb"	,159	,3	,25,	17,	23	,6	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,24,	"dnlima",	158	,2,	30,	16,	23,	3,	0);
            StoreBolaoHistorico(bolao.Nome, 2010,25	,"teles"	,150	,3,	26	,15,	24,	3	,0);
            StoreBolaoHistorico(bolao.Nome, 2010,26,	"tharcius",	143,	1,	26	,10	,22	,3,	0);













            StoreBolaoHistorico(bolao.Nome, 2014, 1, "wfukuda", 224, 5, 36, 23, 17, 7, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 2, "Batista", 203, 4, 28, 17, 26, 9, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 3, "anunes81", 203, 2, 27, 26, 24, 8, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 4, "Lucas", 202, 2, 34, 25, 15, 5, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 5, "lmpaiva", 201, 0, 32, 19, 22, 7, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 6, "ldporto", 199, 0, 31, 20, 26, 6, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 7, "edioneto", 193, 3, 32, 22, 17, 5, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 8, "trebelo", 193, 4, 27, 18, 18, 5, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 9, "MASKARA", 188, 1, 33, 18, 18, 7, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 10, "lfernandojac", 188, 0, 35, 19, 21, 6, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 11, "Mis", 187, 4, 25, 26, 20, 9, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 12, "tharcius", 186, 1, 28, 21, 23, 8, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 13, "dma01", 183, 4, 31, 19, 21, 4, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 14, "kelly", 182, 6, 22, 18, 20, 6, 20);
            StoreBolaoHistorico(bolao.Nome, 2014, 15, "teles", 181, 1, 29, 20, 20, 7, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 16, "carlos", 181, 2, 30, 19, 18, 6, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 17, "lg_sjc", 179, 3, 23, 20, 25, 6, 20);
            StoreBolaoHistorico(bolao.Nome, 2014, 18, "marcio_fv", 178, 3, 29, 18, 18, 4, 20);
            StoreBolaoHistorico(bolao.Nome, 2014, 19, "pauloamorim", 175, 0, 26, 20, 24, 6, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 20, "M9", 173, 1, 30, 21, 18, 4, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 21, "Beto", 172, 1, 32, 24, 13, 5, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 22, "romulosjc", 172, 2, 31, 19, 14, 3, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 23, "luizhrs", 171, 3, 28, 20, 21, 6, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 24, "Edmilson", 171, 2, 32, 10, 15, 4, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 25, "barbosaalr", 169, 1, 30, 24, 15, 4, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 26, "andinho", 169, 4, 30, 20, 12, 5, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 27, "paulo.vrs", 165, 4, 29, 16, 21, 4, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 28, "reinaldo", 164, 5, 31, 11, 14, 3, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 29, "RZ", 163, 3, 26, 15, 17, 6, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 30, "Thoris", 162, 2, 27, 23, 19, 5, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 31, "fabiops91", 162, 4, 33, 15, 20, 1, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 32, "gianluca", 160, 5, 28, 13, 18, 3, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 33, "fcarvalho", 160, 1, 28, 24, 12, 3, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 34, "Alvaro", 159, 5, 22, 21, 15, 6, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 35, "Samuel", 159, 2, 26, 18, 13, 4, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 36, "alcastro", 159, 2, 28, 18, 19, 3, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 37, "denis", 156, 1, 26, 16, 16, 4, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 38, "lise", 156, 1, 28, 12, 15, 4, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 39, "Vieira Junior", 151, 4, 26, 13, 16, 4, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 40, "palpiteiro", 151, 2, 25, 14, 21, 3, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 41, "Gustavo", 150, 0, 27, 16, 16, 3, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 42, "rafaelmcesar", 148, 2, 29, 15, 19, 2, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 43, "carlfrei", 148, 3, 28, 21, 16, 2, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 44, "Thais", 147, 0, 30, 20, 17, 1, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 45, "toninha", 146, 7, 24, 17, 7, 3, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 46, "veronbom", 145, 0, 26, 18, 15, 2, 10);
            StoreBolaoHistorico(bolao.Nome, 2014, 47, "AlbertoFlu", 131, 0, 29, 11, 17, 1, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 48, "bolacha", 113, 2, 17, 16, 15, 3, 0);
            StoreBolaoHistorico(bolao.Nome, 2014, 49, "Helio", 109, 5, 14, 16, 20, 2, 0);


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
            Domain.Entities.Boloes.Bolao bolao = new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014");

            _apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Alemanha"), 1, new Domain.Entities.Users.User("thoris"));
            _apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Argentina"), 2, new Domain.Entities.Users.User("thoris"));
            _apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Holanda"), 3, new Domain.Entities.Users.User("thoris"));
            _apostaExtraApp.InsertResult(bolao, new Domain.Entities.DadosBasicos.Time("Brasil"), 4, new Domain.Entities.Users.User("thoris"));


            return true;
        }
        public bool StartBolao(Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            return _bolaoApp.Iniciar(iniciadoBy, bolao);

        }
        //public bool StoreData<T>(Application.Base.IGenericApp<T> app, T data)
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
