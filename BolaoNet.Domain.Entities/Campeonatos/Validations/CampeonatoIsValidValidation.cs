using BolaoNet.Domain.Entities.Base.Common.Validation;
using BolaoNet.Domain.Entities.Campeonatos.Specifications.CampeonatoSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos.Validations
{
    public class CampeonatoIsValidValidation : Validation<Campeonato>
    {
        #region Constructors/Destructors

        public CampeonatoIsValidValidation()
        {
            base.AddRule(new ValidationRule<Campeonato>(new CampeonatoNomeIsRequiredSpecs(), "Nome is required"));
            base.AddRule(new ValidationRule<Campeonato>(new CampeonatoNomeLengthMustBeLowerThan150Spec(), "Campeonato Nome length must be lower than 150"));
            
        }

        #endregion
    }
}
