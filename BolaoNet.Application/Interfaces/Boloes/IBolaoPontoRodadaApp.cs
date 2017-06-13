using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoPontoRodadaApp
        : Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoPontoRodada>
    {
    }
}
