using BolaoNet.Domain.Interfaces.Services.Logging;

namespace BolaoNet.Domain.Services.EnriquecimentoDados
{
    public class WorldCupMatchService :
        Base.BaseGenericService<Entities.EnriquecimentoDados.WorldCupMatch>,
        Interfaces.Services.EnriquecimentoDados.IWorldCupMatchService
    {

        #region Constructors/Destructors

        public WorldCupMatchService(string userName, Interfaces.Repositories.EnriquecimentoDados.IWorldCupMatchRepositoryDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.EnriquecimentoDados.WorldCupMatch>)dao, logging)
        {

        }

        #endregion
    }
}
