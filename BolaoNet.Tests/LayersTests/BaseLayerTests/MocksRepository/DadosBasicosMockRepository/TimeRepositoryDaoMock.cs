using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository
{
    public class TimeRepositoryDaoMock 
        : GenericRepositoryDaoMock<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao>
    {
        #region Variables

        private Mock<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao> _mock;

        #endregion


        #region Constructors/Destructors

        public TimeRepositoryDaoMock()
            : base()
        {
            _mock = new Mock<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao>();
        }

        #endregion


        #region Methods


        public void Setup()
        {
            IList<Domain.Entities.DadosBasicos.Time> list = new List<Domain.Entities.DadosBasicos.Time>();

            //base.Setup(_mock, list);
        }

        public override Func<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao, bool> GetPredicate(Domain.Interfaces.Repositories.DadosBasicos.ITimeDao entity)
        {
            return base.GetPredicate(entity);
        }

        #endregion
    }
}
