using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.LogReporting
{
    public class LogReportingApp :
        Base.GenericApp<Domain.Entities.LogReporting.LogEvent>,
        Application.Interfaces.LogReporting.ILogReportingApp
    {
        #region Properties

        private Domain.Interfaces.Services.LogReporting.ILogReportingService Service
        {
            get { return (Domain.Interfaces.Services.LogReporting.ILogReportingService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="LogReportingApp" />.
        /// </summary>
        public LogReportingApp(Domain.Interfaces.Services.LogReporting.ILogReportingService service)
            : base (service)
        {

        }

        #endregion

        #region ILogReportingApp members

        public Domain.Interfaces.Services.Paging.IPagedList<Domain.Entities.LogReporting.LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logProviderName, string logLevel)
        {
            return Service.GetByDateRangeAndType(pageIndex, pageSize, start, end, logProviderName, logLevel);
        }

        public Domain.Entities.LogReporting.LogEvent GetById(string logProviderName, string id)
        {
            return Service.GetById(logProviderName, id);
        }

        public void ClearLog(string logProviderName, DateTime start, DateTime end, string[] logLevels)
        {
            Service.ClearLog(logProviderName, start, end, logLevels);
        }

        #endregion
    }
}
