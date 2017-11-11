using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin.Pages
{
    public class LoginPage : BasePage
    {
        #region Constantes

        private const string ControllerName = "/Account/Login";

        #endregion

        #region Properties

        [FindBy(Name = "UserName")]
        public TextField UserNameTextField;
        [FindBy(Name = "Password")]
        public TextField PasswordTextField;
        [FindBy(Text = "Acessar")]
        public Button LogOnButton;
        [FindBy(Text = "Esqueceu a senha?")]
        public Link ForgotPasswordButton;
        [FindBy(Text = "Registrar Usuário")]
        public Link RegisterUserButton;
        [FindBy(Name = "RememberMe")]
        public CheckBox RememberMeCheckBox;

        #endregion

        #region Constructors/Destructors
         
        public LoginPage()
            : base(ControllerName)
        {

        }

        #endregion

        #region Methods

        public override bool IsValidPage()
        {
            if (!UserNameTextField.Exists)
                return false;
            if (!PasswordTextField.Exists)
                return false;
            if (!LogOnButton.Exists)
                return false;

            return true;
        }
        public bool Logon(string userName, string password, bool rememberMe)
        {
            this.UserNameTextField.TypeText(userName);
            this.PasswordTextField.TypeText(password);
            this.LogOnButton.Click();

            return true;
        }


        #endregion
    }
}
