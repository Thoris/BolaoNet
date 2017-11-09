using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Selenium
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return CreateFireFoxDriver();
        }
        private IWebDriver CreateFireFoxDriver()
        {
            return new FirefoxDriver();
        }
        private IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
