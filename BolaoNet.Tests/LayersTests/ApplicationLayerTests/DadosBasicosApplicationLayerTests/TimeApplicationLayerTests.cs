using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.ApplicationLayerTests.DadosBasicosApplicationLayerTests
{ 

    [TestClass]
    public class TimeApplicationLayerTests
    {
        #region Variables

        private readonly Domain.Interfaces.Repositories.DadosBasicos.ITimeDao _dao;

        #endregion

        #region Constructors/Destructors

        public TimeApplicationLayerTests()
        {
            BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock mock =
                new BaseLayerTests.MocksRepository.DadosBasicosMockRepository.TimeRepositoryDaoMock();

            _dao = mock.Setup();

        }

        #endregion

        #region Methods

        private BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp GetObjectToTest()
        {
            //Initialization
            Domain.Interfaces.Services.DadosBasicos.ITimeService service =
                new Domain.Services.DadosBasicos.TimeService(
                    Constants.UserName, _dao,
                    new BolaoNet.Tests.LayersTests.BaseLayerTests.MocksService.LoggingMock());


            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp app =
                new BolaoNet.Application.DadosBasicos.TimeApp(service);

            return app;
        }

        [TestMethod]
        public void TestApplicationTimeCount()
        {

            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();

            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestCount();
        }
        [TestMethod]
        public void TestApplicationTimeCountWhere()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestCountWhere();
        }
        [TestMethod]
        public void TestApplicationTimeDelete()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestDelete();
        }
        [TestMethod]
        public void TestApplicationTimeGetAll()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestGetAll();
        }
        [TestMethod]
        public void TestApplicationTimeGetList()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestGetList();
        }
        [TestMethod]
        public void TestApplicationTimeInsert()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestInsert();
        }
        [TestMethod]
        public void TestApplicationTimeLoad()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);

            test.TestLoad();
        }
        [TestMethod]
        public void TestApplicationTimeUpdate()
        {
            //Initialization
            BolaoNet.Application.Interfaces.DadosBasicos.ITimeApp service = GetObjectToTest();



            BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService> test =
                new BaseLayerTests.BaseDadosBasicosTests.TimeLayerTests<Domain.Interfaces.Services.DadosBasicos.ITimeService>(service);
            
            test.TestUpdate();
        }

        #endregion
    }

}
