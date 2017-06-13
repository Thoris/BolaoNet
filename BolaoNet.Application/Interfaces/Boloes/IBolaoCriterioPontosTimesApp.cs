using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoCriterioPontosTimesApp
        : Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoCriterioPontosTimes>
    {
      
    }
}
