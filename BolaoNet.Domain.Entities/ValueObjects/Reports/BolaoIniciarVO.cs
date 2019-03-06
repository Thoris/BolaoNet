using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects.Reports
{
    public class BolaoIniciarVO
    {
        public IList<Domain.Entities.Boloes.BolaoRegra> Regras { get; set; }
        public IList<BolaoMembroApostasVO> Membros { get; set; }
        public Domain.Entities.Boloes.Bolao Bolao { get; set; }
        public IList<Domain.Entities.Campeonatos.Jogo> Jogos { get; set; }
        public Domain.Entities.Campeonatos.Campeonato.Tipos TipoCampeonato { get; set; }
    }
}
