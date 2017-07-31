using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects.Reports
{
    public class BolaoFinalVO : BolaoIniciarVO
    {
        public IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> Classificacao { get; set; }
        public IList<Domain.Entities.Boloes.BolaoPremio> Premios { get; set; }
    }
}
