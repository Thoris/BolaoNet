using System.Collections.Generic;

namespace BolaoNet.Application.Interfaces.EnriquecimentoDados
{
    public interface IMatchEventApp
        : Domain.Interfaces.Services.EnriquecimentoDados.IMatchEventService,
        Base.IGenericApp<Domain.Entities.EnriquecimentoDados.MatchEvent>
    {
        IList<Domain.Entities.EnriquecimentoDados.MatchEvent> GetByMatch(int id);
    }
}
