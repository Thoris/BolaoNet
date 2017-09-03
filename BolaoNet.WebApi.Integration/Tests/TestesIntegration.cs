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
            throw new NotImplementedException();
        }

        public DateTime GetCurrentDateTime()
        {
            throw new NotImplementedException();
        }
        public bool TestNotifyWelcome(string password, string email)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
