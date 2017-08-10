using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class WelcomeTemplateMail : BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "Welcome.htm";
        private const string Title = "Bem vindo";

        #endregion

        #region Constructors/Destructors

        public WelcomeTemplateMail(string currentUserName, string folder, Domain.Entities.Users.User user)
            : base(currentUserName, folder, TemplateHtmlFile, Title, user)
        {
            base.Tags.Add(new TagValue("NOME", user.FirstName));
            base.Tags.Add(new TagValue("USER", user.UserName));
            base.Tags.Add(new TagValue("PASSWORD", user.Password));          
        }

        #endregion
    }
}
