﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoFaseService
        : Base.IGenericService<Entities.Campeonatos.CampeonatoFase>
    {
        IList<Entities.Campeonatos.CampeonatoFase> GetFaseCampeonato(Entities.Campeonatos.Campeonato campeonato);
    }
}
