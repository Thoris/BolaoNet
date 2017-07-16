using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Facade
{
    public class InitializationFacadeApp
        : Interfaces.Facade.IInitializationFacadeApp
    {

        #region Variables

        private Domain.Interfaces.Services.Facade.IInitializationFacadeService _service;

        #endregion

        #region Constructors/Destructors

        public InitializationFacadeApp(Domain.Interfaces.Services.Facade.IInitializationFacadeService service)
        {
            _service = service;
        }

        #endregion

        #region IInitializationFacadeApp members

        public bool InitAll()
        {
            return _service.InitAll();
        }

        public int InsertList<T>(Domain.Interfaces.Services.Base.IGenericService<T> bo, IList<T> list)
        {
            return _service.InsertList<T>(bo, list);
        }

        public IList<Domain.Entities.Users.User> GetMainUsers()
        {
            return  _service.GetMainUsers();
        }

        public IList<Domain.Entities.Users.Role> GetRoles()
        {
            return _service.GetRoles();
        }

        public IList<Domain.Entities.Users.UserInRole> GetUsersInRoles()
        {
            return _service.GetUsersInRoles();
        }

        public IList<Domain.Entities.DadosBasicos.CriterioFixo> GetCriteriosFixos()
        {
            return _service.GetCriteriosFixos();
        }

        public IList<Domain.Entities.DadosBasicos.PagamentoTipo> GetPagamentoTipo()
        {
            return _service.GetPagamentoTipo();
        }

        #endregion
    }
}
