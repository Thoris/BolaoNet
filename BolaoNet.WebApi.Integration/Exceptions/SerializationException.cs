using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Exceptions
{
    public class SerializationException : Exception
    {
        #region Constructors/Destructors

        public SerializationException()
            : base()
        {

        }
        public SerializationException(string message)
            : base(message)
        {

        }
        public SerializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public SerializationException(string message, string outputMessage, Type type, Exception innerException)
        {

        }

        #endregion
    }
}
