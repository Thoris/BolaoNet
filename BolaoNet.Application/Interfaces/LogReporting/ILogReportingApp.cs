using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.LogReporting
{
    public interface ILogReportingApp
         : Domain.Interfaces.Services.LogReporting.ILogReportingService,
        Base.IGenericApp<Domain.Entities.LogReporting.LogEvent>
    {
    }
}
