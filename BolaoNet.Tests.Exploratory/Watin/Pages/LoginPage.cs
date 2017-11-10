using BolaoNet.Tests.Exploratory.Selenium.Pages.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Watin.Pages
{
    public class LoginPage : BasePage
    {
        #region Propriedades

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtLogin { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtSenha { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement btnAcessar { get; set; }

        #endregion

        #region Constructors/Destructors

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        #endregion

        #region Métodos

        public bool IsValidPage()
        {
            return true;
        }

        public HomePage Login(string login, string senha)
        {

            this.txtLogin.SendKeys(login);
            this.txtSenha.SendKeys(Password);
            this.btnAcessar.Submit();

            HomePage page = new HomePage(base.Driver);
            if (page.IsValidPage())
                return page;
            else
                return null;

        }
        public HomePage Logon()
        {
            OpenLoginPage();
            HomePage welcomePage = Login(base.UserName, base.Password);

            return welcomePage;

        }
        public LoginPage Logoff()
        {
            return new LoginPage(base.Driver);
        }
        public void OpenLoginPage()
        {
            Driver.Navigate().GoToUrl(this.SiteBaseLogin);
        }


        #endregion
    }
}
