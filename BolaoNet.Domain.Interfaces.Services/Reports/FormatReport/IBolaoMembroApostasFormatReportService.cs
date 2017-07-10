using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Reports.FormatReport
{
    public interface IBolaoMembroApostasFormatReportService
    {
        Stream Generate(string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data);
    }
}
