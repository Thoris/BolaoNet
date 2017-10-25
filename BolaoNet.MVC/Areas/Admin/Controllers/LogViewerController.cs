using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    public class LogViewerController : BaseAdminAreaController
    {
        #region Variables

        private Application.Interfaces.LogReporting.ILogReportingApp _logReportingApp;

        #endregion

        #region Constructors/Destructors

        public LogViewerController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.LogReporting.ILogReportingApp logReportingApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _logReportingApp = logReportingApp;
        }

        #endregion

        #region Actions
         
        public ActionResult Index(ViewModels.LogReporting.LogReportingViewModel model)
        {
            if (model == null)
                model = new ViewModels.LogReporting.LogReportingViewModel();

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            if (model.StartDate == null)
                model.StartDate = startDate;

            if (model.EndDate == null)
                model.EndDate = startDate.AddDays(1);

            if (model.Page == null)
                model.Page = 1;

            if (model.TotalItemsPage == null)
                model.TotalItemsPage = 100;

            if (model.Level == null)
                model.Level = "Error";

            var res =_logReportingApp.GetByDateRangeAndType((int)model.Page, (int)model.TotalItemsPage, 
                (DateTime)model.StartDate, (DateTime)model.EndDate, "", model.Level);

            return View();
        }
        ///// <summary>
        ///// Returns the Index view
        ///// </summary>
        ///// <param name="Period">Text representation of the date time period. eg: Today, Yesterday, Last Week etc.</param>
        ///// <param name="LoggerProviderName">Elmah, Log4Net, NLog, Health Monitoring etc</param>
        ///// <param name="LogLevel">Debug, Info, Warning, Error, Fatal</param>
        ///// <param name="page">The current page index (0 based)</param>
        ///// <param name="PageSize">The number of records per page</param>
        ///// <returns></returns>
        //public ActionResult Index(string Period, string LoggerProviderName, string LogLevel, int? page, int? PageSize)
        //{
        //    //// Set up our default values
        //    //string defaultPeriod = Session["Period"] == null ? "Today" : Session["Period"].ToString();
        //    //string defaultLogType = Session["LoggerProviderName"] == null ? "All" : Session["LoggerProviderName"].ToString();
        //    //string defaultLogLevel = Session["LogLevel"] == null ? "Error" : Session["LogLevel"].ToString();

        //    //// Set up our view model
        //    //LoggingIndexModel model = new LoggingIndexModel();

        //    //model.Period = (Period == null) ? defaultPeriod : Period;
        //    //model.LoggerProviderName = (LoggerProviderName == null) ? defaultLogType : LoggerProviderName;
        //    //model.LogLevel = (LogLevel == null) ? defaultLogLevel : LogLevel;
        //    //model.CurrentPageIndex = page.HasValue ? page.Value - 1 : 0;
        //    //model.PageSize = PageSize.HasValue ? PageSize.Value : 20;

        //    //TimePeriod timePeriod = TimePeriodHelper.GetUtcTimePeriod(model.Period);

        //    //// Grab the data from the database
        //    //model.LogEvents = loggingRepository.GetByDateRangeAndType(model.CurrentPageIndex, model.PageSize, timePeriod.Start, timePeriod.End, model.LoggerProviderName, model.LogLevel);

        //    //// Put this into the ViewModel so our Pager can get at these values
        //    //ViewData["Period"] = model.Period;
        //    //ViewData["LoggerProviderName"] = model.LoggerProviderName;
        //    //ViewData["LogLevel"] = model.LogLevel;
        //    //ViewData["PageSize"] = model.PageSize;

        //    //// Put the info into the Session so that when we browse away from the page and come back that the last settings are rememberd and used.
        //    //Session["Period"] = model.Period;
        //    //Session["LoggerProviderName"] = model.LoggerProviderName;
        //    //Session["LogLevel"] = model.LogLevel;

        //    return View(model);
        //}
        #endregion
    }
}