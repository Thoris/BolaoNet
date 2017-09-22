using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.WebApi.Areas.Tests.Controllers
{
    public class TestesController
        : Domain.Interfaces.Services.Testes.ITesteService
    {
        #region Variables

        private Domain.Interfaces.Services.Testes.ITesteService _service;

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Testes.ITesteService Service
        {
            get { return _service; }
        }

        #endregion

        #region Constructors/Destructors

        public TestesController(Domain.Interfaces.Services.Testes.ITesteService service)            
        {
            _service = service;
        }

        #endregion

        #region Methods

        [HttpPost]
        public bool TestConnection()
        {
            return _service.TestConnection();
        }

        [HttpPost]
        public DateTime GetCurrentDateTime()
        {
            return _service.GetCurrentDateTime();
        }
        [HttpPost]
        public bool TestNotifyWelcome(string password, string email)
        {
            return _service.TestNotifyWelcome(password, email);
        }

        #endregion
    }
}