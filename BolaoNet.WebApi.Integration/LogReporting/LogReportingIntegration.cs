using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.LogReporting
{
    public class LogReportingIntegration:
        Base.GenericIntegration<Domain.Entities.LogReporting.LogEvent>,
        Domain.Interfaces.Services.LogReporting.ILogReportingService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "LogReporting";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="LogReportingIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public LogReportingIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region ILogReportingService members


        public Domain.Interfaces.Services.Paging.IPagedList<Domain.Entities.LogReporting.LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logProviderName, string logLevel)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.LogReporting.LogEvent GetById(string logProviderName, string id)
        {
            throw new NotImplementedException();
        }

        public void ClearLog(string logProviderName, DateTime start, DateTime end, string[] logLevels)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
