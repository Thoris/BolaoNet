﻿//#define IGNORE_CALCULO_PONTOS //Já foi feito por outra máquina, depois, comentar
//#define DEBUG_SEMIFINAL
//#define DEBUG_EXTRACTION
//#define DEBUG_FAST_POSSIBILIDADES
//#define DEBUG_ELIMINATORIAS
//#define DEBUG_USUARIO

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
        private const short GolsSemApostaNegativa = -777;
        public const string NomeTimeDesconhecido = "Desconhecido";

        #endregion

        #region Variables

        private BolaoNet.Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private BolaoNet.Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoCriterioPontosApp _bolaoCriterioPontosApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp _bolaoCriterioPontosTimesApp;
        private BolaoNet.Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private BolaoNet.Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;
        private BolaoNet.Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;

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
            _bolaoMembroClassificacaoApp = kernel.Get<IBolaoMembroClassificacaoApp>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que executa o cálculo estatístico de verificação dos jogos.
        /// </summary>
        /// <param name="nomeBolao">Nome do bolão a ser verificado.</param>
        public void Run(string nomeBolao, bool reloadDatabase)
        {
            #region Variables

            int [] pontuacao = null;
            List<JogoInfo> list = null;
            List<ApostaExtraInfo> extras = null;
            List<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes = null;
            List<Domain.Entities.Boloes.BolaoMembroClassificacao> bolaoMembros = null;

            List<CriterioPontosTimes> criterioTimes = new List<CriterioPontosTimes>();
            List<MembroClassificacao> membros = new List<MembroClassificacao>();

            #endregion

            #region Loading database

            if (reloadDatabase)
            {
                extras = ExtractApostasExtras(nomeBolao);
                pontosTimes = (List<Domain.Entities.Boloes.BolaoCriterioPontosTimes>)_bolaoCriterioPontosTimesApp.GetCriterioPontosBolao(new Domain.Entities.Boloes.Bolao(nomeBolao));
                pontuacao = _bolaoCriterioPontosApp.GetCriteriosPontos(new Domain.Entities.Boloes.Bolao(nomeBolao));
                bolaoMembros = _bolaoMembroClassificacaoApp.GetAll().ToList();
                list = ExtractJogos(nomeBolao);
            }

            #endregion

            #region  Copying data

            if (reloadDatabase)
            {
                for (int c = 0; c < pontosTimes.Count; c++)
                {
                    criterioTimes.Add(new CriterioPontosTimes(pontosTimes[c]));
                }

                for (int c = 0; c < bolaoMembros.Count; c++)
                {
                    membros.Add(new MembroClassificacao(bolaoMembros[c]));
                }
            }
             
            #endregion

            #region Serialization

            string folder = ".\\Serialization";
            
            if (reloadDatabase)
            {
                if (!System.IO.Directory.Exists(folder))
                    System.IO.Directory.CreateDirectory(folder);

                Serialization.Serialize<List<ApostaExtraInfo>>(extras, System.IO.Path.Combine(folder, "extras.xml"));
                Serialization.Serialize<List<JogoInfo>>(list, System.IO.Path.Combine(folder, "list.xml"));
                Serialization.Serialize<List<CriterioPontosTimes>>(criterioTimes, System.IO.Path.Combine(folder, "criterioTimes.xml"));
                Serialization.Serialize<List<MembroClassificacao>>(membros, System.IO.Path.Combine(folder, "membros.xml"));
                Serialization.Serialize<int[]>(pontuacao, System.IO.Path.Combine(folder, "pontuacao.xml"));
            }
            else
            {
                extras = Serialization.DeserializeFromFile<List<ApostaExtraInfo>>(System.IO.Path.Combine(folder, "extras.xml"));
                list = Serialization.DeserializeFromFile<List<JogoInfo>>(System.IO.Path.Combine(folder, "list.xml"));
                criterioTimes = Serialization.DeserializeFromFile<List<CriterioPontosTimes>>(System.IO.Path.Combine(folder, "criterioTimes.xml"));
                membros= Serialization.DeserializeFromFile<List<MembroClassificacao>>( System.IO.Path.Combine(folder, "membros.xml"));
                pontuacao = Serialization.DeserializeFromFile<int[]>(System.IO.Path.Combine(folder, "pontuacao.xml"));
            }

            #endregion

#if (DEBUG_ELIMINATORIAS)

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].JogoId < 61)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

