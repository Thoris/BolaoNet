using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Base.Common.Interfaces.Validation
{
    public interface IValidation<in T>
    {
        ValidationResult Valid(T entity);
    }
}
