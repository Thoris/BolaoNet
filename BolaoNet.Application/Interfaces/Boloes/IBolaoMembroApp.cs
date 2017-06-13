using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoMembroApp
        : Domain.Interfaces.Services.Boloes.IBolaoMembroService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoMembro>
    {

    }
}
