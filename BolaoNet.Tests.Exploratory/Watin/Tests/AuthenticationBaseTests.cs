using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin.Tests
{
    public abstract class AuthenticationPage : BaseTests
    {
        #region Properties
        protected string UserName
        {
            get
            {
                string data = ConfigurationManager.AppSettings["WebTestUserName"];

                if (string.IsNullOrEmpty(data))
                {
                    return Constants.UserName;
                }

                return data;
            }
        }
        protected string Password
        {
            get
            {
                string data = ConfigurationManager.AppSettings["WebTestPassword"];

                if (string.IsNullOrEmpty(data))
                {
                    return Constants.Password;
                }

                return data;
            }
        }
        #endregion

        #region Constructors/Destructors

        public AuthenticationPage()
            : base ()
        {

        }

        #endregion

        #region Methods
         

        #endregion
    }
}
