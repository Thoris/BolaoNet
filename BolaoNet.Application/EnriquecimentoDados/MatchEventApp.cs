using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Collections.Generic;

namespace BolaoNet.Application.EnriquecimentoDados
{
    public class MatchEventApp :
            Base.GenericApp<Domain.Entities.EnriquecimentoDados.MatchEvent>,
        Application.Interfaces.EnriquecimentoDados.IMatchEventApp
    {
        #region Properties

        private Domain.Interfaces.Services.EnriquecimentoDados.IMatchEventService Service
        {
            get { return (Domain.Interfaces.Services.EnriquecimentoDados.IMatchEventService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        public MatchEventApp(Domain.Interfaces.Services.EnriquecimentoDados.IMatchEventService service)
            : base(service)
        {

        }

        public IList<MatchEvent> GetByMatch(int id)
        {
            return this.Service.GetByMatch(id);
        }

        #endregion
    }
}
