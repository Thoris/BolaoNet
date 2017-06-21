using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoDao : Base.IGenericDao<Entities.Campeonatos.Campeonato>
    {
        IList<int> GetRodadasCampeonato(string currentUserName, Entities.Campeonatos.Campeonato campeonato);
    }
}
