using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    class ApostasBolaoTemplateMail: BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "ApostasBolao.htm";
        private const string Title = "Apostas do Bolão";

        #endregion

        #region Constructors/Destructors

        public ApostasBolaoTemplateMail(string currentUserName, string folder, Domain.Entities.Users.User user)
            : base(currentUserName, folder, TemplateHtmlFile, Title, user)
        {
            base.Tags.Add(new TagValue("NOME", user.FirstName));
            base.Tags.Add(new TagValue("PASSWORD", user.Password));
            base.Tags.Add(new TagValue("URL", ""));            
        }

        #endregion
}
