﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoRegraApp
        : Domain.Interfaces.Services.Boloes.IBolaoRegraService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoRegra>
    {
    }
}
