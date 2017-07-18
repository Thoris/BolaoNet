using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports
{
    public class BolaoApostasFimReportApp :
        Application.Interfaces.Reports.IBolaoApostasFimReportApp
    {
        #region Variables

        private Domain.Interfaces.Services.Reports.IBolaoApostasFimReportService _service;

        #endregion

        #region Constructors/Destructors

        public BolaoApostasFimReportApp(Domain.Interfaces.Services.Reports.IBolaoApostasFimReportService service)
        {
            _service = service;
        }

        #endregion

        #region IBolaoApostasFimReportApp members

        public Domain.Entities.ValueObjects.Reports.BolaoFinalVO GetData(Domain.Entities.Boloes.Bolao bolao)
        {
            return _service.GetData(bolao);
        }

        public System.IO.Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoFinalVO data)
        {
            return _service.Generate(fileName, compressedFileName, extension, folderProfiles, folderTimes, data);
        }
        #endregion
    }
}
