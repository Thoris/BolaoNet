using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Facade
{
    public class UserFacadeService 
        : Interfaces.Services.Facade.IUserFacadeService
    {
        #region Variables


        private string _currentUserName;
        private Interfaces.Services.Users.IUserService _userService;
        private Interfaces.Services.Users.IUserInRoleService _userInRoleService;
        private Interfaces.Services.Boloes.IBolaoRequestService _bolaoRequestService;

        #endregion

        #region Constructors/Destructors

        public UserFacadeService(string userName, 
            Interfaces.Services.Users.IUserService userService, 
            Interfaces.Services.Users.IUserInRoleService userInRoleService, 
            Interfaces.Services.Boloes.IBolaoRequestService bolaoRequestService)
        {
            _userService = userService;
            _userInRoleService = userInRoleService;
            _bolaoRequestService = bolaoRequestService;

            _currentUserName = userName;
        }

        #endregion

        #region IUserFacadeBO members

        public bool CreateUser(Entities.Users.User user, params Entities.Users.Role[] roles)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentException("user.Email");

            user.ActivateKey = GenerateActivationCode(user);

            long res = _userService.Insert(user);

            if (roles != null)
            {
                for (int c=0; c < roles.Length; c++)
                {
                    _userInRoleService.Insert(new Entities.Users.UserInRole(user.UserName, roles[c].RoleName));
                }
            }


            if (res > 0)
                return true;
            else
                return false;

        }
        public string GenerateActivationCode(Entities.Users.User user)
        {
            string result = "";

            result = user.UserName + "|" + user.Email;

            return result;
        }

        public bool SendActivationCode(Entities.Users.User user)
        {
            return true;
        }

        public bool ActivateUser(Entities.Users.User user, string activationCode)
        {
            Entities.Users.User userLoaded = _userService.Load(user);

            if (string.Compare(userLoaded.ActivateKey, activationCode, true) != 0)
                throw new Exception("Activation Code is not valid");

            userLoaded.IsApproved = true;
            userLoaded.IsLockedOut = false;
            userLoaded.ApprovedDate = DateTime.Now;
            userLoaded.ApprovedBy = _currentUserName;

            return _userService.Update(userLoaded);

        }
        public bool SendRequestUserBolao(Entities.Users.User user, Entities.Boloes.Bolao bolao)
        {
            return true;
        }




        public bool ApproveRequestUserBolao(Entities.Boloes.BolaoRequest request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
