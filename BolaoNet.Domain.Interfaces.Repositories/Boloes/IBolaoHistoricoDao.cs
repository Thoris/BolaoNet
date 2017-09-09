using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoHistoricoDao : Base.IGenericDao<Entities.Boloes.BolaoHistorico>
    {
        IList<Domain.Entities.Boloes.BolaoHistorico> GetListFromBolao(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, int ano);

        IList<int> GetYearsFromBolao(string currentName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);
    }
}
