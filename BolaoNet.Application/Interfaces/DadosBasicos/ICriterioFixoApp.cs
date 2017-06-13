using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.DadosBasicos
{
    public interface ICriterioFixoApp
        : Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService,
        Base.IGenericApp<Domain.Entities.DadosBasicos.CriterioFixo>
    {
    }
}
