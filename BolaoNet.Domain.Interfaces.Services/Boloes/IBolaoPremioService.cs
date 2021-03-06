﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoPremioService
        : Base.IGenericService<Entities.Boloes.BolaoPremio>
    {
        IList<Entities.Boloes.BolaoPremio> GetPremiosBolao(Entities.Boloes.Bolao bolao);
  
    }
}
