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

        public string Identity { get; set; }
        public string Period { get; set; }
        public string Level { get; set; }
        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public int ? Page { get; set; }
        public int ? TotalItemsPage { get; set; }
        public IList<LogEventViewModel> List { get; set; }

        #endregion
    }
}
