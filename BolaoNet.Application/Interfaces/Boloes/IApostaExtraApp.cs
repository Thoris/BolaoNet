using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IApostaExtraApp 
        : Domain.Interfaces.Services.Boloes.IApostaExtraService,
        Base.IGenericApp<Domain.Entities.Boloes.ApostaExtra>
    {

    }
}
