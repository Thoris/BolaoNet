using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoPontuacaoApp
        : Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoPontuacao>
    {
    }
}
