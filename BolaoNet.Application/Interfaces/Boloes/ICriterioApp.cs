using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface ICriterioApp
        : Domain.Interfaces.Services.Boloes.ICriterioService,
        Base.IGenericApp<Domain.Entities.Boloes.Criterio>
    {
    }
}
