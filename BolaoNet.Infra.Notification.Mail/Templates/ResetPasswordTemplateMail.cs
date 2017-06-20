using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class ResetPasswordTemplateMail : BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "ResetPassword.htm";
        private const string Title = "Password";

        #endregion

        #region Constructors/Destructors

        public ResetPasswordTemplateMail(string currentUserName, string folder, Domain.Entities.Users.User user)
            : base(currentUserName, folder, TemplateHtmlFile, Title, user)
        {
            base.Tags.Add(new TagValue("NOME", user.FirstName));
            base.Tags.Add(new TagValue("PASSWORD", user.Password));            
        }

        #endregion
    }
}
