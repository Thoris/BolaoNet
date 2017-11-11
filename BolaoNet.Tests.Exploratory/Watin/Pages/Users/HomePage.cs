using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin.Pages.Users
{
    public class HomePage : BasePage
    {
        #region Constantes

        private const string ControllerName = "/Users/AccountHome";

        #endregion

        #region Properties

        [FindBy(Text = "Sair")]
        public Link SairButton;

        #endregion


        #region Constructors/Destructors

        public HomePage( )
            : base(ControllerName)
        {
        }

        #endregion

        #region Métodos

        public override bool IsValidPage()
        {
            if (!base.Document.ContainsText("Meus Bolões"))
                return false;
            if (!base.Document.ContainsText("Saldo de Pagamentos"))
                return false;
            if (!base.Document.ContainsText("Pontos Obtidos"))
                return false;
            if (!base.Document.ContainsText("Grupo de comparação"))
                return false;
            if (!base.Document.ContainsText("Próximos Jogos"))
                return false;
            if (!base.Document.ContainsText("Meus Bolões"))
                return false;

            return true;
        }


        #endregion

    
    }
}
