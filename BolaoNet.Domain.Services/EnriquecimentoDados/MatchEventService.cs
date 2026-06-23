using BolaoNet.Domain.Entities.EnriquecimentoDados;
using BolaoNet.Domain.Interfaces.Services.Logging;
using System.Collections.Generic;

namespace BolaoNet.Domain.Services.EnriquecimentoDados
{
    public class MatchEventService :
        Base.BaseGenericService<Entities.EnriquecimentoDados.MatchEvent>,
        Interfaces.Services.EnriquecimentoDados.IMatchEventService
    {

        #region Constructors/Destructors

        public MatchEventService(string userName, Interfaces.Repositories.EnriquecimentoDados.IMatchEventRepositoryDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.EnriquecimentoDados.MatchEvent>)dao, logging)
        {

        }

        public IList<MatchEvent> GetByMatch(int id)
        {
            return ((Interfaces.Repositories.EnriquecimentoDados.IMatchEventRepositoryDao)this.BaseDao).GetByMatchId(id);
        }

        #endregion
    }
}
