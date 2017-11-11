using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin.Tests
{
    [TestClass]
    public class LoginLogoutTests : AuthenticationPage
    {
        #region Constructors/Destructors

        public LoginLogoutTests()
            : base()
        {

        }
        [TestInitialize]
        public void Init()
        {
            base.Browser = new BrowserFactory().CreateBrowser();

        }
        [TestCleanup]
        public void End()
        {
            base.Browser.Close();

        }

        #endregion

        #region Methods

        [TestMethod]
        public void Login_and_logout_Tests()
        {
            Browser.GoTo(Browser.Page<Exploratory.Watin.Pages.LoginPage>().ControllerSite);
            Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.LoginPage>().IsValidPage());


            Browser.Page<Exploratory.Watin.Pages.LoginPage>().Logon(this.UserName, this.Password, false);
            Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Users.HomePage>().IsValidPage());


            Browser.Page<Exploratory.Watin.Pages.Users.HomePage>().SairButton.Click();
            Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.LoginPage>().IsValidPage());


            Assert.IsFalse(Browser.Page<Exploratory.Watin.Pages.Users.HomePage>().IsValidPage());

        }

        #endregion
    }
}
