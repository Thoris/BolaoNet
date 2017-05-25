using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.PDF
{
    public class BasePdfManager
    {
        #region Constructors/Destructors

        public BasePdfManager()
        {

        }

        #endregion

        #region Methods

        public IList<EntityJogoUsuario> MergeJogoJogoUsuario(IList<Entities.Campeonatos.Jogo> jogos, IList<Entities.Boloes.JogoUsuario> jogosUsuarios)
        {
            IList<EntityJogoUsuario> list = new List<EntityJogoUsuario>();

            while (jogos.Count > 0)
            {

                int pos = -1;
                for (int c=0; c < jogosUsuarios.Count; c++)
                {
                    if (jogos[0].JogoId == jogosUsuarios[c].JogoId && 
                        string.Compare (jogos[c].NomeCampeonato, jogosUsuarios[c].NomeCampeonato, true) == 0)
                    {
                        pos = c;
                        break;
                    }
                }

                if (pos != -1)
                {
                    list.Add(new EntityJogoUsuario(jogos[0], jogosUsuarios[pos]));
                    jogosUsuarios.RemoveAt(pos);
                }

                jogos.RemoveAt(0);
                
            }

            return list;
        }
        public IList<EntityApostasExtras> MergeApostasApostasUsuario(IList<Entities.Boloes.ApostaExtra> apostas, IList<Entities.Boloes.ApostaExtraUsuario> apostasUsuarios)
        {
            IList<EntityApostasExtras> list = new List<EntityApostasExtras>();

            while (apostas.Count > 0)
            {

                int pos = -1;
                for (int c = 0; c < apostasUsuarios.Count; c++)
                {
                    if (apostas[0].Posicao == apostasUsuarios[c].Posicao &&
                        string.Compare(apostas[c].NomeBolao, apostasUsuarios[c].NomeBolao, true) == 0)
                    {
                        pos = c;
                        break;
                    }
                }

                if (pos != -1)
                {
                    list.Add(new EntityApostasExtras(apostas[0], apostasUsuarios[pos]));
                    apostasUsuarios.RemoveAt(pos);
                }

                apostas.RemoveAt(0);

            }

            return list;
        }

        #endregion
    }
}
