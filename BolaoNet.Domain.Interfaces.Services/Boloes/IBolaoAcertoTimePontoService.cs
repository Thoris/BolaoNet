using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoAcertoTimePontoService
        : Base.IGenericService<Entities.Boloes.BolaoAcertoTimePonto>
    {
        Entities.Boloes.BolaoAcertoTimePonto GetByJogoId(Entities.Boloes.Bolao bolao, int jogoId);
    }
}
