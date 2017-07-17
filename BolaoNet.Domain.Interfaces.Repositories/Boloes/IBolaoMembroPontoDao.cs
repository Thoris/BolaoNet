using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoMembroPontoDao : Base.IGenericDao<Entities.Boloes.BolaoMembroPonto>
    {
        IList<Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(string currentUserName, DateTime currentDateTime,
            Entities.Boloes.Bolao bolao, Entities.Users.User user);

    }
}
