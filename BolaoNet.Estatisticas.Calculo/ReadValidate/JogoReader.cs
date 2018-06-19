using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.ReadValidate
{
    public class JogoReader
    {
        #region Methods

        public void ReadCalcule(IList<Grafo.IVertice> grafo, IList<ReadValidate.ResultadoJogo> jogos, string file)
        {
            StreamReader reader = new StreamReader(file);

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                if (!string.IsNullOrEmpty (line))
                {
                    ResultadoAgrupamento agrupamento = ConvertLine(grafo, jogos, line);
                }
            }

            reader.Close();
        }

        private ResultadoAgrupamento ConvertLine(IList<Grafo.IVertice> grafo, IList<ReadValidate.ResultadoJogo> jogos, string line)
        {
            ResultadoAgrupamento res = new ResultadoAgrupamento();

            string[] ids = line.Split(new char[] { ',' });

            for (int c = 0; c < ids.Length; c++)
            {
                int id = int.Parse (ids[c]);

                res.Jogos.Add(jogos[id]);

                //Grafo.Domain.ArestaJogo aresta = grafo[jogos[id].Index].Arestas[jogos[id].PossibilidadeId] as Grafo.Domain.ArestaJogo;

                //res.AddAresta(aresta);
            }

            return res;
        }

        private void SaveResult(ResultadoAgrupamento agrupamento, string output)
        {

        }

        #endregion
    }
}
