using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BolaoNet.Tests.LayersTests.ServiceLayerTests.DadosBasicosServiceLayerTests
{
    [TestClass]
    public class TimeServiceLayerTests 
    {
        #region Variables

        private readonly Domain.Interfaces.Repositories.DadosBasicos.ITimeDao _dao; 

        #endregion

        #region Constructors/Destructors

        public TimeServiceLayerTests()
        {
            BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock mock = 
                new BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock();

            _dao = mock.Setup();

        }

        #endregion

        #region Methods

        private Domain.Interfaces.Services.DadosBasicos.ITimeService GetObjectToTest()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service =
                new Domain.Services.DadosBasicos.TimeService(
                    Constants.UserName, _dao,
                    new BolaoNet.Tests.LayersTests.BaseLayerTests.MocksService.LoggingMock());

            return service;
        }

        [TestMethod]
        public void TestServiceTimeCount()
        {

            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();

            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestCount();            
        }
        [TestMethod]
        public void TestServiceTimeCountWhere()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestCountWhere();
        }
        [TestMethod]
        public void TestServiceTimeDelete()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestDelete();
        }
        [TestMethod]
        public void TestServiceTimeGetAll()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestGetAll();
        }
        [TestMethod]
        public void TestServiceTimeGetList()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestGetList();
        }
        [TestMethod]
        public void TestServiceTimeInsert()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestInsert();
        }
        [TestMethod]
        public void TestServiceTimeLoad()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestLoad();
        }
        [TestMethod]
        public void TestServiceTimeUpdate()
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
