using BolaoNet.Reports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.Base
{
    public class FactoryReport
    {
        #region Variables

        private static IFactoryBase _factory;
        private static ReportType _reportType;
        private static string _userName;

        private static string _imageTimesFolder;
        private static string _imageUsersFolder;
        private static string _imageExtension;
        private static string _outputFile;

        #endregion

        #region Constructors/Destructors

        public FactoryReport(string userName, ReportType type, string imageTimesFolder, string imageUsersFolder, string imageExtension, string outputFile)
        {
            _reportType = type;

            _imageExtension = imageExtension;
            _imageTimesFolder = imageTimesFolder;
            _imageUsersFolder = imageUsersFolder;
            _outputFile = outputFile;
        }

        #endregion

        #region Methods

        private static ReportType GetDaoType()
        {
            //Buscando a configuração do tipo de acesso à dados
            string daoType = System.Configuration.ConfigurationManager.AppSettings["FactoryReportType"];

            //Se existe informação configurada para o tipo de acesso
            if (!string.IsNullOrEmpty(daoType))
            {
                //Verificando qual tipo corresponde ao configurado
                string[] types = Enum.GetNames(typeof(ReportType));

                //Buscando qual tipo se encaixa
                for (int c = 0; c < types.Length; c++)
                {
                    //Se encontrou a descrição do tipo de conexão
                    if (string.Compare(daoType, types[c], true) == 0)
                    {
                        return (ReportType)c;
                    }
                    //Se encontrou o índice do tipo de conexão
                    else if (string.Compare(daoType, c.ToString(), true) == 0)
                    {
                        return (ReportType)c;
                    }//endif

                }//end for c

            }//endif tipo de conexão à dados

            return ReportType.Pdf;
        }
        private static IFactoryBase GetFactoryReport()
        {
            if (_factory == null)
            {
                _reportType = GetDaoType();

                switch (_reportType)
                {
                    case ReportType.Pdf:

                        _factory = new Reports.DataReports.PDF.FactoryPdfReport(
                            _imageTimesFolder, _imageUsersFolder, _imageExtension, _outputFile);

                        break;

                    case ReportType.Text:



                        break;

                    case ReportType.Excel:


                        break;

                }

            }//endif factory == null

            return _factory;
        }
        public IFactoryBase GetFactoryBase()
        {
            return GetFactoryReport();
        }

        #endregion
    }
}
