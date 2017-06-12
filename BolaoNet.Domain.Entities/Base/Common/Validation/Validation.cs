using BolaoNet.Domain.Entities.Base.Common.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Base.Common.Validation
{
    public class Validation<T> : IValidation<T>
            where T : class
    {
        #region Variables

        private readonly Dictionary<string, IValidationRule<T>> _validationsRules;

        #endregion

        #region Constructors/Destructors

        public Validation()
        {
            _validationsRules = new Dictionary<string, IValidationRule<T>>();
        }

        #endregion

        #region Methods

        protected virtual void AddRule(IValidationRule<T> validationRule)
        {
            var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("D");
            _validationsRules.Add(ruleName, validationRule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            _validationsRules.Remove(ruleName);
        }

        public virtual ValidationResult Valid(T entity)
        {
            var result = new ValidationResult();
            foreach (var key in _validationsRules.Keys)
            {
                var rule = _validationsRules[key];
                if (!rule.Valid(entity))
                    result.Add(new ValidationError(rule.ErrorMessage));
            }
            return result;
        }

        #endregion
    }
}
