using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.WebApi.Areas.LogReporting.Controllers
{
    public class LogReportingController  :
        GenericApiController<Domain.Entities.LogReporting.LogEvent>, 
        Domain.Interfaces.Services.LogReporting.ILogReportingService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.LogReporting.ILogReportingService Service
        {
            get { return (Domain.Interfaces.Services.LogReporting.ILogReportingService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public LogReportingController()
        //    : base(new Domain.Services.FactoryService(null).CreateCriterioFixoService())
        //{

        //}
        public LogReportingController(Domain.Interfaces.Services.LogReporting.ILogReportingService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region ILogReportingService members

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