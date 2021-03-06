﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoHistoricoService
        : Base.IGenericService<Entities.Boloes.BolaoHistorico>
    {
        IList<Domain.Entities.Boloes.BolaoHistorico> GetListFromBolao(Entities.Boloes.Bolao bolao, int ano);
        IList<int> GetYearsFromBolao(Entities.Boloes.Bolao bolao);

    }
}
