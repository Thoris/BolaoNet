using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Watin.Pages
{
    public class AuthenticationPage : BasePage
    {
        #region Properties

        protected string UserName
        {
            get
            {
                string data = ConfigurationManager.AppSettings["WebTestUserName"];

                if (string.IsNullOrEmpty(data))
                {
                    return "usuario0x0";
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
                    return "thoris";
                }

                return data;
            }
        }


        #endregion

        #region Constructors/Destructors

        public AuthenticationPage(string controllerPage)
            : base (controllerPage)
        {

        }

        #endregion

        #region Methods

        public void Logon()
        {

        }

        #endregion

    }
}
