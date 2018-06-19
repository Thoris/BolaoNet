using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class PossibilidadeJogos 
    {
        #region Properties

        public IList<IIdentifier> Caminho { get; set; }
        public IDictionary<string, int> Pontos { get; set; }

        #endregion

        #region Constructors/Destructors

        public PossibilidadeJogos()
        {
            this.Pontos = new Dictionary<string, int>();
            this.Caminho = new List<IIdentifier>();
        }
        public PossibilidadeJogos(PossibilidadeJogos possibilidades)
            : this()
        {
            //this.Pontos = new Dictionary<string, int>();

            this.Caminho = CloneIdentifier(possibilidades.Caminho);

            foreach (KeyValuePair<string, int> entry in  possibilidades.Pontos)
            {
                this.Pontos.Add(entry.Key, entry.Value);
            }
        }

        #endregion

        #region Methods

        public void AddAresta(IAresta aresta)
        {
            if (aresta.GetType() != typeof(ArestaJogo))
                throw new Exception("Invalid type: " + aresta.GetType().ToString());

            ArestaJogo data = aresta as ArestaJogo;

            this.Caminho.Add(aresta.VerticeId);

            //foreach (KeyValuePair<string, int> entry in data.Apostas)
            //{
            //    if (this.Pontos.ContainsKey(entry.Key))
            //        this.Pontos[entry.Key] += entry.Value;
            //    else
            //        this.Pontos.Add(entry.Key, entry.Value);
            //}
        }
         
        public IList<IIdentifier> CloneIdentifier (IList<IIdentifier> ids)
        {
            IList<IIdentifier> list = new List<IIdentifier>();

            for (int c = 0; c < ids.Count; c++ )
            {
                list.Add(ids[c]);
            }

            return list;
        }

        public bool IsAlreadyDone (IIdentifier id)
        {
            for (int c=0; c < this.Caminho.Count; c++)
            {
                if (this.Caminho[c].IsEqual(id))
                    return true;
            }
            return false;
        }

        public PossibilidadeJogos Clone()
        {
            PossibilidadeJogos entry = new PossibilidadeJogos();

            entry.Caminho = this.CloneIdentifier(this.Caminho);

            return entry;
        }

        #endregion


    }
}
