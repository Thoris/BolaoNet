﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoHistoricoService
        : Base.IGenericService<Entities.Campeonatos.CampeonatoHistorico>
    {
        IList<Entities.Campeonatos.CampeonatoHistorico> LoadCampeoes(Entities.Campeonatos.Campeonato campeonato);
    }
}
