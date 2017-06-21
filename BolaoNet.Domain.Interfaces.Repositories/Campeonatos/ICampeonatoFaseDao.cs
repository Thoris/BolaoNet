using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoFaseDao : Base.IGenericDao<Entities.Campeonatos.CampeonatoFase>
    {
        IList<Entities.Campeonatos.CampeonatoFase> GetFasesCampeonato(string currentUserName, Entities.Campeonatos.Campeonato campeonato);
    }
}
