using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Exploratory.Watin.Pages.Boloes
{
    public class ApostasUsuariosIndexPage : BasePage
    {
         #region Constantes

        private const string ControllerName = "/Boloes/ApostasUsuarios";

        #endregion

        #region Properties
         
        #endregion


        #region Constructors/Destructors

        public ApostasUsuariosIndexPage()
            : base(ControllerName)
        {
        }

        #endregion

        #region Métodos
         

        public override bool IsValidPage()
        {
            if (!base.Document.ContainsText("Apostas dos Jogos do Bolão"))
                return false;
             

            return true;
        }


        #endregion
    }
}
