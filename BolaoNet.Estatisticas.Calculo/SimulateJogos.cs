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

        public void Calcular(string pontosFolder, List<Domain.Entities.Boloes.BolaoMembroClassificacao> bolaoMembros, IList<JogoInfo> jogos, IList<ApostaExtraInfo> extras, List<JogoIdAgrupamento> jogoAgrupamento)
        {
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

                for (int i=0; i < pontosUsuarios.Length; i++)
                {
                    bolaoMembros[i].TotalPontos += pontosUsuarios[i];
                }

            }
        }

        #endregion
    }
}
