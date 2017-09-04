using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoHistoricoApp
        : Domain.Interfaces.Services.Boloes.IBolaoHistoricoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoHistorico>
    {
    }
}
