using BolaoNet.Tests.Exploratory.Selenium.Pages.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Selenium.Tests
{
    [TestClass]
    public class LogonTests : BaseTests
    {
        [TestMethod]
        public void TestLogonValid()
        {
            Pages.Users.HomePage homePage = base.LogOn();

            Assert.IsNotNull(homePage);
            Assert.IsTrue(homePage.IsValidPage());

        }
    }
}
