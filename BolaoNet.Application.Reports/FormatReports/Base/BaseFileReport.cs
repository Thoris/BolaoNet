using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.FormatReports.Base
{
    public class BaseFileReport
    {
        #region Properties

        protected string OutputFile { get; set; }
        protected Stream Stream { get; set; }

        #endregion

        #region Constructors/Destructors

        public BaseFileReport(string outputFile)
        {
            this.OutputFile = outputFile;
        }

        #endregion
    }
}
