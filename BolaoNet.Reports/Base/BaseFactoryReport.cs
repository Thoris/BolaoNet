using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.Base
{
    public class BaseFactoryReport
    {
        #region Variables

        protected string ImageTimesFolder {get; set;}
        protected string ImageUsersFolder { get; set; }
        protected string ImageExtension { get; set; }
        protected string OutputFile { get; set; }

        #endregion

        #region Constructors/Destructors

        public BaseFactoryReport(string imageTimesFolder, string imageUsersFolder, string imageExtension, string outputFile)
        {
            this.ImageExtension = imageExtension;
            this.ImageTimesFolder = imageTimesFolder;
            this.ImageUsersFolder = imageUsersFolder;
            this.OutputFile = outputFile;
        }

        #endregion
    }
}
