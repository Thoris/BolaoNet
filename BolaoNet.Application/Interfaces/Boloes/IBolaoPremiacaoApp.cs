using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoPremiacaoApp
        : Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoPremiacao>
    {
    }
}
