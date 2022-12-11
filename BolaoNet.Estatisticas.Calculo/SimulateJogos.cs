using BolaoNet.Domain.Entities.Boloes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class SimulateJogos
    {
        #region Methods

        public void Calcular(string pontosFolder, string extrasFolder, List<Domain.Entities.Boloes.BolaoMembroClassificacao> bolaoMembros, IList<JogoInfo> jogos, IList<ApostaExtraInfo> extras, List<JogoIdAgrupamento> jogoAgrupamento, List<string> campeoes, string outputFile)
        {
            List<List<int>> pontos = new List<List<int>>();
            List<List<int>> extrasPontos = new List<List<int>>();
            List<int> pontosOriginal = new List<int>();

            for (int c=0; c < bolaoMembros.Count; c++)
            {
                pontosOriginal.Add((int)bolaoMembros[c].TotalPontos);
            }

            #region Calculando pontos dos jogos
            for (int c=0; c < jogoAgrupamento.Count; c++)
            {
                string fileJogoId = System.IO.Path.Combine(pontosFolder, jogoAgrupamento[c].JogoId + ".txt");
                StreamReader reader = new StreamReader(fileJogoId);

                string jogoResultado = jogoAgrupamento[c].JogoId + "=" + jogoAgrupamento[c].Gols1 + "x" + jogoAgrupamento[c].Gols2;
                int[] pontosUsuarios = new int[bolaoMembros.Count];
                bool found = false;
                int userId = 0;
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (string.Compare(line, jogoResultado, true) == 0)
                    {
                        found = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (line.Contains("="))
                            {
                                found = false;
                            }
                            else if (found)
                            {
                                pontosUsuarios[userId++] = int.Parse(line);
                            }
                        }
                    }                    
                }

                reader.Close();

                pontos.Add(new List<int>());
                for (int i=0; i < pontosUsuarios.Length; i++)
                {
                    pontos[c].Add(pontosUsuarios[i]);
                    bolaoMembros[i].TotalPontos += pontosUsuarios[i];
                }
            }
            #endregion

            #region Calculando pontuação extra
            for (int c = 0; c < campeoes.Count; c++)
            {
                string extraFile = System.IO.Path.Combine(extrasFolder, (c+1) + ".txt");
                StreamReader reader = new StreamReader(extraFile);

                string extraResultado = "*" + campeoes[c];
                int[] pontosUsuarios = new int[bolaoMembros.Count];
                bool found = false;
                int userId = 0;
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (string.Compare(line, extraResultado, true) == 0)
                    {
                        found = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (line.Contains("*"))
                            {
                                found = false;
                            }
                            else if (found)
                            {
                                pontosUsuarios[userId++] = int.Parse(line);
                            }
                        }
                    }
                }

                reader.Close();

                extrasPontos.Add(new List<int>());
                for (int i = 0; i < pontosUsuarios.Length; i++)
                {
                    extrasPontos[c].Add(pontosUsuarios[i]);
                    bolaoMembros[i].TotalPontos += pontosUsuarios[i];
                }
            }
            #endregion

            var order = bolaoMembros.OrderByDescending(x => x.TotalPontos).ToList<BolaoMembroClassificacao>();
            int lastPoints = -1;
            int pos = 0;
            int posTotal = 0;
            for (int c=0; c < order.Count; c++)
            {
                posTotal++;
                if (order[c].TotalPontos != lastPoints)
                {
                    pos = posTotal;
                    lastPoints = (int)order[c].TotalPontos;
                }
                order[c].Posicao = pos;
            }

            StreamWriter writer = new StreamWriter(outputFile);

            writer.WriteLine("--- Campeões ---");
            for (int c=0; c < campeoes.Count; c++)
            {
                writer.WriteLine((c+1) + ":" + campeoes[c]);
            }

            writer.WriteLine("--- Jogos ---");
            for (int c=0; c < jogoAgrupamento.Count; c++)
            {
                writer.WriteLine(jogoAgrupamento[c].JogoId + ":" + jogoAgrupamento[c].Gols1 + " x " + jogoAgrupamento[c].Gols2);
            }

            writer.WriteLine();
            writer.Write("pos|" + "nome".PadRight(26) + "|" + "Pts".PadLeft(5) + "|");
            for (int c=0; c < jogoAgrupamento.Count; c++)
            {
                writer.Write(("J" + jogoAgrupamento[c].JogoId.ToString()).PadLeft(4) + "|");
            }
            for (int c=0; c < campeoes.Count; c++)
            {
                writer.Write(("E" + (c+1).ToString()).PadLeft(4) + "|");
            }
            writer.WriteLine("Pts atual");
            for (int c=0; c < order.Count; c++)
            {
                writer.Write(((int)order[c].Posicao).ToString().PadLeft(3) + "|");
                writer.Write(order[c].UserName.PadRight(26, ' ') + "|"); 
                writer.Write(order[c].TotalPontos.ToString().PadLeft(5) + "|");

                for (int i = 0; i < bolaoMembros.Count; i++)
                {
                    if (string.Compare(order[c].UserName, bolaoMembros[i].UserName, true) == 0)
                    {
                        for (int x=0; x < jogoAgrupamento.Count; x++)
                        {
                            writer.Write(pontos[x][i].ToString().PadLeft(4) + "|");
                        }

                        for (int x=0; x < extrasPontos.Count; x++)
                        {
                            writer.Write(extrasPontos[x][i].ToString().PadLeft(4) + "|");
                        }

                        writer.WriteLine( "" + pontosOriginal[i].ToString().PadLeft(4) + "");
                        break;
                    }
                }
            }

            writer.Close();

        }

        #endregion
    }
}
