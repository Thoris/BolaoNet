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

        protected string _imageTimesFolder;
        protected string _imageUsersFolder;
        protected string _imageExtension;
        protected string _outputFile;

        #endregion

        #region Constructors/Destructors

        public BaseFactoryReport(string imageTimesFolder, string imageUsersFolder, string imageExtension, string outputFile)
        {
            _imageExtension = imageExtension;
            _imageTimesFolder = imageTimesFolder;
            _imageUsersFolder = imageUsersFolder;
            _outputFile = outputFile;
        }

        #endregion
    }
}
