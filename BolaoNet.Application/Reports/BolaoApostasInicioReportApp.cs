using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports
{
    public class BolaoApostasInicioReportApp :
        Application.Interfaces.Reports.IBolaoApostasInicioReportApp
    {
        #region Variables

        private Domain.Interfaces.Services.Reports.IBolaoApostasInicioReportService _service;

        #endregion

        #region Constructors/Destructors

        public BolaoApostasInicioReportApp(Domain.Interfaces.Services.Reports.IBolaoApostasInicioReportService service)
        {
            _service = service;
        }

        #endregion

        #region IBolaoMembroApostasReportApp members

        public Domain.Entities.ValueObjects.Reports.BolaoIniciarVO GetData(Domain.Entities.Boloes.Bolao bolao)
        {
            return _service.GetData(bolao);
        }

        public System.IO.Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoIniciarVO data)
        {
            return _service.Generate(fileName, compressedFileName, extension, folderProfiles, folderTimes, data);
        }

        #endregion 
    }
}
