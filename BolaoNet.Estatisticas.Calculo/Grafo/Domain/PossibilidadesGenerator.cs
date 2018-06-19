using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class PossibilidadesGenerator
    {
        #region Variables

        private IList<PossibilidadeJogos> _possibilidades;
        private string _resultFile = "result.txt";
        private string _idFile = "idFile.txt";

        #endregion

        #region Methods

        public void SaveIdFile(IList<IVertice> vertices)
        {
            SaveIdFile(vertices, _idFile);
        }
        private void SaveIdFile(IList<IVertice> vertices, string file)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);


            StreamWriter writer = new StreamWriter(file);

            for (int c=0; c < vertices.Count; c++)
            {
                VerticeAposta aposta = vertices[c] as VerticeAposta;
                Identifier id = aposta.Identifier as Identifier;

                writer.WriteLine(id.Index + "\t: " + id.JogoId + "\t|\t" + id.PossibilidadeId + " ["  +  aposta.GolsTime1 + " x " + aposta.GolsTime2 + "]");
            }

            writer.Close();
        }

        public void Generate(IList<IVertice> vertices, IVertice main)
        {
            if (System.IO.File.Exists(_resultFile))
                System.IO.File.Delete(_resultFile);

            //SaveIdFile(vertices, _idFile);
            IList<IList<int>> list = new List<IList<int>>();
            
            for (int c=0; c < main.Arestas.Count; c++)
            {
                IList<int> currentIndex = new List<int>();
                RecursiveFindPath(list, vertices, main.Arestas[c], currentIndex, 1, c+1, main.Arestas.Count);
            }
        }


        public void RecursiveFindPath(IList<IList<int>> list, IList<IVertice> vertices, IAresta aresta, IList<int> currentIndex, int deep, int cont, int total)
        {



            if (deep == 1)
                Console.WriteLine("1" + cont + " / " + total);
            else if (deep == 2)
                Console.WriteLine("\t2" + cont + " / " + total);
            else if (deep == 3)
                Console.WriteLine("\t\t3" + cont + " / " + total);
            else if (deep == 4)
                Console.WriteLine("\t\t\t4" + cont + " / " + total);
            else if (deep == 5)
                Console.WriteLine("\t\t\t\t5" + cont + " / " + total);
            else if (deep == 6)
                Console.WriteLine("\t\t\t\t\t6" + cont + " / " + total);
            else if (deep == 7)
                Console.WriteLine("\t\t\t\t\t\t7" + cont + " / " + total);
            //else if (deep == 8)
            //    Console.WriteLine("\t\t\t\t\t\t\t8");
            //else if (deep == 8)
            //    Console.WriteLine("\t\t\t\t\t\t\t\t9");
            //else if (deep == 9)
            //    Console.WriteLine("\t\t\t\t\t\t\t\t\t10");

            IList<int> newIndex = new List<int>();

            for (int c = 0; c < currentIndex.Count; c++)
                newIndex.Add(currentIndex[c]);

            newIndex.Add(aresta.VerticeId.Index);

            IVertice currentVertice = vertices[aresta.VerticeId.Index];

            if (currentVertice.Arestas == null || currentVertice.Arestas.Count == 0)
            {
                StreamWriter writer = new StreamWriter(_resultFile, true);
                for (int i = 0; i < newIndex.Count; i++ )
                {
                    if (i > 0)
                        writer.Write(",");
                    writer.Write(newIndex[i]);
                }
                writer.WriteLine();
                writer.Close();
                //list.Add(newIndex);

                return;
            }

            for (int c = 0; c < currentVertice.Arestas.Count; c++)
            {
                if (currentIndex.Contains(currentVertice.Arestas[c].VerticeId.Index))
                    continue;




                RecursiveFindPath(list, vertices, currentVertice.Arestas[c], newIndex, deep + 1, c+1, currentVertice.Arestas.Count);
            }

            //currentPath.AddAresta(aresta);

            //IVertice currentVertice = vertices[aresta.VerticeId.Index];

            //if (currentVertice.Arestas == null || currentVertice.Arestas.Count == 0)
            //{
            //    list.Add(currentPath.Clone());
            //    return;
            //}

            //for (int c=0; c < currentVertice.Arestas.Count; c++)
            //{
            //    if (currentPath.IsAlreadyDone(currentVertice.Arestas[c].VerticeId))
            //        continue;

            //    RecursiveFindPath(list, vertices, currentVertice.Arestas[c], currentPath, deep + 1); 
            //}
        }

        #endregion
    }
}
