﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo
{
    public interface IAresta
    {
        IIdentifier VerticeId { get; set; }
    }
}
