﻿//#define DEBUG_EXTRACTION

using BolaoNet.Application.Interfaces.Boloes;
using BolaoNet.Application.Interfaces.Campeonatos;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    /// <summary>
    /// Classe responsável por efetuar o cálculo estatístico.
    /// </summary>
    public class Execute
    {
        #region Constants

        /// <summary>
        /// Constante que define a quantidade de gols que nunca pode ocorrer.
        /// </summary>
        private const short GolsSemApostaMaior = 999;
        /// <summary>
        /// Constante que define a quantidade de gols que nunca pode ocorrer.
        /// </summary>
        private const short GolsSemApostaMenor = 888;
        private const string NomeTimeDesconhecido = "Desconhecido";

        #endregion

        #region Variables

        private BolaoNet.Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private BolaoNet.Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoCriterioPontosApp _bolaoCriterioPontosApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp _bolaoCriterioPontosTimesApp;
        private BolaoNet.Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private BolaoNet.Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;

        #endregion

        #region Constructors/Destructors
        
        /// <summary>
        /// Constructor da classe.
        /// </summary>
        public Execute()
        {
            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();

            _jogoApp = kernel.Get<IJogoApp>();
            _bolaoApp = kernel.Get<IBolaoApp>();
            _jogoUsuarioApp = kernel.Get<IJogoUsuarioApp>();
            _bolaoCriterioPontosApp = kernel.Get<IBolaoCriterioPontosApp>();
            _bolaoCriterioPontosTimesApp = kernel.Get<IBolaoCriterioPontosTimesApp>();
            _apostaExtraApp = kernel.Get<IApostaExtraApp>();
            _apostaExtraUsuarioApp = kernel.Get<IApostaExtraUsuarioApp>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que executa o cálculo estatístico de verificação dos jogos.
        /// </summary>
        /// <param name="nomeBolao">Nome do bolão a ser verificado.</param>
        public void Run(string nomeBolao)
        {
            int [] pontuacao = null;
            IList<JogoInfo> list = null;
            IList<ApostaExtraInfo> extras = null;
            IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes = null;

            bool debug = false;



#if (DEBUG_EXTRACTION)
            debug = true;
#endif
            if (debug)
            {
                pontuacao = SimulateCriterioPontosBolao();
                pontosTimes = SimulateExtractPontosTimes(nomeBolao);

                list = SimulateExtractJogos(nomeBolao, 10, 4);
            }
            else
            {
                extras = ExtractApostasExtras(nomeBolao);


                pontosTimes = _bolaoCriterioPontosTimesApp.GetCriterioPontosBolao(new Domain.Entities.Boloes.Bolao(nomeBolao));
                pontuacao = _bolaoCriterioPontosApp.GetCriteriosPontos(new Domain.Entities.Boloes.Bolao(nomeBolao));

                list = ExtractJogos(nomeBolao);
            }

            DefinirPossibilidades(list);
            DefinirPossibilidades(extras);

            CalcularPontuacao(list, pontuacao, pontosTimes);
            CalcularPontuacao(extras);

            SaveLogJogos("log.log", list, extras);

        }

        /// <summary>
        /// Método que efetua o carregamento de todos os jogos e apostas do bolão.
        /// </summary>
        /// <param name="nomeBolao">Nome do bolão a serem extraídos os jogos e apostas.</param>
        /// <returns>Lista de objeto que possui dados extraídos da aposta e jogos.</returns>
        private IList<JogoInfo> ExtractJogos(string nomeBolao)
        {
            IList<JogoInfo> list = new List<JogoInfo>();

            //Buscando os dados do bolão
            Domain.Entities.Boloes.Bolao bolao = _bolaoApp.Load(new Domain.Entities.Boloes.Bolao(nomeBolao));

            //Buscando todos os jogos do bolão
            IList<Domain.Entities.Campeonatos.Jogo> jogos = 
                _jogoApp.GetJogosByCampeonato(new Domain.Entities.Campeonatos.Campeonato(bolao.NomeCampeonato));

            //Para cada jogo do campeonato
            for (int c = 0; c < jogos.Count; c++ )
            {
                //Criando o objeto para incluir na coleção
                JogoInfo info = new JogoInfo(jogos[c]);

                //Buscando as apostas do jogo
                IList<Domain.Entities.Boloes.JogoUsuario> apostas = _jogoUsuarioApp.GetApostasJogo(bolao, jogos[c]);

                //Para cada aposta encontrada
                for (int i = 0; i < apostas.Count; i++)
                {
                     info.Apostas.Add(new ApostaJogoUsuario(apostas[i]));

                }//end for i

                //Incluindo a lista de jogos encontrados do bolão especificado
                list.Add(info);

            }//end for c

            return list;
        }

        /// <summary>
        /// Método que efetua a simulação da extração de jogos do banco de dados.
        /// </summary>
        /// <param name="nomeBolao">Nome do bolão.</param>
        /// <param name="totalUsuarios">Total de usuários para incluir nas apostas.</param>
        /// <param name="maxGols">Máximo de gols permitido para cada aposta.</param>
        /// <returns>Lista de jogos.</returns>
        private IList<JogoInfo> SimulateExtractJogos(string nomeBolao, int totalUsuarios, int maxGols)
        {
            IList<JogoInfo> list = new List<JogoInfo>();

            Random rnd = new Random();

            for (int c = 0; c < 64; c++ )
            {

                JogoInfo info = new JogoInfo();
                info.JogoId = c + 1;
                

                for (int i = 0; i < totalUsuarios; i ++)
                {
                    string userName = "Usuario" + i;

                    info.Apostas.Add(new ApostaJogoUsuario()
                        {
                            ApostaTime1 = rnd.Next(0, maxGols),
                            ApostaTime2 = rnd.Next(0, maxGols),
                            UserName = userName
                        });
                }

                list.Add(info);
            }


            return list;
        }

        /// <summary>
        /// Método que efetua a simulação de extração de pontos de times.
        /// </summary>
        /// <param name="nomeBolao">Nome do bolão</param>
        /// <returns>Lista de pontos a serem utilizados no cálculo de pontos.</returns>
        private IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> SimulateExtractPontosTimes(string nomeBolao)
        {
            IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontuacaoTimes =
                new List<Domain.Entities.Boloes.BolaoCriterioPontosTimes>();

            pontuacaoTimes.Add(new Domain.Entities.Boloes.BolaoCriterioPontosTimes()
                {
                    MultiploTime = 2,
                    NomeTime = "Brasil",
                    NomeBolao = nomeBolao
                });

            return pontuacaoTimes;
        }

        /// <summary>
        /// Método que simula os critérios de pontuação.
        /// </summary>
        /// <returns>Lista de pontuação encontrada.</returns>
        private int [] SimulateCriterioPontosBolao()
        {
            int[] pontos = new int[18];
            
            pontos[1] = 2;
            pontos[8] = 3;
            pontos[14] = -2;
            pontos[15] = 1;
            pontos[16] = 1;
            pontos[17] = 5;
                

            return pontos;
        }

        /// <summary>
        /// Método que define as possibilidades de apostas para todos os jogos extraídos do banco de dados.
        /// </summary>
        /// <param name="jogos">Lista de jogos a ser definida.</param>
        private void DefinirPossibilidades(IList<JogoInfo> jogos)
        {
            for (int c=0; c < jogos.Count; c++)
            {
                IdentificarPossibilidades(jogos[c]);
            }
        }

        /// <summary>
        /// Método que faz a identificação das possibilidade de apostas de um jogo
        /// </summary>
        /// <param name="jogo">Dados do jogo a ser analisado.</param>
        private void IdentificarPossibilidades(JogoInfo jogo)
        {
            jogo.Possibilidades = new List<JogoPossibilidade>();

            //Para todas as apostas do jogo
            for (int c=0; c < jogo.Apostas.Count; c++)
            {
                //Buscando se a aposta já existe na lista
                int pos = BuscarPossibilidade(jogo.Possibilidades, jogo.Apostas[c]);

                //Se não encontrou a aposta
                if (pos == -1)
                {
                    //Inclui na lista de possibilidades
                    jogo.Possibilidades.Add(new JogoPossibilidade(jogo.Apostas[c]));
                }
                else
                {
                    //Inclui no total de apostas
                    jogo.Possibilidades[pos].TotalApostas++;

                }//end if encontrou a aposta
            }//end for apostas

            jogo.Possibilidades.Add(new JogoPossibilidade(GolsSemApostaMaior, GolsSemApostaMenor));
            jogo.Possibilidades.Add(new JogoPossibilidade(GolsSemApostaMaior, GolsSemApostaMaior));
            jogo.Possibilidades.Add(new JogoPossibilidade(GolsSemApostaMenor, GolsSemApostaMaior));
        }

        /// <summary>
        /// Método que percorre a lista de possibilidade em busca de uma aposta especifica.
        /// </summary>
        /// <param name="list">Lista de possibilidades existentes.</param>
        /// <param name="aposta">Aposta a ser pesquisada.</param>
        /// <returns>Posição da lista que a aposta foi encontrada, ou -1 caso não encontre.</returns>
        private int BuscarPossibilidade(IList<JogoPossibilidade> list, ApostaJogoUsuario aposta)
        {
            for (int c=0; c < list.Count; c++)
            {
                if (list[c].GolsTime1 == aposta.ApostaTime1 && list[c].GolsTime2 == aposta.ApostaTime2)
                {
                    return c;
                }
            }

            return -1;
        }

        /// <summary>
        /// Método que efetua o cálculo de pontos com base nas possibilidades existentes.
        /// </summary>
        /// <param name="jogos">Lista de jogos.</param>
        private void CalcularPontuacao(IList<JogoInfo> jogos, int[] pontuacao, IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes)
        {
            for (int c = 0; c < jogos.Count; c++)
            {
                CalcularPontuacao(jogos[c], pontuacao, pontosTimes);
            }
        }

        /// <summary>
        /// Método que efetua o cálculo de pontos de um jogo específico com base nas possibilidades existentes.
        /// </summary>
        /// <param name="jogo">Jogo a ser calculado.</param>
        private void CalcularPontuacao(JogoInfo jogo, int[] pontuacao, IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes)
        {
            for (int c=0; c < jogo.Possibilidades.Count; c++)
            {
                CalcularPontuacao(jogo, jogo.Possibilidades[c], pontuacao, pontosTimes);
            }
        }

        /// <summary>
        /// Método que calcula a pontuação do jogo com base na possibilidade.
        /// </summary>
        /// <param name="jogo">Dados do jogo.</param>
        /// <param name="possibilidade">possibilidade de jogo para análise.</param>
        /// <param name="pontuacao">Pontuação para cálculo.</param>
        private void CalcularPontuacao(JogoInfo jogo, JogoPossibilidade possibilidade, int[] pontuacao, IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes)
        {

            possibilidade.Pontuacao = new List<ApostaPontos>();

            for (int i = 0; i < jogo.Apostas.Count; i++)
            {
                int res = CalcularPontos(pontuacao, jogo.NomeTime1, jogo.NomeTime2,
                    possibilidade.GolsTime1, possibilidade.GolsTime2,
                    jogo.Apostas[i].ApostaTime1, jogo.Apostas[i].ApostaTime2,
                    pontosTimes);

                possibilidade.Pontuacao.Add(new ApostaPontos(jogo.Apostas[i].UserName, 
                    jogo.Apostas[i].ApostaTime1, jogo.Apostas[i].ApostaTime2)
                    {
                        Pontos = res
                    });

            }

        }

        /// <summary>
        /// Método que efetua o cálculo do pontos.
        /// </summary>
        /// <param name="pontos"></param>
        /// <param name="nomeTime1"></param>
        /// <param name="nomeTime2"></param>
        /// <param name="gols1"></param>
        /// <param name="gols2"></param>
        /// <param name="aposta1"></param>
        /// <param name="aposta2"></param>
        /// <returns></returns>
        private int CalcularPontos(int [] pontos, string nomeTime1, string nomeTime2, int gols1, int gols2, int aposta1, int aposta2, IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes)
        {
            int resultado = 0;

            #region Converter pontuacao em variáveis

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
            int multiploTime = 1;
            bool ismultiploTime = false;

            for (int c = 0; c < pontos.Length; c++)
            {
                switch ((Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID)c)
                {
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Empate:
                        countEmpate = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Vitoria:
                        countVitoria = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Derrota:
                        countDerrota = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Ganhador:
                        countGanhador = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Perdedor:
                        countPerdedor = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time1:
                        countTime1 = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Time2:
                        countTime2 = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.VitoriaDerrotaEmpate:
                        countVDE = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Erro:
                        countErro = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorFora:
                        countGanhadorFora = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GanhadorDentro:
                        countGanhadorDentro = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorFora:
                        countPerdedorFora = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.PerdedorDentro:
                        countPerdedorDentro = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.EmpateGols:
                        countEmpateGols = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime1:
                        countGolsTime1 = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.GolsTime2:
                        countGolsTime2 = pontos[c];
                        break;
                    case Domain.Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio:
                        countCheio = pontos[c];
                        break;

                }
            }
            #endregion

            for (int c = 0; c < pontosTimes.Count; c++)
            {
                if (string.Compare(pontosTimes[c].NomeTime, nomeTime1, true) == 0 ||
                    string.Compare(pontosTimes[c].NomeTime, nomeTime2, true) == 0)
                {
                    ismultiploTime = true;
                    multiploTime = pontosTimes[c].MultiploTime;
                }
            }

            resultado = _jogoUsuarioApp.CalcularPontoSimulation(gols1, gols2, aposta1, aposta2,
                countEmpate, countVitoria, countDerrota, countGanhador, countPerdedor, countTime1, countTime2,
                countVDE, countErro, countGanhadorFora, countGanhadorDentro, countPerdedorFora, countPerdedorDentro,
                countEmpateGols, countGolsTime1, countGolsTime2, countCheio, ismultiploTime, multiploTime);


            return resultado;
        }

        /// <summary>
        /// Método que efetua a extração das apostas extras dos usuários.
        /// </summary>
        /// <param name="nomeBolao"></param>
        /// <returns></returns>
        private IList<ApostaExtraInfo> ExtractApostasExtras(string nomeBolao)
        {
            IList<ApostaExtraInfo> list = new List<ApostaExtraInfo>();


            IList<Domain.Entities.Boloes.ApostaExtra> extras =
                _apostaExtraApp.GetApostasBolao(new Domain.Entities.Boloes.Bolao(nomeBolao));
            
            IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> apostas =
                   _apostaExtraUsuarioApp.GetApostasBolaoAgrupado(new Domain.Entities.Boloes.Bolao(nomeBolao));

            for (int c = 0; c < extras.Count; c++ )
            {
                ApostaExtraInfo info = new ApostaExtraInfo(extras[c]);

                for (int i = 0; i < apostas.Count; i++ )
                {
                    for (int l = 0; l < apostas[i].Count; l ++)
                    {
                        if (apostas[i][l].Posicao == info.Posicao)
                        {
                            info.Apostas.Add(new ApostaExtraAposta(apostas[i][l]));
                        }
                    }
                }

                list.Add(info);
            }

            return list;
        }

        private void DefinirPossibilidades(IList<ApostaExtraInfo> extras)
        {
            for (int c = 0; c < extras.Count; c++)
            {
                IdentificarPossibilidades(extras[c]);
            }
        }

        private void IdentificarPossibilidades(ApostaExtraInfo extra)
        {
            extra.Possibilidades = new List<ApostaExtraPossibilidade>();

            //Para todas as apostas do jogo
            for (int c = 0; c < extra.Apostas.Count; c++)
            {
                //Buscando se a aposta já existe na lista
                int pos = BuscarPossibilidade(extra.Possibilidades, extra.Apostas[c]);

                //Se não encontrou a aposta
                if (pos == -1)
                {
                    //Inclui na lista de possibilidades
                    extra.Possibilidades.Add(new ApostaExtraPossibilidade(extra.Apostas[c]));
                }
                else
                {
                    //Inclui no total de apostas
                    extra.Possibilidades[pos].TotalApostas++;

                }//end if encontrou a aposta
            }//end for apostas

            extra.Possibilidades.Add(new ApostaExtraPossibilidade() { NomeTime = NomeTimeDesconhecido, TotalApostas = 1 });
            
        }

        private int BuscarPossibilidade(IList<ApostaExtraPossibilidade> list, ApostaExtraAposta aposta)
        {
            for (int c = 0; c < list.Count; c++)
            {
                if (string.Compare (list[c].NomeTime, aposta.NomeTime, true) == 0)
                {
                    return c;
                }
            }

            return -1;
        }

        private void CalcularPontuacao(IList<ApostaExtraInfo> extras)
        {
            for (int c=0; c < extras.Count; c++)
            {
                CalcularPontuacao(extras[c]);
            }
        }

        private void CalcularPontuacao(ApostaExtraInfo extra)
        {
            for (int c=0; c < extra.Possibilidades.Count; c++)
            {
                extra.Possibilidades[c].Pontos = new List<ApostaExtraPontos>();
                for (int i = 0; i < extra.Apostas.Count; i++)
                {
                    int pontos = 0;
                    if (string.Compare(extra.Apostas[i].NomeTime, extra.Possibilidades[c].NomeTime, true) == 0)
                    {
                        pontos = extra.Pontuacao;
                    }

                    extra.Possibilidades[c].Pontos.Add(new ApostaExtraPontos()
                        {
                            NomeTime = extra.Apostas[i].NomeTime,
                            Pontos = pontos,
                            UserName = extra.Apostas[i].UserName
                        });
                }

            }
        }

        /// <summary>
        /// Método que armzena em log os resultados calculados.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="jogos"></param>
        private void SaveLogJogos(string file, IList<JogoInfo> jogos, IList<ApostaExtraInfo> extras)
        {
            StreamWriter writer = new StreamWriter(file);

            for (int c = 0; c < extras.Count; c++)
            {
                writer.WriteLine("==============================================================================");
                writer.WriteLine("Posição: " + extras[c].Posicao + " Pontuação: " + extras[c].Pontuacao);


                if (extras[c].Possibilidades != null)
                {
                    for (int i = 0; i < extras[c].Possibilidades.Count; i++)
                    {
                        writer.WriteLine("\t-------------------------------------");
                        writer.WriteLine("\t" + extras[c].Possibilidades[i].NomeTime);
                        writer.WriteLine("\t-------------------------------------");

                        for (int l = 0; l < extras[c].Possibilidades[i].Pontos.Count; l ++)
                        {
                            writer.WriteLine("\t\t" + extras[c].Possibilidades[i].Pontos[l].UserName + " : " +
                           extras[c].Possibilidades[i].Pontos[l].Pontos +
                           "\t[" + extras[c].Possibilidades[i].Pontos[l].NomeTime + "]");
                        }
                    }
                }
            }

            writer.WriteLine("*****************************************************************************");

            for (int c = 0; c < jogos.Count; c++)
            {
                writer.WriteLine("==============================================================================");
                writer.WriteLine("JOGO: " + jogos[c].JogoId + " - " + jogos[c].NomeTime1 + " x " + jogos[c].NomeTime2);

                for (int i = 0; i < jogos[c].Possibilidades.Count; i++)
                {
                    writer.WriteLine("\t-------------------------------------");
                    writer.WriteLine("\t" + jogos[c].Possibilidades[i].GolsTime1 + " x " +
                        jogos[c].Possibilidades[i].GolsTime2);
                    writer.WriteLine("\t-------------------------------------");

                    for (int l = 0; l < jogos[c].Possibilidades[i].Pontuacao.Count; l++)
                    {
                        writer.WriteLine("\t\t" + jogos[c].Possibilidades[i].Pontuacao[l].UserName + " : " +
                            jogos[c].Possibilidades[i].Pontuacao[l].Pontos +
                            "\t[" +
                            jogos[c].Possibilidades[i].Pontuacao[l].Gols1 +
                            " x " +
                            jogos[c].Possibilidades[i].Pontuacao[l].Gols2 + "]");
                    }
                }
            }

            writer.Close();
        }

        #endregion
    }
}