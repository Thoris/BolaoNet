using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class ApostasBolaoInicialTemplateEmail : BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "ApostasBolaoInicial.htm";
        private const string Title = "Apostas do Bolão - Inicial";

        #endregion

        #region Constructors/Destructors

        public ApostasBolaoInicialTemplateEmail(string currentUserName, string folder)
            : base(currentUserName, folder, TemplateHtmlFile, Title, null)
        {
        }

        #endregion
     
    }
}
