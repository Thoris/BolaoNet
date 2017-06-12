
using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Base
{
    public abstract class BaseSelfValidationEntity : AuditModel
    {
        #region Properties

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        #endregion

        #region Constructors/Destructors

        public BaseSelfValidationEntity()
        {

        }

        #endregion
    }
}
