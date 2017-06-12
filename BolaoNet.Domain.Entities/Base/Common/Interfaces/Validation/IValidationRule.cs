using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Base.Common.Interfaces.Validation
{
    public interface IValidationRule<in T>
    {
        string ErrorMessage { get; }
        bool Valid(T entity);
    }
}
