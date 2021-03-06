﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Users
{
    public interface IRoleApp
        : Domain.Interfaces.Services.Users.IRoleService,
        Base.IGenericApp<Domain.Entities.Users.Role>
    {
    }
}
