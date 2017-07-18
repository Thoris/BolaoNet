using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Reports.FormatReport
{
    public interface IBolaoApostasFimFormatReportService
    {
        Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Entities.ValueObjects.Reports.BolaoFinalVO data);
    
    }
}