#endif

            #region Calcular possibilidades com base nas apostas

            DefinirPossibilidades(list);
            DefinirPossibilidades(extras);

            CalcularPontuacao(list, pontuacao, criterioTimes);
            CalcularPontuacao(extras);

            ValidarJogosResultado(list, pontuacao, criterioTimes);

            #endregion

            if (reloadDatabase)
            {
                Serialization.Serialize<List<ApostaExtraInfo>>(extras, System.IO.Path.Combine(folder, "extras_final.xml"));
                Serialization.Serialize<List<JogoInfo>>(list, System.IO.Path.Combine(folder, "list_final.xml")); 
            }

            string outputPath = "Jogos";

            FileStructureManager manager = new FileStructureManager();

            #region Apostas Extras

            string outputExtras = System.IO.Path.Combine (outputPath, "Extras");
            manager.SaveApostasExtras(outputExtras, extras);

            for (int c = 0; c < extras.Count; c++)
            {
                string outputExtrasOpcao = System.IO.Path.Combine(outputPath, "Extras_" + extras[c].Posicao);

                if (!System.IO.Directory.Exists(outputExtrasOpcao))
                    System.IO.Directory.CreateDirectory(outputExtrasOpcao);

                for (int i = 0; i < extras[c].Possibilidades.Count; i++)
                {
                    if (!System.IO.File.Exists(outputExtrasOpcao))
                    {

                        string fileExtraOpcao = System.IO.Path.Combine(outputExtrasOpcao, extras[c].Possibilidades[i].NomeTime + ".txt");

                        if (c == 0)
                            manager.SaveApostasExtrasPossibilidade(fileExtraOpcao, extras[c].Posicao, extras[c].Possibilidades[i].NomeTime, extras[c].Possibilidades[i]);
                        else
                        {
                            string basePath = System.IO.Path.Combine(outputPath, "Extras_" + extras[c - 1].Posicao);
                            manager.SaveApostasExtrasPossibilidade(basePath, fileExtraOpcao, extras[c].Posicao, extras[c].Possibilidades[i].NomeTime, extras[c].Possibilidades[i]);                            
                        }
                    }
                }
            }

            #endregion

            #region Apostas BASE

            if (!System.IO.Directory.Exists(outputPath))
                System.IO.Directory.CreateDirectory(outputPath);

            List<JogoInfo> listBase = list.OrderBy(x => x.DataJogo).ToList ();

            string indexFile = System.IO.Path.Combine(outputPath, "Index.txt");
            JogoPossibilidadeAgrupamento agrIndex = new JogoPossibilidadeAgrupamento(listBase[listBase.Count - 1].Possibilidades[0]);
            manager.SaveIndex(indexFile, agrIndex);

            string outputPontos = System.IO.Path.Combine (outputPath, "Pontos");

            if (!System.IO.Directory.Exists(outputPontos))
                System.IO.Directory.CreateDirectory(outputPontos);

            for (int c = 0; c < listBase[listBase.Count - 1].Possibilidades.Count; c++)
            {
                string path = System.IO.Path.Combine(outputPath, listBase[listBase.Count - 1].JogoId.ToString());

                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                string file = System.IO.Path.Combine(path,
                    listBase[listBase.Count - 1].Possibilidades[c].GolsTime1 + "_" +
                    listBase[listBase.Count - 1].Possibilidades[c].GolsTime2 + ".txt");

                if (System.IO.File.Exists(file))
                    continue;

                JogoPossibilidadeAgrupamento agrupamento = new JogoPossibilidadeAgrupamento(listBase[listBase.Count - 1].Possibilidades[c]);
                agrupamento.Jogos.Add(new JogoIdAgrupamento()
                {
                    Gols1 = listBase[listBase.Count - 1].Possibilidades[c].GolsTime1,
                    Gols2 = listBase[listBase.Count - 1].Possibilidades[c].GolsTime2,
                    JogoId = listBase[listBase.Count - 1].JogoId
                });

                manager.SaveFile(file, agrupamento);
            }

            string newFile = System.IO.Path.Combine(outputPontos, listBase[listBase.Count - 1].JogoId + ".txt");

            if (!System.IO.File.Exists(newFile))
                manager.SaveJogoPossibilidades(newFile, listBase[listBase.Count - 1]);

            #endregion

            #region Armazenamento de pontos dos jogos

            for (int i = listBase.Count - 1; i >= 0; i--)
            {
                if (!listBase[i].IsValid)
                {
                    newFile = System.IO.Path.Combine(outputPontos, listBase[i].JogoId + ".txt");

                    if (!System.IO.File.Exists(newFile))
                        manager.SaveJogoPossibilidades(newFile, listBase[i]);
                }
            }

            #endregion

