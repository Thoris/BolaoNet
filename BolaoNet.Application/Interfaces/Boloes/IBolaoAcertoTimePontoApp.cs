using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoAcertoTimePontoApp :
        Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoAcertoTimePonto>
    {
    }
}
