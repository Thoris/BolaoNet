using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.DadosBasicos
{
    public interface IPagamentoTipoApp
        : Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService,
        Base.IGenericApp<Domain.Entities.DadosBasicos.PagamentoTipo>
    {
    }
}
