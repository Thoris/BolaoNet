﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Campeonatos
{
    public interface ICampeonatoClassificacaoApp
        : Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService,
        Base.IGenericApp<Domain.Entities.Campeonatos.CampeonatoClassificacao>
    {
    }
}
