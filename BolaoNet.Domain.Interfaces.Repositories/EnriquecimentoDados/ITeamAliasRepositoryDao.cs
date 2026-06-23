using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.EnriquecimentoDados
{
    public interface ITeamAliasRepositoryDao : Base.IGenericDao<Entities.EnriquecimentoDados.TeamAlias>
    {
        Task<List<TeamAlias>> GetByLocalName(string localName);
        Task<List<TeamAlias>> GetByApiName(string apiName);
    }
}
