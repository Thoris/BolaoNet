﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Security
{
    [Flags]
    public enum PermissionLevel
    {
        Admin,
        User,
    }
}