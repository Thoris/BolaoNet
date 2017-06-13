using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoRequestApp
        : Domain.Interfaces.Services.Boloes.IBolaoRequestService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoRequest>
    {
    }
}
