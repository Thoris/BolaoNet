using BolaoNet.Domain.Entities.Base.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos.Specifications.CampeonatoSpecs
{
    public class CampeonatoNomeLengthMustBeLowerThan150Spec : ISpecification<Campeonato>
    {
        public bool IsSatisfiedBy(Campeonato entity)
        {
            return entity.Nome.Trim().Length < 150;
        }
    }
}
