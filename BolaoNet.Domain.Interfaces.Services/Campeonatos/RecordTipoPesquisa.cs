using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public enum RecordTipoPesquisa
    {
        QtdJogosSemGanhar = 1,
        QtdJogosSemPerder = 2,
        SequenciaDerrotas = 3,
        SequenciaEmpates = 4,
        SequenciaVitorias = 5,
        RecordQtdJogosSemGanhar = 6,
        RecordQtdJogosSemPerder = 7,
        RecordSeqDerrotas = 8,
        RecordSeqEmpates = 9,
        RecordSeqVitorias = 10,
    }
}
