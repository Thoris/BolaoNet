﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo
{
    public interface IIdentifier
    {
        int Index { get; }

        bool IsEqual(IIdentifier identifier);
     
    }
}
