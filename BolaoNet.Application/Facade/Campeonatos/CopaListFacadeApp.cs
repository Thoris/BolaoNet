using BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos;
using System.Collections.Generic;

namespace BolaoNet.Application.Facade.Campeonatos
{
    public class CopaListFacadeApp
        : Interfaces.Facade.Campeonatos.ICopaListFacadeApp
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.Campeonatos.ICopaListFacadeService _service;

        #endregion

        #region Constructors/Destructors

        public CopaListFacadeApp(Domain.Interfaces.Services.Facade.Campeonatos.ICopaListFacadeService service)
        {
            _service = service;
        }

        #endregion

        #region ICopaListFacadeApp members

        public ICopaFacadeService GetInstance(string name)
        {
            return _service.GetInstance(name);
        }

        public IList<string> GetNames()
        {
            return _service.GetNames();
        }

        #endregion
    }
}
