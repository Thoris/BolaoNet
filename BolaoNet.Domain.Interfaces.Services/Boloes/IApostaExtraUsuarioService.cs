using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IApostaExtraUsuarioService
        : Base.IGenericService<Entities.Boloes.ApostaExtraUsuario>
    {
        IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(Entities.Boloes.Bolao bolao, Entities.Users.User user);

    }
}
