using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class UserController:
        GenericApiController<Domain.Entities.Users.User>, 
        Domain.Interfaces.Services.Users.IUserService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Users.IUserService Service
        {
            get { return (Domain.Interfaces.Services.Users.IUserService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public UserController()
        //    : base(new Domain.Services.FactoryService(null).CreateUserService())
        //{

        //}
        public UserController(Domain.Interfaces.Services.Users.IUserService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IUserService members

        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult Login(int id, ArrayList data)
        {
            string userName = data[0].ToString();
            string password = data[1].ToString();

            return this.Login(userName, password);
        }
        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult Login(string userName, string password)
        {
            return Service.Login(userName, password);
        }

        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult RegisterUser(Domain.Entities.Users.User user)
        {
            return Service.RegisterUser(user);
        }

        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult ChangePassword(int id, ArrayList data)
        {
            string userName = data[0].ToString();
            string oldPassword = data[1].ToString();
            string newPassword = data[2].ToString();
            string confirmPassword = data[3].ToString();

            return ChangePassword(userName, oldPassword, newPassword, confirmPassword);
        }

        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult ChangePassword(string userName, string oldPassword, string newPassword, string confirmPassord)
        {
            return Service.ChangePassword(userName, oldPassword, newPassword, confirmPassord);
        }

        [HttpPost]
        public string GenerateActivationCode(Domain.Entities.Users.User user)
        {
            return Service.GenerateActivationCode(user);
        }
        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult ApproveUser(int id, ArrayList data)
        {
            Domain.Entities.Users.User user = JsonConvert.DeserializeObject < Domain.Entities.Users.User >( data[0].ToString());
            string activationCode = data[1].ToString();

            return ApproveUser(user, activationCode);
        }

        [HttpPost]
        public Domain.Entities.Base.Common.Validation.ValidationResult ApproveUser(Domain.Entities.Users.User user, string activationCode)
        {
            return Service.ApproveUser(user, activationCode);
        }
        [HttpPost]
        public IList<Domain.Entities.Users.User> SearchByUserNameEmail(int id, ArrayList data)
        {
            string userName;
            string email;

            userName = data[0].ToString();
            email = data[1].ToString();

            return Service.SearchByUserNameEmail(userName, email);
        }

        [HttpPost]
        public IList<Domain.Entities.Users.User> SearchByUserNameEmail(string userName, string email)
        {
            return Service.SearchByUserNameEmail(userName, email);
        }

        #endregion


    }
}