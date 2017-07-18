using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Reports
{
    public interface IBolaoApostasInicioReportService
    {
        Entities.ValueObjects.Reports.BolaoIniciarVO GetData(Domain.Entities.Boloes.Bolao bolao);

        Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Entities.ValueObjects.Reports.BolaoIniciarVO data);

    }
}
