using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos
{
    public interface ICopaListFacadeService
    {
        IList<string> GetNames();
        ICopaFacadeService GetInstance(string name);
    }
}
