using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Boloes
{
    public interface IApostaExtraBO : Base.IGenericBusiness<Entities.Boloes.ApostaExtra>
    {
        IList<Entities.Boloes.ApostaExtra> GetApostasBolao(Entities.Boloes.Bolao bolao);
    }
}
