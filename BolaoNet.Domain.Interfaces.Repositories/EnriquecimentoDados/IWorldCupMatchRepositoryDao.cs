using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.EnriquecimentoDados
{
    public interface IWorldCupMatchRepositoryDao : Base.IGenericDao<Entities.EnriquecimentoDados.WorldCupMatch>
    {
        WorldCupMatch GetByExternalId(string externalId);

        IEnumerable<WorldCupMatch> GetWithoutExternalId();
    }
}
