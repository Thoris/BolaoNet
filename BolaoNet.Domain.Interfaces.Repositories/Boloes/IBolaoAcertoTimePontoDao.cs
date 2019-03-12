using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoAcertoTimePontoDao : Base.IGenericDao<Entities.Boloes.BolaoAcertoTimePonto>
    {
        Entities.Boloes.BolaoAcertoTimePonto GetByJogoId(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, int jogoId);
    }
}
