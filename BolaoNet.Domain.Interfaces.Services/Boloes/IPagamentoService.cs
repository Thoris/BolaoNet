using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IPagamentoService
        : Base.IGenericService<Entities.Boloes.Pagamento>
    {
        IList<Entities.Boloes.Pagamento> GetPagamentosBolao(Entities.Boloes.Bolao bolao);
        IList<Entities.Boloes.Pagamento> GetPagamentosBolaoSoma(Entities.Boloes.Bolao bolao);
    
    }
}
