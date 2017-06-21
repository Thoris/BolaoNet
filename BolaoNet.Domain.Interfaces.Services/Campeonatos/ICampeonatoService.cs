using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoService
        : Base.IGenericService<Entities.Campeonatos.Campeonato>
    {
        IList<int> GetRodadasCampeonato(Entities.Campeonatos.Campeonato campeonato);
    }
}
