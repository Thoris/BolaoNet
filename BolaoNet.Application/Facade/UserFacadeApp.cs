using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Facade
{
    public class UserFacadeApp :
        Application.Interfaces.Facade.IUserFacadeApp
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.IUserFacadeService _service;

        #endregion

        #region Constructors/Destructors

        public UserFacadeApp(Domain.Interfaces.Services.Facade.IUserFacadeService service)
        {
            _service = service;
        }

        #endregion

        public string GenerateActivationCode(Domain.Entities.Users.User user)
        {
            return _service.GenerateActivationCode(user);
        }

        public bool CreateUser(Domain.Entities.Users.User user, params Domain.Entities.Users.Role[] roles)
        {
            return _service.CreateUser(user, roles);
        }

        public bool SendActivationCode(Domain.Entities.Users.User user)
        {
            return _service.SendActivationCode(user);
        }

        public bool ActivateUser(Domain.Entities.Users.User user, string activationCode)
        {
            return _service.ActivateUser(user, activationCode);
        }

        public bool SendRequestUserBolao(Domain.Entities.Users.User user, Domain.Entities.Boloes.Bolao bolao)
        {
            return _service.SendRequestUserBolao(user, bolao);
        }

        public bool ApproveRequestUserBolao(Domain.Entities.Boloes.BolaoRequest request)
        {
            return _service.ApproveRequestUserBolao(request);
        }
    }
}
