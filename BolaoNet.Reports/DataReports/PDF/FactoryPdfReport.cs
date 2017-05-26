using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.DataReports.PDF
{
    public class FactoryPdfReport : Base.BaseFactoryReport, Interfaces.IFactoryBase
    {
        #region Constructors/Destructors

        public FactoryPdfReport(string imageTimesFolder, string imageUsersFolder, string imageExtension, string outputFile)
            : base(imageTimesFolder, imageUsersFolder, imageExtension, outputFile)
        {

        }

        #endregion

        #region Methods


        public Interfaces.IApostasUserReport CreateApostasUserReport()
        {
            return new PdfCopaMundoApostasUserReport(_imageTimesFolder, _imageUsersFolder, _outputFile, _imageExtension);
        }

        #endregion
    }
}
