﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoRegraService
        : Base.IGenericService<Entities.Boloes.BolaoRegra>
    {
        IList<Entities.Boloes.BolaoRegra> GetRegrasBolao(Entities.Boloes.Bolao bolao);

    }
}
