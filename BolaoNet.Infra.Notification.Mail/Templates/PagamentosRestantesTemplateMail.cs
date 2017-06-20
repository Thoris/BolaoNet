using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class PagamentosRestantesTemplateMail : BaseTemplateMailUser, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "PagamentosRestantes.htm";
        private const string Title = "Pagamentos Restantes";

        #endregion

        #region Constructors/Destructors

        public PagamentosRestantesTemplateMail(string currentUserName, string folder, Domain.Entities.Users.User user)
            : base(currentUserName, folder, TemplateHtmlFile, Title, user)
        {
            base.Tags.Add(new TagValue("NOME", user.FirstName));
            base.Tags.Add(new TagValue("PASSWORD", user.Password));
            base.Tags.Add(new TagValue("URL", ""));            
        }

        #endregion
    }
}
