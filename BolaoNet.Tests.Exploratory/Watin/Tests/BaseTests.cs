using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin.Tests
{
    public abstract class BaseTests
    {
        #region Variables

        private Browser _browser;

        #endregion

        #region Properties

        public Browser Browser 
        {
            get { return _browser; }
            set { _browser = value; }
        }

        #endregion

        #region Constructors/Destructors

        public BaseTests()
        {

        }

        #endregion
    }
}
