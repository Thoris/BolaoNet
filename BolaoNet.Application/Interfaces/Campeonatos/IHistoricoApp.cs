﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface IHistoricoApp
        : Domain.Interfaces.Services.Campeonatos.IHistoricoService,
        Base.IGenericApp<Domain.Entities.Campeonatos.Historico>
    {
    }
}
