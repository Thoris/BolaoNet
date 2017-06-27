using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoMembroService
        : Base.IGenericService<Entities.Boloes.BolaoMembro>
    {

        IList<Entities.Boloes.BolaoMembro> GetListUsersInBolao(Entities.Boloes.Bolao bolao);
        IList<Entities.Boloes.BolaoMembro> GetListBolaoInUsers(Entities.Users.User user);
    }
}
