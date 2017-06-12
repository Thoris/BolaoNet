using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Base.Common.Validation
{
    public class ValidationError
    {
        #region Properties

        public string Message { get; set; }

        #endregion

        #region Constructors/Destructors

        public ValidationError(string message)
        {
            Message = message;
        }

        #endregion
    }
}
