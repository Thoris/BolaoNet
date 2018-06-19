using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.ReadValidate
{
    public class ResultadoAgrupamento
    {
        #region Variables

        private IList<ResultadoJogo> _jogos;
        private IList<ResultadoPosicao> _posicao;

        #endregion

        #region Properties

        public IList<ResultadoJogo> Jogos 
        { 
            get { return _jogos; }
            set { _jogos = value; }
        }
        public IList<ResultadoPosicao> Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        
        #endregion

        #region Constructors/Destructors

        public ResultadoAgrupamento()
        {
            _posicao = new List<ResultadoPosicao>();
            _jogos = new List<ResultadoJogo>();
        }

        #endregion

        #region Methods

        public void AddAresta(Grafo.Domain.ArestaJogo aresta)
        {

        }

        public void Calcular(bool ultimo, params int [] posicoes)
        {
            OrdenarPontuacao();
            ManterPosicoes(ultimo, posicoes);
        }

        public void OrdenarPontuacao()
        {
            IList<ResultadoPosicao> pt = _posicao.OrderByDescending(x => x.Pontos).ToList<ResultadoPosicao>();

            int pos = 0;
            int pontos = -1;

            for (int c = 0; c < pt.Count; c++ )
            {
                if (pt[c].Pontos != pontos)
                {
                    pontos = pt[c].Pontos;
                    pos++;
                    pt[c].Posicao = pos;
                }
            }

            _posicao = pt;
        }
        public void ManterPosicoes(bool ultimo, params int [] posicao)
        {
            int posUltimo = _posicao[_posicao.Count - 1].Posicao;

            for (int c=_posicao.Count-1; c >= 0; c-- )
            {
                 if (posUltimo != _posicao[c].Posicao)
                 {
                     bool found = false;
                     for (int i = 0; i < posicao.Length; i++)
                     {
                         if (posicao[i] == _posicao[c].Posicao)
                         {
                             found = true;
                             break;
                         }
                     }

                     if (!found)
                     {
                         _posicao.RemoveAt(c);
                         c++;
                     }
                 }
            }
        }

        #endregion
    }
}
