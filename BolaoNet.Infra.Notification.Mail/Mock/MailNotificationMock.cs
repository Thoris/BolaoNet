using BolaoNet.Domain.Entities.ValueObjects.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Mock
{
    public class MailNotificationMock : Domain.Interfaces.Services.Notification.INotificationService
    {
        public void NotifyActivationCode(Domain.Entities.Users.User user)
        {
            
        }


        public void NotifyApostasRestantes(Domain.Entities.Users.User user)
        {
            
        }

        public void NotityPagamentoRestante(Domain.Entities.Users.User user)
        {
            
        }

        public void NotifyWelcome(Domain.Entities.Users.User user)
        {
            
        }

        public void NotifySendPassword(Domain.Entities.Users.User user)
        {
            
        }

        public void NotifyApostasBolao(Domain.Entities.Users.User user, string file)
        { 
        }

        public void NotifyApostasIniciaisBolao(IList<string> emails, string file)
        { 
        }

        public void NotifyApostasFinaisBolao(IList<string> emails, string file)
        { 
        } 

        public void NotifyClassificacao(IList<string> emails, IList<ClassificacaoObject> classificacao, IList<PremioObject> premios, IList<JogoObject> jogos)
        { 
        }
    }
}
