﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoGrupoService
        : Base.IGenericService<Entities.Campeonatos.CampeonatoGrupo>
    {
        IList<Entities.Campeonatos.CampeonatoGrupo> GetGruposCampeonato(Entities.Campeonatos.Campeonato campeonato);
    }
}
