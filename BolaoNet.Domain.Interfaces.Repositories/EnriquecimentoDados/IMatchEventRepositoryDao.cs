using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;

namespace BolaoNet.Domain.Interfaces.Repositories.EnriquecimentoDados
{
    public interface IMatchEventRepositoryDao : Base.IGenericDao<Entities.EnriquecimentoDados.MatchEvent>
    { 
        List<MatchEvent> GetByMatchExternalId(string externalId);
        List<MatchEvent> GetByMatchId(int matchId);
    }
}
