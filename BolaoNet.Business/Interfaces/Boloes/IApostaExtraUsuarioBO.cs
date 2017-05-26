using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Boloes
{
    public interface IApostaExtraUsuarioBO : Base.IGenericBusiness<Entities.Boloes.ApostaExtraUsuario>
    {
        IList<Entities.Boloes.ApostaExtraUsuario> GetApostasUser(Entities.Boloes.Bolao bolao, Entities.Users.User user);

    }
}
