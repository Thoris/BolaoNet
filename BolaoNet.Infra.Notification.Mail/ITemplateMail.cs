﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail
{
    public interface ITemplateMail
    {
        string LoadBody();
        string LoadTitle();
    }
}
