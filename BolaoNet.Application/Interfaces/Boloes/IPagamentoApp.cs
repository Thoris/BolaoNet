using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IPagamentoApp
        : Domain.Interfaces.Services.Boloes.IPagamentoService,
        Base.IGenericApp<Domain.Entities.Boloes.Pagamento>
    {
    }
}
