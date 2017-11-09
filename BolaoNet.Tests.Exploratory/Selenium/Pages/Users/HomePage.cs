using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Selenium.Pages.Users
{
    public class HomePage : BasePage
    {
        #region Constructors/Destructors

        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }

        #endregion

        #region Métodos

        public bool IsValidPage()
        {
            return base.PageContains("");
        }


        #endregion

    
    }
}
