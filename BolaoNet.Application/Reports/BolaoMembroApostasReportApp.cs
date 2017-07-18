using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports
{
    public class BolaoMembroApostasReportApp :
        Application.Interfaces.Reports.IBolaoMembroApostasReportApp
    {
        #region Variables

        private Domain.Interfaces.Services.Reports.IBolaoMembroApostasReportService _service;

        #endregion

        #region Constructors/Destructors

        public BolaoMembroApostasReportApp(Domain.Interfaces.Services.Reports.IBolaoMembroApostasReportService service)
        {
            _service = service;
        }

        #endregion

        #region IBolaoMembroApostasReportApp members

        public Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO GetData(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return _service.GetData(bolao, user);
        }

        public System.IO.Stream Generate(string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data)
        {
            return _service.Generate(extension, folderProfiles, folderTimes, data);
        }

        #endregion
    }
}
