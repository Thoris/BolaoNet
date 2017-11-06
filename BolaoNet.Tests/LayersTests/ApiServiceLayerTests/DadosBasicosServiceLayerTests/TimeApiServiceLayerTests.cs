using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.ApiServiceLayerTests.DadosBasicosServiceLayerTests
{ 
    [TestClass]
    [Ignore]
    public class TimeApiServiceLayerTests
    {
        #region Variables

        private readonly Domain.Interfaces.Repositories.DadosBasicos.ITimeDao _dao;

        #endregion

        #region Constructors/Destructors

        public TimeApiServiceLayerTests()
        {
            BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock mock =
                new BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock();

            _dao = mock.Setup();

        }

        #endregion

        #region Methods

        private BolaoNet.Services.Areas.DadosBasicos.Controllers.TimeController GetObjectToTest()
        {
            Domain.Interfaces.Services.DadosBasicos.ITimeService service =
                new Domain.Services.DadosBasicos.TimeService(
                    Constants.UserName, _dao,
                    new BolaoNet.Tests.LayersTests.BaseLayerTests.MocksService.LoggingMock());

            BolaoNet.Services.Areas.DadosBasicos.Controllers.TimeController res = 
                new Services.Areas.DadosBasicos.Controllers.TimeController(service);


            return res;
        }

        [TestMethod]
        public void TestWebApiTimeCount()
        {

            BolaoNet.Services.Areas.DadosBasicos.Controllers.TimeController service = GetObjectToTest();

            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestCount();
        }
        [TestMethod]
        public void TestWebApiTimeCountWhere()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestCountWhere();
        }
        [TestMethod]
        public void TestWebApiTimeDelete()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestDelete();
        }
        [TestMethod]
        public void TestWebApiTimeGetAll()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestGetAll();
        }
        [TestMethod]
        public void TestWebApiTimeGetList()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestGetList();
        }
        [TestMethod]
        public void TestWebApiTimeInsert()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestInsert();
        }
        [TestMethod]
        public void TestWebApiTimeLoad()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestLoad();
        }
        [TestMethod]
        public void TestWebApiTimeUpdate()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestUpdate();
        }

        #endregion
    }
}
