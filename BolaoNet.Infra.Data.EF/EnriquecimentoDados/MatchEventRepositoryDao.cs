using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;
using System.Linq;

namespace BolaoNet.Infra.Data.EF.EnriquecimentoDados
{
    public class MatchEventRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.EnriquecimentoDados.MatchEvent>, Domain.Interfaces.Repositories.EnriquecimentoDados.IMatchEventRepositoryDao
    {

        #region Constructors/Destructors

        public MatchEventRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<MatchEvent> GetByMatchExternalId(string externalId)
        {
            var data = base.GetList( x => x.ExternalId == externalId).ToList();
            return data;
        }

        public List<MatchEvent> GetByMatchId(int matchId)
        {
            var data = base.GetList(x => x.MatchKeyId == matchId).ToList();
            return data;
        }


        #endregion
    }
}
