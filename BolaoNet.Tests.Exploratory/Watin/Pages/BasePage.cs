using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Watin.Pages
{
    public class BasePage
    {
        #region Variables

        private IWebDriver _driver;

        #endregion

        #region Properties

        protected IWebDriver Driver
        {
            get { return _driver; }
        }

        protected string SiteBaseLogin
        {
            get
            {
                return SiteBase + "/Account/Login";
            }
        }
        protected string SiteBase
        {
            get
            {
                string data = ConfigurationManager.AppSettings["WebTestPortal"];

                if (string.IsNullOrEmpty(data))
                {
                    return "http://thorisbolaonet.somee.com";
                }

                return data;
            }
        }
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

        public BasePage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(driver, this);
        }

        #endregion

        #region Métodos

        public BasePage OpenPortal()
        {
            Driver.Navigate().GoToUrl(this.SiteBase);

            return new BasePage(_driver);
        }
        public void Check(IWebElement element)
        {
            element.Click();
        }
        public string GetText(IWebElement element)
        {
            return element.Text;
        }
        public void EnterText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        public bool PageContains(string text)
        {
            return _driver.PageSource.Contains(text);
        }
        public void WaitForElementLoad(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }

        protected virtual bool IsValid()
        {
            return true;
        }
        protected virtual void OpenPage(string controller, string action, string parameters)
        {
            this.Driver.Navigate().GoToUrl(this.SiteBase + "/" + controller + "/" + action + "?" + parameters);
            
        }
        protected virtual void OpenPage(string area, string controller, string action, string parameters)
        {
            this.Driver.Navigate().GoToUrl(this.SiteBase + "/" + area + "/" + controller + "/" + action + "?" + parameters);            
        }
        #endregion
    }
}
