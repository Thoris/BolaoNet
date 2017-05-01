using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Exceptions
{
    public class IntegrationBaseException : Exception
    {
        #region Constructors/Destructors

        public IntegrationBaseException()
            : base()
        {

        }
        public IntegrationBaseException(string message)
            : base(message)
        {

        }
        public IntegrationBaseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        #endregion
    }
}
