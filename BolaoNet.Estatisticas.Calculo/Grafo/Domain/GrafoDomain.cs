using BolaoNet.Estatisticas.Calculo.Grafo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class GrafoDomain : GrafoBase, IGrafo
    {

        #region Constructors/Destructors

        public GrafoDomain()
            : base(new List<IVertice>())
        {
        }

        #endregion

        #region Methods
 

        public void CreateGrafo(IList<JogoInfo> jogos)
        {
            Console.WriteLine("Montando o grafo dos jogos... Total: " + jogos.Count);

            int totalArestas = 0;
            int totalVertices = 0;

            this.Clear();

            IIdentifier mainId = Identifier.Create(GetTotalVertices() + 1, 0, 0);
            IVertice mainVertice = this.CreateVertice(mainId);
            Add(mainVertice);
            totalVertices++;

            //Buscando todas as vértices (Possibilidade de jogos)
            for (int c=0; c < jogos.Count; c++)
            {
                for (int i = 0; i < jogos[c].Possibilidades.Count; i++)
                {
                    IIdentifier identifier = Identifier.Create(GetTotalVertices() + 1, jogos[c].JogoId, i);

                    IVertice vertice = this.CreateVertice(identifier);
                    ((VerticeAposta)vertice).SetPossibilidade(jogos[c].Possibilidades[i]);

                    this.Add(vertice);

                    totalVertices++;
                }
            }//end for c


            //Criando as arestas dos primeiros jogos associados ao vértice principal
            for (int i = 0; i < jogos[0].Possibilidades.Count; i++)
            {
                IIdentifier idTarget = Identifier.Create(0, jogos[0].JogoId, i);
                IAresta aresta = this.CreateAresta(mainId, idTarget);
                Add(mainId, aresta);

                totalArestas++;

            }//end for i
            


            //Criando as arestas das possibilidades dos jogos
            for (int c = 0; c < jogos.Count - 1; c++)
            {
                for (int i = 0; i < jogos[c].Possibilidades.Count; i++)
                {
                    for (int x = 0; x < jogos[c + 1].Possibilidades.Count; x++)
                    {
                        IIdentifier idSource = Identifier.Create(0, jogos[c].JogoId, i);
                        IIdentifier idTarget = Identifier.Create(0, jogos[c + 1].JogoId, x);

                        IAresta aresta = this.CreateAresta(idSource, idTarget);
                        //((ArestaJogo)aresta).SetPontuacao(jogos[c+1].Possibilidades)

                        Add(idSource, aresta);
                        totalArestas++;

                    }//end for x
                }//end for i
            }//end for c


            Console.WriteLine("Total de Vértices: " + totalVertices + " ... Total de Arestas: " + totalArestas);

        }

        #endregion

        #region IGrafo members

        public override IVertice CreateVertice(IIdentifier identifier)
        {
            return VerticeAposta.Create(identifier);
        }
        public override IAresta CreateAresta(IIdentifier source, IIdentifier target)
        {
            return ArestaJogo.Create(target);
        }

        #endregion
    }
}
