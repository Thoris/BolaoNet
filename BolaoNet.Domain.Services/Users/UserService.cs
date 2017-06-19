using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Users
{
    public class UserService :
        Base.BaseGenericService<Entities.Users.User>,
        Interfaces.Services.Users.IUserService
    {
        #region Constructors/Destructors

        public UserService(string userName, Interfaces.Repositories.Users.IUserDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.User>)dao, logging)
        {

        }

        #endregion

        #region IUserService members

        public Entities.Base.Common.Validation.ValidationResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password");

            Entities.Base.Common.Validation.ValidationResult res = new Entities.Base.Common.Validation.ValidationResult();

            Entities.Users.User userLoaded = this.Load(new Entities.Users.User(userName));

            if (userLoaded == null)            
                return new Entities.Base.Common.Validation.ValidationResult().Add("User is not found.");

            if (userLoaded.IsLockedOut)
                return new Entities.Base.Common.Validation.ValidationResult().Add("User is locked.");

            if (!userLoaded.IsApproved)
                return new Entities.Base.Common.Validation.ValidationResult().Add("User is not approved.");

            if (string.Compare(password, userLoaded.Password) != 0)
            {
                userLoaded.FailedPasswordAttemptCount ++;
                userLoaded.FailedPasswordAttemptWindowStart = DateTime.Now;

                this.Update(userLoaded);

                return new Entities.Base.Common.Validation.ValidationResult().Add("Password is incorrect.");
            }
            else
            {
                userLoaded.FailedPasswordAttemptCount = 0;
                userLoaded.FailedPasswordAttemptWindowStart = null;
                userLoaded.LastLoginDate = DateTime.Now;

                this.Update(userLoaded);

                return new Entities.Base.Common.Validation.ValidationResult();
            }
        }

        public Entities.Base.Common.Validation.ValidationResult RegisterUser(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");

            if (!user.IsValid())
                return user.ValidationResult;


            Entities.Users.User userLoaded = this.Load(user);

            if (userLoaded != null)
                return new Entities.Base.Common.Validation.ValidationResult().Add("User is already in database.");


            long total = this.Insert(user);

            if (total != 1)
            {
                return user.ValidationResult;
            }
            else
            {
                return new Entities.Base.Common.Validation.ValidationResult();
            }
        }

        public Entities.Base.Common.Validation.ValidationResult ChangePassword(string userName, string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName");
            if (string.IsNullOrEmpty(oldPassword))
                throw new ArgumentException("oldPassword");
            if (string.IsNullOrEmpty(oldPassword))
                throw new ArgumentException("newPassword");
            if (string.IsNullOrEmpty(confirmPassword))
                throw new ArgumentException("confirmPassord");

            if (string.Compare(newPassword, confirmPassword) != 0)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Password confirmation is not valid");


            Entities.Users.User userLoaded = this.Load(new Entities.Users.User(userName));

            if (userLoaded == null)
                return new Entities.Base.Common.Validation.ValidationResult().Add("User is not found");

            if (string.Compare(userLoaded.Password, oldPassword) != 0)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Old password is not the same");


            bool updatedResult = this.Update(userLoaded);

            if (!updatedResult)
                return userLoaded.ValidationResult;


            return new Entities.Base.Common.Validation.ValidationResult();


        }

        public string GenerateActivationCode(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");

            Entities.Users.User userLoaded = this.Load(user);

            if (userLoaded == null)
                throw new Exception("User " + user.UserName + " is not found");

            string activationKey = "teste";

            userLoaded.ActivateKey = activationKey;

            if (!this.Update(userLoaded))
                return null;

            return activationKey;

        }

        public Entities.Base.Common.Validation.ValidationResult ApproveUser(Entities.Users.User user, string activationCode)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");
            if (string.IsNullOrEmpty(activationCode))
                throw new ArgumentException("activationCode");

            Entities.Users.User userLoaded = this.Load(user);

            if (userLoaded == null)
                return new Entities.Base.Common.Validation.ValidationResult().Add("User is not found");

            if (string.Compare(userLoaded.ActivateKey, activationCode) != 0)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Activation code is not valid");

            if (!userLoaded.IsApproved)
            {
                userLoaded.IsApproved = true;
                if (!this.Update(userLoaded))
                    return userLoaded.ValidationResult;
                else
                    return new Entities.Base.Common.Validation.ValidationResult();
            }
            else
            {
                return new Entities.Base.Common.Validation.ValidationResult();
            }

        }

        #endregion
    }
}
