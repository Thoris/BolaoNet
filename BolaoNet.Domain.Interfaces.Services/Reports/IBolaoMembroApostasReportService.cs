using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Reports
{
    public interface IBolaoMembroApostasReportService
    {
        Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO GetData(
            Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user);

        Stream Generate(string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data);
    }
}
