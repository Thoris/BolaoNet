﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IMensagemApp
        : Domain.Interfaces.Services.Boloes.IMensagemService,
        Base.IGenericApp<Domain.Entities.Boloes.Mensagem>
    {
    }
}
