using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin.Pages.Boloes
{
    public class BolaoClassificacaoIndexPage : BasePage
    {
         #region Constantes

        private const string ControllerName = "/Boloes/BolaoClassificacao";

        #endregion

        #region Properties
         
        #endregion


        #region Constructors/Destructors

        public BolaoClassificacaoIndexPage()
            : base(ControllerName)
        {
        }

        #endregion

        #region Métodos

        public bool ContainsLogin(string login)
        {
            return base.Document.ContainsText(login);
        }

        public override bool IsValidPage()
        {
            if (!base.Document.ContainsText("Classificação do Bolão"))
                return false;
             

            return true;
        }


        #endregion
    }
}
