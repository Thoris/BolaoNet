using BolaoNet.Domain.Entities.LogReporting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.LogReporting
{
    public class LogReportingRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.LogReporting.LogEvent>, 
        Domain.Interfaces.Repositories.LogReporting.ILogReportingDao
    {
        #region Constructors/Destructors

        public LogReportingRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ILogReportingDao members

        /// <summary>
        /// Gets a filtered list of log events
        /// </summary>
        /// <param name="pageIndex">0 based page index</param>
        /// <param name="pageSize">max number of records to return</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevel">The level of the log messages</param>
        /// <returns>A filtered list of log events</returns>
        public IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            IQueryable<LogEvent> list = (from b in base.DataContext.Logging
                                         where b.LogDate >= start && b.LogDate <= end
                                         && (b.Level == logLevel || logLevel == "All")
                                         select new LogEvent
                                         {
                                             Id = b.Id.ToString (),
                                             //IdAsGuid = Guid.NewGuid(),
                                             LoggerProviderName = "Log4Net",
                                             LogDate = b.LogDate,
                                             MachineName = b.MachineName,
                                             Message = b.Message,
                                             Type = "",
                                             Level = b.Level,
                                             Source = b.Source,
                                             StackTrace = ""
                                         });

            return list;
        }

        /// <summary>
        /// Returns a single Log event
        /// </summary>
        /// <param name="id">Id of the log event as a string</param>
        /// <returns>A single Log event</returns>
        public LogEvent GetById(string id)
        {
            //int logEventId = Convert.ToInt32(id);

            LogEvent logEvent = (from b in base.DataContext.Logging
                                 where b.Id == id
                                 select new LogEvent
                                 {
                                     Id = b.Id.ToString (),
                                     LoggerProviderName = "Log4Net",
                                     LogDate = b.LogDate,
                                     MachineName = b.MachineName,
                                     Message = b.Message,
                                     Type = "",
                                     Level = b.Level,
                                     Source = b.Source,
                                     StackTrace = "",
                                     AllXml = ""
                                 })
                                .SingleOrDefault();

            return logEvent;
        }

        /// <summary>
        /// Clears log messages between a date range and for specified log levels
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevels">string array of log levels</param>
        public void ClearLog(DateTime start, DateTime end, string[] logLevels)
        {
            string logLevelList = "";
            foreach (string logLevel in logLevels)
            {
                logLevelList += ",'" + logLevel + "'";
            }
            if (logLevelList.Length > 0)
            {
                logLevelList = logLevelList.Substring(1);
            }
            
            string commandText = "delete from Logging WHERE [Date] >= @p0 and [Date] <= @p1 and Level in (@p2)";

            SqlParameter paramStartDate = new SqlParameter 
                { 
                    ParameterName = "p0", 
                    Value = start.ToUniversalTime(), 
                    DbType = System.Data.DbType.DateTime 
                };
            SqlParameter paramEndDate = new SqlParameter 
                { 
                    ParameterName = "p1", 
                    Value = end.ToUniversalTime(), 
                    DbType = System.Data.DbType.DateTime 
                };
            SqlParameter paramLogLevelList = new SqlParameter 
                { 
                    ParameterName = "p2", 
                    Value = logLevelList 
                };

            base.DataContext.Database.ExecuteSqlCommand(
                commandText, paramStartDate, paramEndDate, paramLogLevelList);
        }

        #endregion
    }
}
