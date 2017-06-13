using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoCampeonatoClassificacaoUsuarioApp
        : Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>
    {
    }
}
