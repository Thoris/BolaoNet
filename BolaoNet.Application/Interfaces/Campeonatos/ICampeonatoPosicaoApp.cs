using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface ICampeonatoPosicaoApp
        : Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService,
        Base.IGenericApp<Domain.Entities.Campeonatos.CampeonatoPosicao>
    {
    }
}
