﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IPontuacaoApp
        : Domain.Interfaces.Services.Boloes.IPontuacaoService,
        Base.IGenericApp<Domain.Entities.Boloes.Pontuacao>
    {
    }
}
