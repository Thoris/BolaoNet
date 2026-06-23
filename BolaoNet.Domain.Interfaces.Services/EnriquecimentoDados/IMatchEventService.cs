using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;

namespace BolaoNet.Domain.Interfaces.Services.EnriquecimentoDados
{
    public interface IMatchEventService
        : Base.IGenericService<Entities.EnriquecimentoDados.MatchEvent>
    {
        IList<MatchEvent> GetByMatch(int id);
    }
}
