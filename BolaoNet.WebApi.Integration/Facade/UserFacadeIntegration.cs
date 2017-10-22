using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Facade
{
    public class UserFacadeIntegration : Base.JsonManagement,
        Domain.Interfaces.Services.Facade.IUserFacadeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "UserFacade";

        #endregion
        
        #region Constructors/Destructors

        public UserFacadeIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IUserFacadeService members

        public string GenerateActivationCode(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<string>(new Dictionary<string, string>(), user, "GenerateActivationCode");
        }

        public bool CreateUser(Domain.Entities.Users.User user, params Domain.Entities.Users.Role[] roles)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("user", user);
            parameters.Add("roles", roles);

            return base.HttpPostApi<bool>(parameters, "CreateUser");
        }

        public bool SendActivationCode(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<bool>(new Dictionary<string, string>(), user, "SendActivationCode");
           
        }

        public bool ActivateUser(Domain.Entities.Users.User user, string activationCode)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("user", user);
            parameters.Add("activationCode", activationCode);

            return base.HttpPostApi<bool>(parameters, "ActivateUser");
        }

        public bool SendRequestUserBolao(Domain.Entities.Users.User user, Domain.Entities.Boloes.Bolao bolao)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("user", user);
            parameters.Add("bolao", bolao);

            return base.HttpPostApi<bool>(parameters, "SendRequestUserBolao");
        }

        public bool ApproveRequestUserBolao(Domain.Entities.Boloes.BolaoRequest request)
        {

            return base.HttpPostApi<bool>(new Dictionary<string, string>(), request, "ApproveRequestUserBolao");
        }

        #endregion
    }
}
