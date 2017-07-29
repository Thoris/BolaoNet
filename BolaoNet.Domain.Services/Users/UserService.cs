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
        #region Properties

        private Interfaces.Repositories.Users.IUserDao BaseDao
        {
            get { return (Interfaces.Repositories.Users.IUserDao)base.BaseDao; }
        }
        #endregion

        #region Constructors/Destructors

        public UserService(string userName, Interfaces.Repositories.Users.IUserDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Users.User>)dao, logging)
        {

        }

        #endregion

        #region Methods

        private string ConvertFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return "";

            string res = fullName.Substring (0,1).ToUpper ();
            bool foundBlank = false;
            for (int c=1; c < fullName.Length; c++)
            {
                if (fullName[c] == ' ')
                {
                    foundBlank = true;
                    res += fullName[c];
                }
                else
                {
                    if (foundBlank)
                    {
                        foundBlank = false;
                        res += fullName[c].ToString().ToUpper();
                    }
                    else
                    {
                        res += fullName[c].ToString ().ToLower ();
                    }
                }
            }

            return res;
            
        }

        #endregion

        #region IUserService members

        public Entities.Base.Common.Validation.ValidationResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password");

            if (IsSaveLog)
                CheckStart();

            Entities.Base.Common.Validation.ValidationResult res = new Entities.Base.Common.Validation.ValidationResult();

            Entities.Users.User userLoaded = this.Load(new Entities.Users.User(userName));

            if (userLoaded == null)            
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário não encontrado.");

            if (userLoaded.IsLockedOut)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário bloqueado.");

            if (!userLoaded.IsApproved)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário ainda não ativado.");

            if (string.Compare(password, userLoaded.Password) != 0)
            {
                userLoaded.FailedPasswordAttemptCount ++;
                userLoaded.FailedPasswordAttemptWindowStart = DateTime.Now;

                this.Update(userLoaded);

                return new Entities.Base.Common.Validation.ValidationResult().Add("Senha incorreta.");
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

            if (IsSaveLog)
                CheckStart();

            if (!user.IsValid())
                return user.ValidationResult;


            Entities.Users.User userLoaded = this.Load(user);

            if (userLoaded != null)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário já existente.");


            user.UserName = user.UserName.ToLower();
            user.Email = user.Email.ToLower();
            user.FullName = ConvertFullName(user.FullName);

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
                return new Entities.Base.Common.Validation.ValidationResult().Add("Confirmação de senha inválida.");


            if (IsSaveLog)
                CheckStart();

            Entities.Users.User userLoaded = this.Load(new Entities.Users.User(userName));

            if (userLoaded == null)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário não encontrado.");

            if (string.Compare(userLoaded.Password, oldPassword) != 0)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Senha antiga não confere.");


            bool updatedResult = this.Update(userLoaded);

            if (!updatedResult)
                return userLoaded.ValidationResult;


            return new Entities.Base.Common.Validation.ValidationResult();


        }

        public string GenerateActivationCode(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");

            if (IsSaveLog)
                CheckStart();

            Entities.Users.User userLoaded = this.Load(user);

            if (userLoaded == null)
                throw new Exception("Usuário " + user.UserName + " não encontrado.");

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

            if (IsSaveLog)
                CheckStart();
            Entities.Users.User userLoaded = this.Load(user);

            if (userLoaded == null)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário não encontrado.");

            if (userLoaded.IsApproved)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Usuário já está aprovado.");

            if (string.Compare(userLoaded.ActivateKey, activationCode) != 0)
                return new Entities.Base.Common.Validation.ValidationResult().Add("Código de ativação inválido.");

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

        public IList<Entities.Users.User> SearchByUserNameEmail(string userName, string email)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName");
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Users.User> res = BaseDao.SearchByUserNameEmail(base.CurrentUserName, userName, email);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de usuários por email [" + email + "] usuario [" + userName + "] total: " + res.Count));
            }

            return res;
        }

        #endregion
    }
}
