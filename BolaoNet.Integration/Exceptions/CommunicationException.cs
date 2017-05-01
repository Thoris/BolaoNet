using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Exceptions
{
    public class CommunicationException : IntegrationBaseException
    {
        #region Constructors/Destructors

        public CommunicationException()
            : base()
        {

        }
        public CommunicationException(string message)
            : base(message)
        {

        }
        public CommunicationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        #endregion
    }
}
