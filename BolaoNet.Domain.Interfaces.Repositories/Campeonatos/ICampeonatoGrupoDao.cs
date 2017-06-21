using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoGrupoDao : Base.IGenericDao<Entities.Campeonatos.CampeonatoGrupo>
    {
        IList<Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(string currentUserName, Entities.Campeonatos.Campeonato campeonato);
    }
}
