using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface ICampeonatoHistoricoApp
        : Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService,
        Base.IGenericApp<Domain.Entities.Campeonatos.CampeonatoHistorico>
    {
    }
}
