using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Logging
{
    public interface ILogging
    {
        void Info(object sourceObject, string message, params string[] args);
        void Debug(object sourceObject, string message, params string[] args);
        void Warn(object sourceObject, string message, params string[] args);
        void Error(object sourceObject, string message, params string[] args);
        void Fatal(object sourceObject, string message, params string[] args);
        void Fatal(object sourceObject, Exception ex);
    }
}
