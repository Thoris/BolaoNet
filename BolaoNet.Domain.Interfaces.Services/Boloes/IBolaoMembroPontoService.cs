using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoMembroPontoService :
        Base.IGenericService<Entities.Boloes.BolaoMembroPonto>
    {
        IList<Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(Entities.Boloes.Bolao bolao, Entities.Users.User user);
    }
}
