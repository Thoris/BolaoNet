using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.EnriquecimentoDados
{
    public class TeamAliasRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.EnriquecimentoDados.TeamAlias>, Domain.Interfaces.Repositories.EnriquecimentoDados.ITeamAliasRepositoryDao
    {

        #region Constructors/Destructors

        public TeamAliasRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public async Task<List<TeamAlias>> GetByApiName(string apiName)
        {
            return base.GetList(x => x.ApiName == apiName).ToList();
        }

        public async Task<List<TeamAlias>> GetByLocalName(string localName)
        {
            return base.GetList(x => x.LocalName == localName).ToList();
        }

        #endregion
    }
}
