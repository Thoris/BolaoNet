using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.IntegrationTests.DadosBasicosIntegrationLayerTests
{

    [TestClass]
    public class TimeIntegrationLayerTests
    {
        #region Variables

        private readonly Domain.Interfaces.Repositories.DadosBasicos.ITimeDao _dao;

        #endregion

        #region Constructors/Destructors

        public TimeIntegrationLayerTests()
        {
            BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock mock =
                new BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock();

            _dao = mock.Setup();

        }

        #endregion

        #region Methods

        private BolaoNet.WebApi.Integration.DadosBasicos.TimeIntegration GetObjectToTest()
        {
            BolaoNet.WebApi.Integration.DadosBasicos.TimeIntegration integration =
                new WebApi.Integration.DadosBasicos.TimeIntegration(Constants.UrlWebApi, "");




            return integration;
        }
         

        #endregion
    }
}
