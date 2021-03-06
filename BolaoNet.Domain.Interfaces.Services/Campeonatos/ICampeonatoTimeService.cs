﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoTimeService
        : Base.IGenericService<Entities.Campeonatos.CampeonatoTime>
    {
        IList<Entities.Campeonatos.CampeonatoTime> GetTimesCampeonato(Entities.Campeonatos.Campeonato campeonato);
    }
}
