using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoPosicaoService
        : Base.IGenericService<Entities.Campeonatos.CampeonatoPosicao>
    {
        IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetPosicao(Domain.Entities.Campeonatos.Campeonato campeonato, 
            Domain.Entities.Campeonatos.CampeonatoFase fase);
    }
}
