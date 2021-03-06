﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IBolaoMembroGrupoApp
        : Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService,
        Base.IGenericApp<Domain.Entities.Boloes.BolaoMembroGrupo>
    {
    }
}