#if !IGNORE_CALCULO_PONTOS
            #region Cálculo de Apostas

            //Todas as apostas
            for (int i = listBase.Count - 2; i >= 0; i--)
            {
                Console.WriteLine(DateTime.Now.ToString() + " - " + listBase[i].JogoId + " - Análise de Apostas do jogo");

                #region Atribuindo as possibilidades

                for (int c = 0; c < listBase[i].Possibilidades.Count; c++)
                {
                    Console.WriteLine(DateTime.Now.ToString() + " - Possibilidade : [" +
                        listBase[i].Possibilidades.Count + " / " + (c + 1) + "] : " +
                        listBase[i].Possibilidades[c].GolsTime1 + " x " + listBase[i].Possibilidades[c].GolsTime2);

                    string path = System.IO.Path.Combine(outputPath, listBase[i].JogoId.ToString());

                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(path);

                    string file = System.IO.Path.Combine(path,
                        listBase[i].Possibilidades[c].GolsTime1 + "_" +
                        listBase[i].Possibilidades[c].GolsTime2 + ".txt");

                    int f = i + 1;
  
                    string pathBase = System.IO.Path.Combine(outputPath, listBase[f].JogoId.ToString());

                    JogoPossibilidadeAgrupamento agrupamento = new JogoPossibilidadeAgrupamento(listBase[i].Possibilidades[c]);
                    agrupamento.Jogos.Add(new JogoIdAgrupamento()
                    {
                        Gols1 = listBase[i].Possibilidades[c].GolsTime1,
                        Gols2 = listBase[i].Possibilidades[c].GolsTime2,
                        JogoId = listBase[i].JogoId
                    });
                    agrupamento.JogoId = listBase[i].JogoId;

                    manager.ReadAppendSave(file, pathBase, agrupamento);
                }

                //newFile = System.IO.Path.Combine(outputPontos, listBase[i].JogoId + ".txt");

                //if (!System.IO.File.Exists(newFile))
                //    manager.SaveJogoPossibilidades(newFile, listBase[i]);

                #endregion

                Console.WriteLine(DateTime.Now.ToString() + " - " + listBase[i].JogoId + " - Fim da análise");

                if (i < FileStructureManager.JogoIdJogoPendente)
                    break;
            }//end for jogos

            #endregion
#endif

#if DEBUG_SEMIFINAL
            list[61 - 1].NomeTime1 = "Argentina";
            list[61 - 1].NomeTime2 = "Croácia";
            list[62 - 1].NomeTime1 = "França";
            list[62 - 1].NomeTime2 = "Marrocos";
