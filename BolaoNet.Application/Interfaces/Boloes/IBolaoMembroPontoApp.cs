﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoMembroPontoApp : 
        Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoMembroPonto>
    {

    }
}
