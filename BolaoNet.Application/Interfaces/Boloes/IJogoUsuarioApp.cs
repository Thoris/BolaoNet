﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Boloes
{
    public interface IJogoUsuarioApp
        : Domain.Interfaces.Services.Boloes.IJogoUsuarioService,
        Base.IGenericApp<Domain.Entities.Boloes.JogoUsuario>
    {
       
    
    }
}
