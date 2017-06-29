using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoHistoricoDao : Base.IGenericDao<Entities.Campeonatos.CampeonatoHistorico>
    {
        IList<Entities.Campeonatos.CampeonatoHistorico> LoadCampeoes(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Campeonato campeonato);
    }
}
