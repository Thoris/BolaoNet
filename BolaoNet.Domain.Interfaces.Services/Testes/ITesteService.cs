using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Testes
{
    public interface ITesteService
    {
        bool TestConnection();
        DateTime GetCurrentDateTime();
    }
}
