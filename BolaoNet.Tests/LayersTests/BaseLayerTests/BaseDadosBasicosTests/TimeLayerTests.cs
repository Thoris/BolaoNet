using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests.BaseDadosBasicosTests
{
    public class TimeLayerTests<L> :
        BaseGenericDataTests<Domain.Entities.DadosBasicos.Time, L> 
    {
        #region Constructors/Destructors

        public TimeLayerTests(L performer)
            : base (performer)
        {
            
        }

        #endregion

        #region Methods

        protected override Domain.Entities.DadosBasicos.Time GenerateEntity()
        {
            return new Domain.Entities.DadosBasicos.Time("Time 1")
                {
                };
        }

        protected override Domain.Entities.DadosBasicos.Time GenerateEntityToUpdate()
        {
            return new Domain.Entities.DadosBasicos.Time("Time 2")
                {
                };
        }

        #endregion
    }
}
