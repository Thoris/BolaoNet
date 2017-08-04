using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail
{
    public class MailNotification : BaseMailNotification,
        Domain.Interfaces.Services.Notification.INotificationService
    {
        #region Constructors/Destructors

        public MailNotification(string userName)
            : base(userName)
        {
        }

        #endregion

        #region INotificationService members

        public void NotifyActivationCode(Domain.Entities.Users.User user)
        {
            ITemplateMail template = new Templates.ActivationTemplateMail(
                base.CurrentUserName, GetFolderTemplates(), user);

            SendMailFromAppSettingsConfig(
                template.LoadTitle(),
                template.LoadBody(),
                true,
                new string [] {user.Email});
        }
        public void NotifyWelcome(Domain.Entities.Users.User user)
        {
            ITemplateMail template = new Templates.WelcomeTemplateMail(
                  base.CurrentUserName, GetFolderTemplates(), user);

            SendMailFromAppSettingsConfig(
                template.LoadTitle(),
                template.LoadBody(),
                true,
                new string[] { user.Email });
        }
        public void NotifySendPassword(Domain.Entities.Users.User user)
        {
            ITemplateMail template = new Templates.ResetPasswordTemplateMail(
               base.CurrentUserName, GetFolderTemplates(), user);

            SendMailFromAppSettingsConfig(
                template.LoadTitle(),
                template.LoadBody(),
                true,
                new string[] { user.Email });
        }
        public void NotityPagamentoRestante(Domain.Entities.Users.User user)
        {
            ITemplateMail template = new Templates.PagamentosRestantesTemplateMail(
               base.CurrentUserName, GetFolderTemplates(), user);

            SendMailFromAppSettingsConfig(
                template.LoadTitle(),
                template.LoadBody(),
                true,
                new string[] { user.Email });
        }
        public void NotifyApostasBolao(Domain.Entities.Users.User user, System.IO.Stream file)
        {
            ITemplateMail template = new Templates.ApostasBolaoTemplateMail(
               base.CurrentUserName, GetFolderTemplates(), user);

            SendMailFromAppSettingsConfig(
                template.LoadTitle(),
                template.LoadBody(),
                true,
                new string[] { user.Email });
        }
        public void NotifyApostasRestantes(Domain.Entities.Users.User user)
        {
            ITemplateMail template = new Templates.ApostasRestantesTemplateMail(
               base.CurrentUserName, GetFolderTemplates(), user);

            SendMailFromAppSettingsConfig(
                template.LoadTitle(),
                template.LoadBody(),
                true,
                new string[] { user.Email });
        }

        #endregion
    }
}
