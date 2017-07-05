using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoPosicaoDao : Base.IGenericDao<Entities.Campeonatos.CampeonatoPosicao>
    {
        IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(string currentUserName, DateTime currentDateTime,
            Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase);
    }
}
