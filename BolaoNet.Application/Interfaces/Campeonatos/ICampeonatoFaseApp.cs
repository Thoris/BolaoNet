﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface ICampeonatoFaseApp
        : Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService,
        Base.IGenericApp<Domain.Entities.Campeonatos.CampeonatoFase>
    {
    }
}
