using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.DataManager
{
    public class MergeJogoJogoUsuario
    {
        #region Methods

        public IList<Entities.EntityJogoUsuario> Execute(IList<Domain.Entities.Campeonatos.Jogo> jogos, IList<Domain.Entities.Boloes.JogoUsuario> jogosUsuarios)
        {
            IList<Entities.EntityJogoUsuario> list = new List<Entities.EntityJogoUsuario>();

            while (jogos.Count > 0)
            {

                int pos = -1;
                for (int c = 0; c < jogosUsuarios.Count; c++)
                {
                    if (jogos[0].JogoId == jogosUsuarios[c].JogoId &&
                        string.Compare(jogos[c].NomeCampeonato, jogosUsuarios[c].NomeCampeonato, true) == 0)
                    {
                        pos = c;
                        break;
                    }
                }

                if (pos != -1)
                {
                    list.Add(new Entities.EntityJogoUsuario(jogos[0], jogosUsuarios[pos]));
                    jogosUsuarios.RemoveAt(pos);
                }

                jogos.RemoveAt(0);

            }

            return list;
        }
        #endregion
    }
}
