using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class ActivationTemplateMail : BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "Activation.htm";
        private const string Title = "Ativação de Conta";

        #endregion

        #region Constructors/Destructors

        public ActivationTemplateMail(string currentUserName, string folder, Domain.Entities.Users.User user)
            : base(currentUserName, folder, TemplateHtmlFile, Title, user)
        {
            base.Tags.Add(new TagValue("NOME", user.FirstName));
            base.Tags.Add(new TagValue("URLACTIVATION", ""));
            base.Tags.Add(new TagValue("USER", user.UserName));
            base.Tags.Add(new TagValue("ACTIVATIONKEY", user.ActivateKey));
        }

        #endregion
    }
}
