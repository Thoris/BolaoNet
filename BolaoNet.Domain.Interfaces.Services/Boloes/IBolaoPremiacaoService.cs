using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoPremiacaoService
        : Base.IGenericService<Entities.Boloes.BolaoPremiacao>
    {
        IList<Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(Entities.Boloes.Bolao bolao);
    }
}
