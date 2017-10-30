using AutoMapper;
using BolaoNet.Domain.Entities.LogReporting;
using BolaoNet.Domain.Interfaces.Services.Paging;
using BolaoNet.MVC.ViewModels.LogReporting;
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
         
        public ActionResult Index(ViewModels.LogReporting.LogReportingViewModel model, int ? newPage)
        {
            if (newPage != null)
            {
                model = (ViewModels.LogReporting.LogReportingViewModel)Session["ModelEntry"];
                model.CurrentPageIndex = newPage;
            }
            else
            {
                model.CurrentPageIndex = 0;
            }

            DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            if (model.StartDate == null)
                model.StartDate = currentDate;
            
            model.EndDate = currentDate.AddDays(1);
            
            //if (model.CurrentPageIndex == null || model.CurrentPageIndex == 0)
            //    model.CurrentPageIndex = 1;

            if (model.PageSize == null || model.PageSize == 0)
                model.PageSize = 20;

            if (model.Level == null)
                model.Level = "FATAL";


            switch(model.Period)
            {
                case "0":
                    model.StartDate = currentDate.AddDays(-1);
                    break;
                case "1":
                    model.EndDate = currentDate.AddDays(-1);
                    model.StartDate = currentDate.AddDays(-2);
                    break;
                case "2":
                    model.StartDate = currentDate.AddDays(-7);
                    break;
                case "3":
                    model.StartDate = currentDate.AddDays(-7);
                    model.StartDate = currentDate.AddDays(-14);
                    break;
                case "4": 
                    model.StartDate = currentDate.AddDays(-30);
                    break;
                case "5":
                    model.EndDate = currentDate.AddDays(-30);
                    model.StartDate = currentDate.AddDays(-60);
                    break;
                case "6":
                    model.StartDate = currentDate.AddDays(-30);
                    break;
                case "7":
                    model.StartDate = currentDate.AddDays(-60);
                    break;
                case "8":
                    model.StartDate = currentDate.AddDays(-90);
                    break;
            }

            

            Session["ModelEntry"] = model;


            IPagedList<LogEvent> list = _logReportingApp.GetByDateRangeAndType((int)model.CurrentPageIndex, (int)model.PageSize,
                 (DateTime)model.StartDate, (DateTime)model.EndDate, model.Level, model.Identity);

            model.PageCount = list.PageCount;
            model.Total = list.TotalItemCount;
            model.IsFirstPage = 1 == model.CurrentPageIndex + 1;
            model.IsLastPage = list.PageCount == model.CurrentPageIndex + 1;
            


            model.List = Mapper.Map<IList<Domain.Entities.LogReporting.LogEvent>,
                IList<ViewModels.LogReporting.LogEventViewModel>>(list);
             
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            LogEvent log = _logReportingApp.GetById(id);

            LogEventViewModel model = Mapper.Map<Domain.Entities.LogReporting.LogEvent,
                ViewModels.LogReporting.LogEventViewModel>(log);

            return View(model);
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