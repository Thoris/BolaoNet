using BolaoNet.Application.Reports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.DataManager
{
    public class MergeApostasApostasUsuario
    {
        #region Methods

        public IList<EntityApostasExtras> Execute(IList<Domain.Entities.Boloes.ApostaExtra> apostas, IList<Domain.Entities.Boloes.ApostaExtraUsuario> apostasUsuarios)
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
