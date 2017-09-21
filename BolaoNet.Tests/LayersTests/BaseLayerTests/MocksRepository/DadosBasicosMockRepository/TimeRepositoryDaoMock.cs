using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository.DadosBasicosMockRepository
{
    public class TimeRepositoryDaoMock 
        : GenericRepositoryDaoMock<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao, Domain.Entities.DadosBasicos.Time>
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

        public Domain.Interfaces.Repositories.DadosBasicos.ITimeDao Setup()
        {
            IList<Domain.Entities.DadosBasicos.Time> list = new List<Domain.Entities.DadosBasicos.Time>();
            list.Add(new Domain.Entities.DadosBasicos.Time("XXXXXX"));
            list.Add(new Domain.Entities.DadosBasicos.Time("YYYYYY"));
            list.Add(new Domain.Entities.DadosBasicos.Time("ZZZZZZ"));
              
            return base.Setup( _mock, list);
        }

        public override Func<Domain.Entities.DadosBasicos.Time, bool> GetPredicate(Domain.Entities.DadosBasicos.Time entity)
        {
            return x => string.Compare (x.Nome, entity.Nome, true) == 0;            
        }

        #endregion
    }
}
