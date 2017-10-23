using BolaoNet.Domain.Entities.LogReporting;
using BolaoNet.Domain.Interfaces.Services.Logging;
using BolaoNet.Domain.Interfaces.Services.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.LogReporting
{
    public class LogReportingService :
        Base.BaseGenericService<Entities.LogReporting.LogEvent>,
        Interfaces.Services.LogReporting.ILogReportingService
    {
        #region Properties

        private Interfaces.Repositories.LogReporting.ILogReportingDao Dao
        {
            get { return (Interfaces.Repositories.LogReporting.ILogReportingDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public LogReportingService(string userName, Interfaces.Repositories.LogReporting.ILogReportingDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.LogReporting.LogEvent>)dao, logging)
        {

        }

        #endregion

        #region ILogReportingService members

        /// <summary>
        /// Gets a filtered list of log events
        /// </summary>
        /// <param name="pageIndex">0 based page index</param>
        /// <param name="pageSize">max number of records to return</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logProviderName">name of the log provider</param>
        /// <param name="logLevel">The level of the log messages</param>
        /// <returns>A filtered list of log events</returns>
        public IPagedList<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logProviderName, string logLevel)
        {
            IQueryable<LogEvent> list = null;

            IQueryable<LogEvent> logList = Dao.GetByDateRangeAndType(pageIndex, pageSize, start, end, logLevel);
            
            list = list.OrderByDescending(d => d.LogDate);

            return new PagedList<LogEvent>(list, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns a single Log event
        /// </summary>
        /// <param name="logProviderName">name of the log provider</param>
        /// <param name="id">Id of the log event as a string</param>
        /// <returns>A single Log event</returns>
        public LogEvent GetById(string logProviderName, string id)
        {
            LogEvent logEvent = Dao.GetById(id);
            return logEvent;
        }

        /// <summary>
        /// Clears log messages between a date range and for specified log levels
        /// </summary>
        /// <param name="logProviderName">name of the log provider</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevels">string array of log levels</param>
        public void ClearLog(string logProviderName, DateTime start, DateTime end, string[] logLevels)
        {
            Dao.ClearLog (start, end, logLevels);
        }

        #endregion


    }
}
