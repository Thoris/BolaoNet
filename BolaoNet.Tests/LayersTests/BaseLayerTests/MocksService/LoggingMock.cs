using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests.MocksService
{
    public class LoggingMock : Domain.Interfaces.Services.Logging.ILogging
    {
        public void Verbose(object sourceObject, string message, params string[] args)
        { 
        }

        public void Trace(object sourceObject, string message, params string[] args)
        { 
        }

        public void Info(object sourceObject, string message, params string[] args)
        { 
        }

        public void Debug(object sourceObject, string message, params string[] args)
        { 
        }

        public void Warn(object sourceObject, string message, params string[] args)
        { 
        }

        public void Error(object sourceObject, string message, params string[] args)
        { 
        }

        public void Fatal(object sourceObject, string message, params string[] args)
        { 
        }

        public void Fatal(object sourceObject, Exception ex)
        { 
        }
    }
}
