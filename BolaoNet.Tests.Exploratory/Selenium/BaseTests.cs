using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Selenium
{
    public class BaseTests
    {

        #region Variáveis

        private IWebDriver _driver;

        #endregion

        #region Propriedades

        protected IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        #endregion

        #region Construtores/Destrutores



        /// <summary>
        /// Inicializa dados da instância.
        /// </summary>
        //[TestFixtureSetUp]
        public void Init()
        {
            //_driver = new DriverFactory().CreateDriver();
            //LogOn();

            if (_driver == null)
            {
                _driver = new DriverFactory().CreateDriver();
                LogOn();
            }

        }
        /// <summary>
        /// Finaliza objetos da classe.
        /// </summary>
        //[TestFixtureTearDown]
        public void End()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver = null;
            }
        }


        public BaseTests()
        {

        }

        #endregion

        #region Métodos

        protected Pages.Users.HomePage LogOn()
        {
            Pages.LoginPage login = new Pages.LoginPage(_driver);
            login.OpenLoginPage();
            return (Pages.Users.HomePage)login.Logon();
        }

        #endregion
    }
}
