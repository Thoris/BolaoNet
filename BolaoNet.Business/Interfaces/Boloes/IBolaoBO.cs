using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Boloes
{
    public interface IBolaoBO : Base.IGenericBusiness<Entities.Boloes.Bolao>
    {
        bool Iniciar(Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao);
        bool Aguardar(Entities.Boloes.Bolao bolao);

    }
}
