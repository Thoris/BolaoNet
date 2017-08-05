using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Notification
{
    public class NotificationApp : Application.Interfaces.Notification.INotificationApp
    {
        #region Variables

        private Domain.Interfaces.Services.Notification.INotificationService _service;

        #endregion

        #region Constructors/Destructors

        public NotificationApp(Domain.Interfaces.Services.Notification.INotificationService service)
        {
            _service = service;
        }

        #endregion

        #region INotificationApp members

        public void NotifyActivationCode(Domain.Entities.Users.User user)
        {
            _service.NotifyActivationCode(user);
        }

        public void NotifyApostasBolao(Domain.Entities.Users.User user, string file)
        {
            _service.NotifyApostasBolao(user, file);
        }

        public void NotifyApostasRestantes(Domain.Entities.Users.User user)
        {
            _service.NotifyApostasRestantes(user);
        }

        public void NotityPagamentoRestante(Domain.Entities.Users.User user)
        {
            _service.NotityPagamentoRestante(user);
        }

        public void NotifyWelcome(Domain.Entities.Users.User user)
        {
            _service.NotifyWelcome(user);
        }

        public void NotifySendPassword(Domain.Entities.Users.User user)
        {
            _service.NotifySendPassword(user);
        }

        public void NotifyApostasIniciaisBolao(IList<string> emails, string file)
        {
            _service.NotifyApostasIniciaisBolao(emails, file);
        }

        public void NotifyApostasFinaisBolao(IList<string> emails, string file)
        {
            _service.NotifyApostasFinaisBolao(emails, file);
        }
        #endregion



    }
}
