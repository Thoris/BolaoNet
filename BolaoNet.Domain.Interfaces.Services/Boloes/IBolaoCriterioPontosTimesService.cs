using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoCriterioPontosTimesService
        : Base.IGenericService<Entities.Boloes.BolaoCriterioPontosTimes>
    {
        IList<Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao);

    }
}
