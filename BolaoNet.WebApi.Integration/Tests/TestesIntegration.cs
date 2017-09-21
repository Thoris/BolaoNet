using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Tests
{
    public class TestesIntegration : Base.JsonManagement,
        Domain.Interfaces.Services.Testes.ITesteService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Teste";

        #endregion
        
        #region Constructors/Destructors

        public TestesIntegration(string url)
            : base(url, ModuleName)
        {

        }

        #endregion

        #region ITesteService members

        public bool TestConnection()
        {
            return base.HttpPostApi<bool>(
                 new Dictionary<string, object>(), "TestConnection");
        }

        public DateTime GetCurrentDateTime()
        {
            return base.HttpPostApi<DateTime>(
                 new Dictionary<string, object>(), "GetCurrentDateTime");
        }
        public bool TestNotifyWelcome(string password, string email)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("password", password);
            parameters.Add("email", email); 

            return HttpPostApi<bool>(
                parameters, "TestNotifyWelcome");
        }

        #endregion
    }
}
