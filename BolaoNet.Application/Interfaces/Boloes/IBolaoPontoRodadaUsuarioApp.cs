using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoPontoRodadaUsuarioApp
        : Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoPontoRodadaUsuario>
    {
    }
}
