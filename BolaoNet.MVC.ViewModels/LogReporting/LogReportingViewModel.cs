using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.LogReporting
{
    public class LogReportingViewModel
    {
        #region Properties

        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public string Identity { get; set; }
        public string Period { get; set; }
        public string Level { get; set; }
        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public int? CurrentPageIndex { get; set; }
        public int? SetNextPage { get; set; }
        public int? PageCount { get; set; }
        public int? PageSize { get; set; }
        public int? Total { get; set; }
        public IList<LogEventViewModel> List { get; set; }

        #endregion
    }
}
