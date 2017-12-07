using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Watin.Pages.Boloes
{
    public class ApostasJogoIndexPage : BasePage
    {
         #region Constantes

        private const string ControllerName = "/Boloes/ApostasJogo";

        #endregion

        #region Properties
         
        #endregion


        #region Constructors/Destructors

        public ApostasJogoIndexPage()
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
            if (!base.Document.ContainsText("Apostas do Jogo"))
                return false;
             

            return true;
        }


        #endregion
    }
}
