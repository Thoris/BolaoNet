using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoRequestStatusApp
        : Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoRequestStatus>
    {
    }
}
