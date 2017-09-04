using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IMensagemService
        : Base.IGenericService<Entities.Boloes.Mensagem>
    {
        IList<Entities.Boloes.Mensagem> GetMensagensUsuario(Entities.Boloes.Bolao bolao, Entities.Users.User user);

    }
}
