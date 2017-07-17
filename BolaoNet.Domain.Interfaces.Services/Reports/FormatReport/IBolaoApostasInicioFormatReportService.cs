using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Reports.FormatReport
{
    public interface IBolaoApostasInicioFormatReportService
    {
        Stream Generate(string extension, string folderProfiles, string folderTimes, IList<Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO> data);
    }
}
