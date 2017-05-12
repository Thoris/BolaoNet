using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Boloes
{
    public interface IBolaoCriterioPontosTimesBO : Base.IGenericBusiness<Entities.Boloes.BolaoCriterioPontosTimes>
    {
        IList<Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao);
    }
}
