using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        #region Variables

        private IWebDriver _driver;

        #endregion

        #region Properties

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

        #region Constructors/Destructors



        /// <summary>
        /// Inicializa dados da instância.
        /// </summary>
        //[TestFixtureSetUp]
        //[ClassInitialize]
        [TestInitialize]
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
        //[ClassCleanup]
        [TestCleanup]
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

        #region Methods

        protected Pages.Users.HomePage LogOn()
        {
            Pages.LoginPage login = new Pages.LoginPage(_driver);
            login.OpenLoginPage();
            return (Pages.Users.HomePage)login.Logon();
        }

        #endregion
    }
}
