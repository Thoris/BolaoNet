using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Boloes
{
    public interface IBolaoCriterioPontosBO : Base.IGenericBusiness<Entities.Boloes.BolaoCriterioPontos>
    {
        int[] GetCriteriosPontos(Entities.Boloes.Bolao bolao);
        IList<Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao);
    }
}
