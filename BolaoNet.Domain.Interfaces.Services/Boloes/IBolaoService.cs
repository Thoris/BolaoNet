using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoService
        : Base.IGenericService<Entities.Boloes.Bolao>
    {
        bool Iniciar(Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao);
        bool Aguardar(Entities.Boloes.Bolao bolao);

    }
}
