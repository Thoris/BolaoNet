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


        [TestMethod]
        public void Test_Check_Classificacao_Jogo_Stress()
        {
            for (int c = 0; c < 100; c++)
            {
                Browser.GoTo(Browser.Page<Exploratory.Watin.Pages.LoginPage>().ControllerSite);
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.LoginPage>().IsValidPage());


                Browser.Page<Exploratory.Watin.Pages.LoginPage>().Logon(this.UserName, this.Password, false);
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Users.HomePage>().IsValidPage());


                //Verificação de classificação
                Browser.GoTo(Browser.Page<Exploratory.Watin.Pages.Boloes.BolaoClassificacaoIndexPage>().ControllerSite);
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Boloes.BolaoClassificacaoIndexPage>().IsValidPage());
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Boloes.BolaoClassificacaoIndexPage>().ContainsLogin(this.UserName));

                //Carregamento de um jogo
                Browser.GoTo(Browser.Page<Exploratory.Watin.Pages.Boloes.ApostasUsuariosIndexPage>().ControllerSite);
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Boloes.ApostasUsuariosIndexPage>().IsValidPage());

                //Verificação de pontuação do jogo
                Browser.GoTo(Browser.Page<Exploratory.Watin.Pages.Boloes.ApostasJogoIndexPage>().ControllerSite + "/Index/1");
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Boloes.ApostasJogoIndexPage>().IsValidPage());
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.Boloes.ApostasJogoIndexPage>().ContainsLogin(this.UserName));



                Browser.Page<Exploratory.Watin.Pages.Users.HomePage>().SairButton.Click();
                Assert.IsTrue(Browser.Page<Exploratory.Watin.Pages.LoginPage>().IsValidPage());


                Assert.IsFalse(Browser.Page<Exploratory.Watin.Pages.Users.HomePage>().IsValidPage());

            }
        }

        #endregion
    }
}