#endif

            #region Times Jogos

            string fileTimes = System.IO.Path.Combine(outputPath, "times.txt");

            if (!System.IO.File.Exists(fileTimes))
                manager.SaveTimesJogos(fileTimes, list);

            #endregion

            #region Classificacao

            //TODO: Retirar o comentário para efetuar o cálculo correto dos pontos
            SavePontuacaoClassificacao(System.IO.Path.Combine(outputPath, "Classificacao_Pontos"), list);

            string fileClassificacaoValidacao = System.IO.Path.Combine(outputPath, "ClassValidacao.txt");
            SaveClassificacao(fileClassificacaoValidacao, list);

            string fileClassificacao = System.IO.Path.Combine(outputPath, "Classificacao.txt");
            
            if (!System.IO.File.Exists(fileClassificacao))
                manager.SaveClassificacao(fileClassificacao, membros);

            manager.UpdateClassificacao(fileClassificacao, membros);

            #endregion

            #region Possibilidade de Apostas Extras para times

            IList<ExtraJogoTime> possibilidadeExtras = manager.GetPossibilidadeTimes(extras, list);

            #endregion

            //#region Simulação de Jogo 

            //List<JogoIdAgrupamento> jogosSimulacao = new List<JogoIdAgrupamento>();
            //jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 59, Gols1 = 1, Gols2 = 2 });
            //jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 61, Gols1 = 1, Gols2 = 2 });
            //jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 62, Gols1 = 1, Gols2 = 2 });
            //jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 63, Gols1 = 1, Gols2 = 2 });
            //jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 64, Gols1 = 1, Gols2 = 2 });
            //new SimulateJogos().Calcular(outputPontos, bolaoMembros, list, extras, jogosSimulacao);

            //#endregion

            #region Possibilidades de usuários

            string apostas = System.IO.Path.Combine(outputPath, "Usuarios");
            if (!System.IO.Directory.Exists(apostas))
                System.IO.Directory.CreateDirectory(apostas);

            //TODO: Alterar o identificador do jogo para buscar as possibilidades
            int jogoIdCheck = FileStructureManager.JogoIdJogoPendente;

            int posId = -1;
            for (int c = listBase.Count - 1; c >= 0; c-- )
            {
                if (listBase[c].JogoId == jogoIdCheck)
                {
                    posId = c;
                    break;
                }
            }

            #region Cálculo de pontos dos usuários
            //for (int i = listBase.Count - 1; i >= 0; i--)
            {
                int jogoId = listBase[posId].JogoId;
                string jogoPath = System.IO.Path.Combine(outputPath, jogoId.ToString());
                string apostasPath = System.IO.Path.Combine(apostas, jogoId.ToString());

                string baseApostas = System.IO.Path.Combine(outputPath, "TempApostas");

                if (System.IO.Directory.Exists(apostasPath))                
                    System.IO.Directory.Delete(apostasPath, true);               
                System.IO.Directory.CreateDirectory(apostasPath);

                if (System.IO.Directory.Exists(baseApostas))
                    System.IO.Directory.Delete(baseApostas, true);                
                System.IO.Directory.CreateDirectory(baseApostas);

                for (int c = 0; c < agrIndex.Pontuacao.Count; c++)
                {
                    string userName = agrIndex.Pontuacao[c].UserName;

#if (DEBUG_USUARIO)
                    userName = "thoris";
#endif

                    string file = System.IO.Path.Combine(apostas, userName);

                    Console.WriteLine(DateTime.Now.ToString() + " - Jogo[" + jogoId + "] - Análise de Apostas do Usuário: " + userName);

                    string outputApostas = System.IO.Path.Combine(apostasPath, userName + ".txt");

                    manager.CheckPossibilidades(baseApostas, outputApostas, indexFile, jogoPath, membros, userName, extras, listBase, possibilidadeExtras, true, 1, 2, 3);

                    Console.WriteLine(DateTime.Now.ToString() + " - Jogo[" + jogoId + "] - Análise de Apostas do Usuário: " + userName + ". FIM");
#if (DEBUG_USUARIO)
                    break;
#endif
                }
            }
            #endregion

            #endregion

            Console.WriteLine (DateTime.Now.ToString() + " - Iniciando análise de quantidade de possibilidades.");
            #region Percentual

            string percentualFile = System.IO.Path.Combine(outputPath, "contagem.txt");
            manager.CalcularQuantidade(percentualFile, System.IO.Path.Combine( apostas, jogoIdCheck.ToString()));

            Console.WriteLine (DateTime.Now.ToString() + " - Iniciando análise de quantidade de possibilidades. FIM");
            string percFile = System.IO.Path.Combine(outputPath, "percentual.txt");
            manager.CalcularPercentual(percFile, percentualFile);

            #endregion

            SaveLogJogos("log.log", list, extras);

        }

        public void ReRun(string nomeBolao)
        {
            int[] pontuacao = null;
            List<JogoInfo> list = null;
            List<ApostaExtraInfo> extras = null;
            List<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontosTimes = null;
            List<Domain.Entities.Boloes.BolaoMembroClassificacao> bolaoMembros = null;
            FileStructureManager manager = new FileStructureManager();

            List<CriterioPontosTimes> criterioTimes = new List<CriterioPontosTimes>();
            List<MembroClassificacao> membros = new List<MembroClassificacao>();
            extras = ExtractApostasExtras(nomeBolao);
            //pontosTimes = (List<Domain.Entities.Boloes.BolaoCriterioPontosTimes>)_bolaoCriterioPontosTimesApp.GetCriterioPontosBolao(new Domain.Entities.Boloes.Bolao(nomeBolao));
            //pontuacao = _bolaoCriterioPontosApp.GetCriteriosPontos(new Domain.Entities.Boloes.Bolao(nomeBolao));
            bolaoMembros = _bolaoMembroClassificacaoApp.GetAll().ToList();
            list = ExtractJogos(nomeBolao);

            string outputPath = "Jogos";
            //string percentualFile = System.IO.Path.Combine(outputPath, "contagem.txt");
            string outputPontos = System.IO.Path.Combine(outputPath, "Pontos");
            string outputExtras = System.IO.Path.Combine(outputPath, "Extras");
            string outputSimulacoes = System.IO.Path.Combine(outputPath, "Simulacoes");
            if (!System.IO.Directory.Exists(outputSimulacoes))
                System.IO.Directory.CreateDirectory(outputSimulacoes);

            #region Simulação de Jogo

            List<JogoIdAgrupamento> jogosSimulacao = new List<JogoIdAgrupamento>();
            jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 61, Gols1 = 0, Gols2 = 1 });
            jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 62, Gols1 = 0, Gols2 = 2 });
            jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 63, Gols1 = 1, Gols2 = 0 });
            jogosSimulacao.Add(new JogoIdAgrupamento() { JogoId = 64, Gols1 = 2, Gols2 = 1 });
            List<string> campeoes = new List<string>();
            campeoes.Add("Croácia");
            campeoes.Add("Marrocos");
            campeoes.Add("Argentina");
            campeoes.Add("França");

            string outputSimulacao = System.IO.Path.Combine(outputSimulacoes, "simulacao1.txt");

            new SimulateJogos().Calcular(outputPontos, outputExtras, bolaoMembros, list, extras, jogosSimulacao, campeoes, outputSimulacao);

            #endregion
        }

        private void ValidarJogosResultado(List<JogoInfo> list, int[] pontuacao, List<CriterioPontosTimes> pontosTimes)
        {
            for (int c=0; c < list.Count; c++)
            {
                if (list[c].IsValid)
                {
                    list[c].Possibilidades.Clear();
                    list[c].Possibilidades.Add(new JogoPossibilidade((short)list[c].GolsTime1, (short)list[c].GolsTime2));

                    CalcularPontuacao(list[c], pontuacao, pontosTimes);
                }
            }
        }

        /// <summary>
        /// Método que efetua o carregamento de todos os jogos e apostas do bolão.
        /// </summary>
        /// <param name="nomeBolao">Nome do bolão a serem extraídos os jogos e apostas.</param>
        /// <returns>Lista de objeto que possui dados extraídos da aposta e jogos.</returns>
        private List<JogoInfo> ExtractJogos(string nomeBolao)
        {
            List<JogoInfo> list = new List<JogoInfo>();

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
        private List<JogoInfo> SimulateExtractJogos(string nomeBolao, int totalUsuarios, int maxGols)
        {
            List<JogoInfo> list = new List<JogoInfo>();

            Random rnd = new Random();

            for (int c = 0; c < FileStructureManager.JogoIdFinal; c++)
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
        private List<Domain.Entities.Boloes.BolaoCriterioPontosTimes> SimulateExtractPontosTimes(string nomeBolao)
        {
            List<Domain.Entities.Boloes.BolaoCriterioPontosTimes> pontuacaoTimes =
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

            IList<short> golsTime1 = new List<short>();
            IList<short> golsTime2 = new List<short>();


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

                    short gols1 = (short)jogo.Apostas[c].ApostaTime1;
                    short gols2 = (short)jogo.Apostas[c].ApostaTime2;

                    if (!golsTime1.Contains(gols1))
                    {
                        golsTime1.Add(gols1);             
                    }
                    if (!golsTime2.Contains(gols2))
                    {
                        golsTime2.Add(gols2);
                    }
                }
                else
                {
                    //Inclui no total de apostas
                    jogo.Possibilidades[pos].TotalApostas++;

                }//end if encontrou a aposta


#if (DEBUG_FAST_POSSIBILIDADES)
                if (c > 2)
                    break;
#endif
            }//end for apostas


            for (int c = 0; c < golsTime1.Count; c++ )
            {
                if (BuscarPossibilidade(jogo.Possibilidades, golsTime1[c], GolsSemApostaMaior) == -1)
                    jogo.Possibilidades.Add(new JogoPossibilidade(golsTime1[c], GolsSemApostaMaior));

                if (golsTime1[c] > 0)
                {
                    for (int i = 0; i < golsTime1[c] - 1; i++ )
                    {
                        int pos = BuscarPossibilidade(jogo.Possibilidades, golsTime1[c], i);

                        if (pos == -1)
                            if (BuscarPossibilidade(jogo.Possibilidades, golsTime1[c], GolsSemApostaNegativa) == -1)
                                jogo.Possibilidades.Add(new JogoPossibilidade(golsTime1[c], GolsSemApostaNegativa));
                    }
                }
            }
            for (int c = 0; c < golsTime2.Count; c++)
            {
                if (BuscarPossibilidade(jogo.Possibilidades, GolsSemApostaMaior, golsTime2[c]) == -1)
                    jogo.Possibilidades.Add(new JogoPossibilidade(GolsSemApostaMaior, golsTime2[c]));

                if (golsTime2[c] > 0)
                {
                    for (int i = 0; i < golsTime2[c] - 1; i++)
                    {
                        int pos = BuscarPossibilidade(jogo.Possibilidades, i, golsTime2[c]);

                        if (pos == -1)
                            if (BuscarPossibilidade(jogo.Possibilidades, GolsSemApostaNegativa, golsTime2[c] ) == -1)
                                jogo.Possibilidades.Add(new JogoPossibilidade(GolsSemApostaNegativa, golsTime2[c]));
                    }

                    //if (BuscarPossibilidade(jogo.Possibilidades, GolsSemApostaNegativa, golsTime2[c]) == -1)
                    //    jogo.Possibilidades.Add(new JogoPossibilidade(GolsSemApostaNegativa, golsTime2[c]));
                }
            }


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
            return BuscarPossibilidade(list, aposta.ApostaTime1, aposta.ApostaTime2);
        }

        public int BuscarPossibilidade(IList<JogoPossibilidade> list, int gols1, int gols2)
        {
            for (int c = 0; c < list.Count; c++)
            {
                if (list[c].GolsTime1 == gols1 && list[c].GolsTime2 == gols2)
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
        private void CalcularPontuacao(IList<JogoInfo> jogos, int[] pontuacao, List<CriterioPontosTimes> pontosTimes)
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
        private void CalcularPontuacao(JogoInfo jogo, int[] pontuacao, List<CriterioPontosTimes> pontosTimes)
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
        private void CalcularPontuacao(JogoInfo jogo, JogoPossibilidade possibilidade, int[] pontuacao, List<CriterioPontosTimes> pontosTimes)
        {

            possibilidade.Pontuacao = new List<ApostaPontos>();

            for (int i = 0; i < jogo.Apostas.Count; i++)
            {
                int res = CalcularPontos(pontuacao, jogo.NomeTime1, jogo.NomeTime2, "", "",
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
        private int CalcularPontos(int[] pontos, string nomeTime1, string nomeTime2, string nomeTime1Aposta, string nomeTime2Aposta, int gols1, int gols2, int aposta1, int aposta2, List<CriterioPontosTimes> pontosTimes)
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
            int countPontosAcertoTime = 0;
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
                nomeTime1, nomeTime2, nomeTime1Aposta, nomeTime2Aposta,
                countEmpate, countVitoria, countDerrota, countGanhador, countPerdedor, countTime1, countTime2,
                countVDE, countErro, countGanhadorFora, countGanhadorDentro, countPerdedorFora, countPerdedorDentro,
                countEmpateGols, countGolsTime1, countGolsTime2, countCheio, countPontosAcertoTime, ismultiploTime, multiploTime);


            return resultado;
        }

        /// <summary>
        /// Método que efetua a extração das apostas extras dos usuários.
        /// </summary>
        /// <param name="nomeBolao"></param>
        /// <returns></returns>
        private List<ApostaExtraInfo> ExtractApostasExtras(string nomeBolao)
        {
            List<ApostaExtraInfo> list = new List<ApostaExtraInfo>();

            IList<Domain.Entities.Boloes.ApostaExtra> extras =
                _apostaExtraApp.GetApostasBolao(new Domain.Entities.Boloes.Bolao(nomeBolao));
            
            IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> apostas =
                   _apostaExtraUsuarioApp.GetApostasBolaoAgrupado(new Domain.Entities.Boloes.Bolao(nomeBolao));

            for (int c = 0; c < extras.Count; c++ )
            {
                ApostaExtraInfo info = new ApostaExtraInfo(extras[c]);
                info.NomeTimeValidado = extras[c].NomeTimeValidado;

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

            if (extra.NomeTimeValidado == null)
            {
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
            else
            {
                extra.Possibilidades.Add(new ApostaExtraPossibilidade() { NomeTime = extra.NomeTimeValidado, TotalApostas = 1 });
            }
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

        private void SaveClassificacao(string file, IList<JogoInfo> jogos)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            List<ApostaPontos> pontos = new List<ApostaPontos>();

            for (int c=0; c < jogos.Count; c++)
            {
                if (jogos[c].IsValid)
                {
                    if(pontos.Count == 0)
                    {
                        for (int i = 0; i < jogos[c].Possibilidades[0].Pontuacao.Count; i++ )
                        {
                            pontos.Add(new ApostaPontos()
                            {
                                UserName = jogos[c].Possibilidades[0].Pontuacao[i].UserName,
                                Pontos = jogos[c].Possibilidades[0].Pontuacao[i].Pontos
                            });
                        }
                    }
                    else
                    {
                        for (int i = 0; i < jogos[c].Possibilidades[0].Pontuacao.Count; i++)
                        {
                            pontos[i].Pontos += jogos[c].Possibilidades[0].Pontuacao[i].Pontos;
                        }
                    }
                }
            }

            List<ApostaPontos> pt = pontos.OrderByDescending(x => x.Pontos).ToList();

#region Calculando posições

            int currentPosicao = 0;
            int currentPontos = -1;
            int countPosicao = 0;

            for (int c = 0; c < pt.Count; c++)
            {
                countPosicao++;
                if (pt[c].Pontos != currentPontos)
                {
                    currentPosicao = countPosicao;
                    pt[c].Posicao = currentPosicao;
                    currentPontos = pt[c].Pontos;
                }
                else
                {
                    pt[c].Posicao = currentPosicao;
                }
            }
#endregion

            StreamWriter writer = new StreamWriter(file);

            for (int c = 0; c < pt.Count; c++)
            {
                writer.WriteLine(pt[c].Posicao + "|" + pt[c].UserName + "=" + pt[c].Pontos);
            }

            writer.Close();

        }

        private void SavePontuacaoClassificacao(string folder, IList<JogoInfo> jogos)
        {
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            string[] files = System.IO.Directory.GetFiles(folder);
            for (int c = 0; c < files.Length; c++)
                System.IO.File.Delete(files[c]);


            for (int c = 0; c < jogos.Count; c++)
            {
                if (jogos[c].IsValid)
                {
                    for (int i = 0; i < jogos[c].Possibilidades[0].Pontuacao.Count; i++)
                    {
                        string file = System.IO.Path.Combine (folder, jogos[c].Possibilidades[0].Pontuacao[i].UserName + ".txt");
                        StreamWriter writer = null;
                        if (System.IO.File.Exists(file))
                            writer = new StreamWriter(file, true);
                        else
                            writer = new StreamWriter(file);

                        writer.Write(jogos[c].JogoId + "|" + jogos[c].NomeTime1 + " [ " + jogos[c].GolsTime1 + " ]x[ " + jogos[c].GolsTime2 + " ] " + jogos[c].NomeTime2 +
                            " [" + jogos[c].Possibilidades[0].Pontuacao[i].Gols1 + " x " + jogos[c].Possibilidades[0].Pontuacao[i].Gols2 + "] => " + 
                            jogos[c].Possibilidades[0].Pontuacao[i].Pontos);

                        writer.WriteLine();

                        writer.Close();

                    }
                }
                else
                {
                    for (int i = 0; i < jogos[c].Possibilidades[0].Pontuacao.Count; i++)
                    {
                        string file = System.IO.Path.Combine(folder, jogos[c].Possibilidades[0].Pontuacao[i].UserName + ".txt");
                        StreamWriter writer = null;
                        if (System.IO.File.Exists(file))
                            writer = new StreamWriter(file, true);
                        else
                            writer = new StreamWriter(file);

                        writer.Write(jogos[c].JogoId + "|" + jogos[c].NomeTime1 + " [ "  + " ]x[ " +  " ] " + jogos[c].NomeTime2 +
                            " [" + jogos[c].Possibilidades[0].Pontuacao[i].Gols1 + " x " + jogos[c].Possibilidades[0].Pontuacao[i].Gols2 + "]  ");

                        writer.WriteLine();

                        writer.Close();

                    }
                }
            }
        }


#endregion
    }
}
