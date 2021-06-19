using System.Collections.Generic;

namespace BolaoNet.Domain.Interfaces.Services.Facade.Boloes
{
    public interface IBolaoListFacadeService
    {
        IList<string> GetNames();
        Domain.Interfaces.Services.Facade.Boloes.IBolaoFacadeService GetInstance(string name);
    }
}
