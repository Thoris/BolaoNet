using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.EnriquecimentoDados
{
    public class WorldCupMatchRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.EnriquecimentoDados.WorldCupMatch>, Domain.Interfaces.Repositories.EnriquecimentoDados.IWorldCupMatchRepositoryDao
    {

        #region Constructors/Destructors

        public WorldCupMatchRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        public WorldCupMatch GetByExternalId(string externalId)
        {
            var res = (base.GetList(x => x.ExternalId == externalId));
            if (res != null && res.Count > 0)
                return res.FirstOrDefault();
            return null;
        }

        public IEnumerable<WorldCupMatch> GetWithoutExternalId()
        {
            return base.GetList( x=> x.ExternalId == null); 
        }
    

    }
}
