using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Notification
{
    public interface INotificationService
    {
        void NotifyActivationCode(Entities.Users.User user);
        void NotifyApostasBolao(Entities.Users.User user, Stream file);
        void NotifyApostasRestantes(Entities.Users.User user);
        void NotityPagamentoRestante(Entities.Users.User user);
        void NotifyWelcome(Entities.Users.User user);
        void NotifySendPassword(Entities.Users.User user);
        

    }
}
