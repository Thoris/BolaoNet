using System.Collections.Generic;

namespace BolaoNet.Application.Facade.Boloes
{
    public class BolaoListFacadeApp
        : Interfaces.Facade.Boloes.IBolaoListFacadeApp
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.Boloes.IBolaoListFacadeService _service;

        #endregion

        #region Constructors/Destructors

        public BolaoListFacadeApp(Domain.Interfaces.Services.Facade.Boloes.IBolaoListFacadeService service)
        {
            _service = service;
        }

        #endregion

        #region ICopaListFacadeApp members

        public Domain.Interfaces.Services.Facade.Boloes.IBolaoFacadeService GetInstance(string name)
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
