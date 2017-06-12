using BolaoNet.Domain.Entities.Base.Common.Interfaces.Validation;
using BolaoNet.Domain.Entities.Base.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Base.Common.Validation
{
    public class ValidationRule<T> : IValidationRule<T>
    {
        #region Variables

        private readonly ISpecification<T> _specificationRule;

        #endregion

        #region Properties

        public string ErrorMessage { get; private set; }

        #endregion

        #region Constructors/Destructors

        public ValidationRule(ISpecification<T> specificationRule, string errorMessage)
        {
            _specificationRule = specificationRule;
            ErrorMessage = errorMessage;
        }

        #endregion

        #region Methods

        public bool Valid(T entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }

        #endregion
    }
}
