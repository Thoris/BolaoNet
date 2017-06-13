using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoCriterioPontosApp
        : Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoCriterioPontos>
    {
    }
}
