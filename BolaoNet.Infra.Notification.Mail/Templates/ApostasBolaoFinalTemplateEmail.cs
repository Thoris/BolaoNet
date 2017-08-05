using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class ApostasBolaoFinalTemplateEmail : BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "ApostasBolaoFinal.htm";
        private const string Title = "Apostas do Bolão - Final";

        #endregion

        #region Constructors/Destructors

        public ApostasBolaoFinalTemplateEmail(string currentUserName, string folder)
            : base(currentUserName, folder, TemplateHtmlFile, Title, null)
        {
        }

        #endregion
        
    }
}
