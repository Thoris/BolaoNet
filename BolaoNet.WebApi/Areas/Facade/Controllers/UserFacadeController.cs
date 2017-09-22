using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.WebApi.Areas.Facade.Controllers
{
    public class UserFacadeController : AuthorizationController,
        Domain.Interfaces.Services.Facade.IUserFacadeService
    {
        #region Variables
        
        private Domain.Interfaces.Services.Facade.IUserFacadeService _service;

        #endregion

        #region Constructors/Destructors

        //public UserFacadeController()
        //    //: base(new Domain.Services.FactoryService(null).cre())
        //{
        //    _service = new Domain.Services.FactoryService(null).CreateUserFacadeService();
        //}

        public UserFacadeController(Domain.Interfaces.Services.Facade.IUserFacadeService service)        
        {
            _service = service;
        }

        #endregion

        #region IUserFacadeService members

        [HttpPost]
        public string GenerateActivationCode(Domain.Entities.Users.User user)
        {
            return _service.GenerateActivationCode(user);
        }
        [HttpPost]
        public bool CreateUser(int id, ArrayList data)
        {
            Domain.Entities.Users.User user;
            Domain.Entities.Users.Role[] roles;

            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[0].ToString());
            roles = JsonConvert.DeserializeObject<Domain.Entities.Users.Role[]>(data[1].ToString());

            return this.CreateUser(user, roles);
        }
        [HttpPost]
        public bool CreateUser(Domain.Entities.Users.User user, params Domain.Entities.Users.Role[] roles)
        {
            return _service.CreateUser(user, roles);
        }

        [HttpPost]
        public bool SendActivationCode(Domain.Entities.Users.User user)
        {
            return _service.SendActivationCode(user);
        }
        [HttpPost]
        public bool ActivateUser(int id, ArrayList data)
        {
            Domain.Entities.Users.User user;
            string activationCode;

            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[0].ToString());
            activationCode = JsonConvert.DeserializeObject<string>(data[1].ToString());

            return this.ActivateUser(user, activationCode);
        }

        [HttpPost]
        public bool ActivateUser(Domain.Entities.Users.User user, string activationCode)
        {
            return _service.ActivateUser(user, activationCode);
        }

        [HttpPost]
        public bool SendRequestUserBolao(int id, ArrayList data)
        {
            Domain.Entities.Users.User user;
            Domain.Entities.Boloes.Bolao bolao;

            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[0].ToString());
            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[1].ToString());

            return this.SendRequestUserBolao(user, bolao);
        }
        [HttpPost]
        public bool SendRequestUserBolao(Domain.Entities.Users.User user, Domain.Entities.Boloes.Bolao bolao)
        {
            return _service.SendRequestUserBolao(user, bolao);
        }

        [HttpPost]
        public bool ApproveRequestUserBolao(Domain.Entities.Boloes.BolaoRequest request)
        {
            return _service.ApproveRequestUserBolao(request);
        }

        #endregion
    }
}