using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Testes
{
    public class TestesApp
        : Application.Interfaces.Testes.ITestesApp
    {
        #region Variables

        private Domain.Interfaces.Services.Testes.ITesteService _service;

        #endregion

        #region Properties

        private Domain.Interfaces.Services.Testes.ITesteService Service
        {
            get { return (Domain.Interfaces.Services.Testes.ITesteService)_service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="TestesApp" />.
        /// </summary>
        public TestesApp(Domain.Interfaces.Services.Testes.ITesteService service)            
        {
            _service = service;
        }

        #endregion


        #region Methods

        public bool TestConnection()
        {
            return _service.TestConnection();
        }

        public DateTime GetCurrentDateTime()
        {
            return _service.GetCurrentDateTime();
        }

        #endregion
    }
}
