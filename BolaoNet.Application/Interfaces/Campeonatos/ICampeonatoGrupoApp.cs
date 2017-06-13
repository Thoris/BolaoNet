using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface ICampeonatoGrupoApp
        : Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService,
        Base.IGenericApp<Domain.Entities.Campeonatos.CampeonatoGrupo>
    {
    }
}
