using BolaoNet.Domain.Entities.Base.Common.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos.Specifications.CampeonatoSpecs
{
    public class CampeonatoNomeIsRequiredSpecs : ISpecification<Campeonato>
    {
        public bool IsSatisfiedBy(Campeonato entity)
        {
            return entity.Nome.Trim().Length > 0;
        }
    }
}
