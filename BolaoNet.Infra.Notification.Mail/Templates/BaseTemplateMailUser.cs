﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public abstract class BaseTemplateMailUser : BaseTemplateMail
    {
        #region Properties

        protected Domain.Entities.Users.User User { get; set; }

        #endregion

        #region Constructors/Destructors

        public BaseTemplateMailUser(string currentUserName, string folder, string templateHtmlFile, string title, Domain.Entities.Users.User user)
            : base(currentUserName, folder, templateHtmlFile, title)
        {
            this.User = user;
        }

        #endregion
    }
}
