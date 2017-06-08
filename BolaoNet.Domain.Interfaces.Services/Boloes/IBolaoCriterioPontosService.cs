using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoCriterioPontosService
        : Base.IGenericService<Entities.Boloes.BolaoCriterioPontos>
    {
        int[] GetCriteriosPontos(Entities.Boloes.Bolao bolao);
        IList<Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao);
    }
}
