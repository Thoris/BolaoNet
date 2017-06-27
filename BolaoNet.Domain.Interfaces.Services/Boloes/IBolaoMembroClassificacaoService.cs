using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoMembroClassificacaoService
        : Base.IGenericService<Entities.Boloes.BolaoMembroClassificacao>
    {
        IList<Entities.ValueObjects.BolaoClassificacaoVO> LoadClassificacao(Entities.Boloes.Bolao bolao, int? rodada);
    }
}
