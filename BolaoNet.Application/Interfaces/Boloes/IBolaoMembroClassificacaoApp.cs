using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoMembroClassificacaoApp
        : Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoMembroClassificacao>
    {
    }
}
