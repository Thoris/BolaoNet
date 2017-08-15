using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Testes
{
    public interface ITesteDao
    {
        bool TestConnection();
        DateTime GetCurrentDateTime();
    }
}
