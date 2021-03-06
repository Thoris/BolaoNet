﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface ICampeonatoApp
        : Domain.Interfaces.Services.Campeonatos.ICampeonatoService,
        Base.IGenericApp<Domain.Entities.Campeonatos.Campeonato>
    {
        
    }
}
